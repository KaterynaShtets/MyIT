using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IEducationalProgramService
{
    Task<IEnumerable<EducationalProgramDto>> GetAllEducationalProgramsAsync(Guid facultyId);
    Task<EducationalProgramDto> GetEducationalProgramByIdAsync(Guid educationalProgramId);
    Task AddEducationalProgramAsync(Guid facultyId, EducationalProgramDto educationalProgramDto);
    Task UpdateEducationalProgramAsync(Guid id, EducationalProgramDto educationalProgramDto);
    Task DeleteEducationalProgramAsync(Guid educationalProgramId);
}