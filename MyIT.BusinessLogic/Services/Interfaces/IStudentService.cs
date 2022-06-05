using Microsoft.AspNetCore.Http;
using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync(Guid groupId);
    Task<StudentDto> GetStudentByIdAsync(Guid studentId);
    Task AddStudentAsync(Guid groupId, StudentDto studentDto);
    Task UpdateStudentAsync(Guid id, StudentDto studentDto);
    Task DeleteStudentAsync(Guid studentId);
    Task UploadStudentPhotoStudentAsync(Guid studentId, IFormFile file);
}