using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class PsychologistService : IPsychologistService
{
    private readonly IRepository<Psychologist> _psychologistRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PsychologistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _psychologistRepository = unitOfWork.GetRepository<Psychologist>();
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
    
    public async Task UpdatePsychologistAsync(Guid id, PsychologistDto psychologistDto)
    {
        var psychologist = _mapper.Map<Psychologist>(psychologistDto);
        psychologist.Id = id;
        _psychologistRepository.Update(psychologist);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeletePsychologistAsync(Guid psychologistId)
    {
        _psychologistRepository.Delete(psychologistId);
        await _unitOfWork.SaveChangesAsync();
    }
}