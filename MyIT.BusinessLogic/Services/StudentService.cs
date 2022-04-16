using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
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
        var students =  await _studentRepository.GetAsync(x=>x.GroupId == groupId);
        return _mapper.Map<IEnumerable<StudentDto>>(students);
    }
    
    public async Task<StudentDto> GetStudentByIdAsync(Guid studentId)
    {
        var group = await _studentRepository.GetAsync(studentId);
        return _mapper.Map<StudentDto>(group);
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
    
    public async Task DeleteStudentAsync(Guid studentId)
    {
        _studentRepository.Delete(studentId);
        await _unitOfWork.SaveChangesAsync();
    }
}