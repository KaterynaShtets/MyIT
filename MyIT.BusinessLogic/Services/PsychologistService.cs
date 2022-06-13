using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Helpers;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class PsychologistService : IPsychologistService
{
    private readonly IRepository<Psychologist> _psychologistRepository;
    private readonly IRepository<PsychologistSpeciality> _psychologistSpecialityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PsychologistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _psychologistRepository = unitOfWork.GetRepository<Psychologist>();
        _psychologistSpecialityRepository = unitOfWork.GetRepository<PsychologistSpeciality>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PsychologistDto>> GetAllPsychologistAsync()
    {
        var psychologists =  await _psychologistRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PsychologistDto>>(psychologists);
    }
    
    public async Task<PsychologistDto> GetPsychologistByIdAsync(Guid psychologistId)
    {
        var university =  await _psychologistRepository.GetAsync(psychologistId);
        return _mapper.Map<PsychologistDto>(university);
    }
    
    public async Task AddPsychologistAsync(PsychologistDto psychologistDto)
    {
        _psychologistRepository.Create(_mapper.Map<Psychologist>(psychologistDto));
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task AddPsychologistSpecialityAsync(Guid psychologistId, Guid specialityId)
    {
        _psychologistSpecialityRepository.Create(
            new PsychologistSpeciality
            {
                PsychologistId = psychologistId,
                SpecialityId = specialityId
            });
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdatePsychologistAsync(Guid id, PsychologistDto psychologistDto)
    {
        var psychologist = _mapper.Map<Psychologist>(psychologistDto);
        psychologist.Id = id;
        _psychologistRepository.Update(psychologist);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UploadPsychologistPhotoAsync(Guid psychologistId, IFormFile file)
    {
        var student = await _psychologistRepository.GetAsync(psychologistId);
        var link = await S3Helper.UploadFile(file);
        student.PhotoPath = link;
        _psychologistRepository.Update(student);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<(byte[], string)> GetPsychologistPhotoAsync(Guid psychologistId)
    {
        var student = await _psychologistRepository.GetAsync(psychologistId);
        var file = student.PhotoPath.Split("/");
        var fileName = file.Last();
        var image = await S3Helper.DownloadFileAsync(fileName);
        return (image, fileName);
    }
    
    public async Task<(byte[], string)> GetPsychologistDiplomaAsync(Guid psychologistId)
    {
        var student = await _psychologistRepository.GetAsync(psychologistId);
        var file = student.DiplomPath.Split("/");
        var fileName = file.Last();
        var image = await S3Helper.DownloadFileAsync(fileName);
        return (image, fileName);
    }
    
    public async Task UploadDiplomaPhotoAsync(Guid psychologistId, IFormFile file)
    {
        var student = await _psychologistRepository.GetAsync(psychologistId);
        var link = await S3Helper.UploadFile(file);
        student.DiplomPath = link;
        _psychologistRepository.Update(student);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task VerifyPsychologistAsync(Guid id)
    {
        var psychologist = await _psychologistRepository.GetAsync(id);
        psychologist.isVerified = true;
        _psychologistRepository.Update(psychologist);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeletePsychologistAsync(Guid psychologistId)
    {
        _psychologistRepository.Delete(psychologistId);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<PsychologistDto>> GetAllPsychologistsBySpeciality(Guid specialityId)
    {
        var psychologistSpecialties =  await _psychologistSpecialityRepository.GetAsync(
            filter: x=>x.SpecialityId == specialityId,
            includeProperties: x=>x.Include(s => s.Psychologist));
        var psychologists = psychologistSpecialties.Select(x => x.Psychologist);
        return _mapper.Map<IEnumerable<PsychologistDto>>(psychologists);
    }

    public async Task<Psychologist> GetPsychologistByEmailAsync(string email)
    {
        var psychologists = await _psychologistRepository.GetAsync(x => x.Email == email);

        var psych = psychologists.FirstOrDefault();

        return psych;
    }
}