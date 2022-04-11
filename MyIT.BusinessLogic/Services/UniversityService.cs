using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class UniversityService : IUniversityService
{
    private readonly IRepository<University> _universityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UniversityService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _universityRepository = unitOfWork.GetRepository<University>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UniversityDto>> GetAllUniversityAsync()
    {
       var universities =  await _universityRepository.GetAllAsync();
       return _mapper.Map<IEnumerable<UniversityDto>>(universities);
    }
    
    public async Task<UniversityDto> GetUniversityByIdAsync(Guid universityId)
    {
        var university =  await _universityRepository.GetAsync(universityId);
        return _mapper.Map<UniversityDto>(university);
    }
    
    public async Task AddUniversityAsync(UniversityDto university)
    {
        _universityRepository.Create(_mapper.Map<University>(university));
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateUniversityAsync(Guid id, UniversityDto universityDto)
    {
        var university = _mapper.Map<University>(universityDto);
        university.Id = id;
        _universityRepository.Update(university);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteUniversityAsync(Guid universityId)
    {
        _universityRepository.Delete(universityId);
        await _unitOfWork.SaveChangesAsync();
    }
}