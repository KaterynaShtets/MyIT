using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IFacultyService
{
    Task<IEnumerable<FacultyDto>> GetAllFacultiesAsync(Guid universityId);
    Task<FacultyDto> GetFacultyByIdAsync(Guid facultyId);
    Task AddFacultyAsync(Guid universityId, FacultyDto facultyDto);
    Task UpdateFacultyAsync(Guid id, FacultyDto facultyDto);
    Task DeleteFacultyAsync(Guid facultyId);
}