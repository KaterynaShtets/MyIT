using Microsoft.AspNetCore.Http;
using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsByGroupAsync(Guid groupId);
    Task<IEnumerable<StudentDto>> GetAllStudentsByUniversityAsync(Guid universityId);
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    Task<StudentDto> GetStudentByIdAsync(Guid studentId);
    Task AddStudentAsync(Guid groupId, StudentDto studentDto);
    Task UpdateStudentAsync(Guid id, StudentDto studentDto);
    Task DeleteStudentAsync(Guid studentId);
    Task UploadStudentPhotoStudentAsync(Guid studentId, IFormFile file);
    Task<(byte[], string)> GetStudentPhotoStudentAsync(Guid studentId);
}