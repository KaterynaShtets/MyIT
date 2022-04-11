using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class FacultyService : IFacultyService
{
    private readonly IRepository<Faculty> _facultiesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _facultiesRepository = unitOfWork.GetRepository<Faculty>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FacultyDto>> GetAllFacultiesAsync(Guid universityId)
    {
        var faculties =  await _facultiesRepository.GetAsync(x=>x.UniversityId == universityId);
        return _mapper.Map<IEnumerable<FacultyDto>>(faculties);
    }
    
    public async Task<FacultyDto> GetFacultyByIdAsync(Guid facultyId)
    {
        var faculty =  await _facultiesRepository.GetAsync(facultyId);
        return _mapper.Map<FacultyDto>(faculty);
    }
    
    public async Task AddFacultyAsync(Guid universityId, FacultyDto facultyDto)
    {
        var faculty = _mapper.Map<Faculty>(facultyDto);
        faculty.UniversityId = universityId;
        _facultiesRepository.Create(faculty);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateFacultyAsync(Guid id, FacultyDto facultyDto)
    {
        var faculty = await _facultiesRepository.GetAsync(id);
        var facultyMapped = _mapper.Map(facultyDto, faculty);
        facultyMapped.Id = id;
        facultyMapped.UniversityId = faculty.UniversityId;
        _facultiesRepository.Update(faculty);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteFacultyAsync(Guid facultyId)
    {
        _facultiesRepository.Delete(facultyId);
        await _unitOfWork.SaveChangesAsync();
    }
}