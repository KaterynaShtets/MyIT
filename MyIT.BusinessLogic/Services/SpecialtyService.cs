using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class SpecialtyService : ISpecialityService
{
    private readonly IRepository<Speciality> _specialityRepository;
    private readonly IRepository<PsychologistSpeciality> _psychologistSpecialityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _specialityRepository = unitOfWork.GetRepository<Speciality>();
        _psychologistSpecialityRepository = unitOfWork.GetRepository<PsychologistSpeciality>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SpecialityDto>> GetAllSpecialityAsync()
    {
        var specialties =  await _specialityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SpecialityDto>>(specialties);
    }

    public async Task AddSpecialityAsync(SpecialityDto university)
    {
        _specialityRepository.Create(_mapper.Map<Speciality>(university));
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task AddPsychologistSpecialityAsync(Guid psychologistId, SpecialityDto specialityDto)
    {
        var specialityId = _specialityRepository.Create(_mapper.Map<Speciality>(specialityDto));
        _psychologistSpecialityRepository.Create(
            new PsychologistSpeciality
            {
                PsychologistId = psychologistId,
                SpecialityId = specialityId
            });
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateSpecialityAsync(Guid id, SpecialityDto specialityDto)
    {
        var speciality = _mapper.Map<Speciality>(specialityDto);
        speciality.Id = id;
        _specialityRepository.Update(speciality);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteSpecialityAsync(Guid specialityId)
    {
        _specialityRepository.Delete(specialityId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<SpecialityDto>> GetAllPsychologistSpecialities(Guid psychologistId)
    {
        var psychologistSpecialties =  await _psychologistSpecialityRepository.GetAsync(
            filter: x=>x.PsychologistId == psychologistId,
            includeProperties: x=>x.Include(s => s.Speciality));
        var specialities = psychologistSpecialties.Select(x => x.Speciality);
        return _mapper.Map<IEnumerable<SpecialityDto>>(specialities);
    }
}