using Microsoft.AspNetCore.Http;
using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IPsychologistService
{
    Task<IEnumerable<PsychologistDto>> GetAllPsychologistAsync();
    Task<PsychologistDto> GetPsychologistByIdAsync(Guid psychologistId);
    Task AddPsychologistAsync(PsychologistDto psychologistDto);
    Task UpdatePsychologistAsync(Guid id, PsychologistDto psychologistDto);
    Task VerifyPsychologistAsync(Guid id);
    Task DeletePsychologistAsync(Guid psychologistId);
    Task AddPsychologistSpecialityAsync(Guid psychologistId, Guid specialityId);
    Task<IEnumerable<PsychologistDto>> GetAllPsychologistsBySpeciality(Guid specialityId);
    Task UploadPsychologistPhotoAsync(Guid psychologistId, IFormFile file);
    Task UploadDiplomaPhotoAsync(Guid psychologistId, IFormFile file);
    Task<(byte[], string)> GetPsychologistPhotoAsync(Guid psychologistId);
    Task<(byte[], string)> GetPsychologistDiplomaAsync(Guid psychologistId);
}