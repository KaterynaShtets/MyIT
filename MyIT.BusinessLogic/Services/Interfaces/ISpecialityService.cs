using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface ISpecialityService
{
    Task<IEnumerable<SpecialityDto>> GetAllSpecialityAsync();
    Task AddSpecialityAsync(SpecialityDto specialityDto);
    Task AddPsychologistSpecialityAsync(Guid psychologistId, SpecialityDto specialityDto);
    Task UpdateSpecialityAsync(Guid id, SpecialityDto specialityDto);
    Task DeleteSpecialityAsync(Guid specialityId);
    Task<IEnumerable<SpecialityDto>> GetAllPsychologistSpecialities(Guid psychologistId);
}