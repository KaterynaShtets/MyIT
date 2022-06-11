using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Helpers;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _studentRepository = unitOfWork.GetRepository<Student>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(Guid groupId)
    {
        var students = await _studentRepository.GetAsync(x => x.GroupId == groupId);
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }

    public async Task<StudentDto> GetStudentByIdAsync(Guid studentId)
    {
        var student = (await _studentRepository.GetAsync(
            filter: x => x.Id == studentId, 
            includeProperties: x => x.Include(s => s.Group.EducationalProgram)))
            .First();
        return _mapper.Map<StudentDto>(student);
    }

    public async Task AddStudentAsync(Guid groupId, StudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);
        student.GroupId = groupId;
        _studentRepository.Create(student);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Guid id, StudentDto studentDto)
    {
        var student = await _studentRepository.GetAsync(id);
        var studentMapped = _mapper.Map(studentDto, student);
        studentMapped.Id = id;
        studentMapped.GroupId = student.GroupId;
        _studentRepository.Update(studentMapped);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UploadStudentPhotoStudentAsync(Guid studentId, IFormFile file)
    {
        var student = await _studentRepository.GetAsync(studentId);
        var link = await S3Helper.UploadFile(file);
        student.PhotoPath = link;
        _studentRepository.Update(student);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<(byte[], string)> GetStudentPhotoStudentAsync(Guid studentId)
    {
        var student = await _studentRepository.GetAsync(studentId);
        var file = student.PhotoPath.Split("/");
        var fileName = file.Last();
        var image = await S3Helper.DownloadFileAsync(fileName);
        return (image, fileName);
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        _studentRepository.Delete(studentId);
        await _unitOfWork.SaveChangesAsync();
    }
}