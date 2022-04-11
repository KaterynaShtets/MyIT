using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class EducationalProgramService : IEducationalProgramService
{
    private readonly IRepository<EducationalProgram> _educationalProgramRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EducationalProgramService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _educationalProgramRepository = unitOfWork.GetRepository<EducationalProgram>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EducationalProgramDto>> GetAllEducationalProgramsAsync(Guid facultyId)
    {
        var educationalPrograms =  await _educationalProgramRepository.GetAsync(x=>x.FacultyId == facultyId);
        return _mapper.Map<IEnumerable<EducationalProgramDto>>(educationalPrograms);
    }
    
    public async Task<EducationalProgramDto> GetEducationalProgramByIdAsync(Guid educationalProgramId)
    {
        var educationalProgram =  await _educationalProgramRepository.GetAsync(educationalProgramId);
        return _mapper.Map<EducationalProgramDto>(educationalProgram);
    }
    
    public async Task AddEducationalProgramAsync(Guid facultyId, EducationalProgramDto educationalProgramDto)
    {
        var educationalProgram = _mapper.Map<EducationalProgram>(educationalProgramDto);
        educationalProgram.FacultyId = facultyId;
        _educationalProgramRepository.Create(educationalProgram);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateEducationalProgramAsync(Guid id, EducationalProgramDto educationalProgramDto)
    {
        var educationalProgram = await _educationalProgramRepository.GetAsync(id);
        var educationalProgramMapped = _mapper.Map(educationalProgramDto, educationalProgram);
        educationalProgramMapped.Id = id;
        educationalProgramMapped.FacultyId = educationalProgram.FacultyId;
        _educationalProgramRepository.Update(educationalProgram);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteEducationalProgramAsync(Guid educationalProgramId)
    {
        _educationalProgramRepository.Delete(educationalProgramId);
        await _unitOfWork.SaveChangesAsync();
    }
}