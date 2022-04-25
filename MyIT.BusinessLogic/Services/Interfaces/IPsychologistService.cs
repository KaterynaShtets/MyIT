using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IPsychologistService
{
    Task<IEnumerable<PsychologistDto>> GetAllPsychologistAsync();
    Task<PsychologistDto> GetPsychologistByIdAsync(Guid psychologistId);
    Task AddPsychologistAsync(PsychologistDto psychologistDto);
    Task UpdatePsychologistAsync(Guid id, PsychologistDto psychologistDto);
    Task DeletePsychologistAsync(Guid psychologistId);
    Task AddPsychologistSpecialityAsync(Guid psychologistId, Guid specialityId);
    Task<IEnumerable<PsychologistDto>> GetAllPsychologistsBySpeciality(Guid specialityId);
}