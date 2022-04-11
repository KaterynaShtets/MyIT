using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IUniversityService
{
    Task<IEnumerable<UniversityDto>> GetAllUniversityAsync();
    Task AddUniversityAsync(UniversityDto university);
    Task UpdateUniversityAsync(Guid id, UniversityDto university);
    Task DeleteUniversityAsync(Guid universityId);
    Task<UniversityDto> GetUniversityByIdAsync(Guid universityId);
}