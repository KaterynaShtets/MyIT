using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class TestService: ITestService
{
    private readonly IRepository<Test> _testRepository;
    private readonly IRepository<AssignedStudentTest> _assignedStudentTestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _testRepository = unitOfWork.GetRepository<Test>();
        _assignedStudentTestRepository = unitOfWork.GetRepository<AssignedStudentTest>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TestDto>> GetAllTestAsync(Guid psychologistId)
    {
        var tests =  await _testRepository.GetAsync(x=>x.PsychologistId == psychologistId);
        return _mapper.Map<IEnumerable<TestDto>>(tests);
    }
    
    public async Task<TestDto> GetTestByIdAsync(Guid testId)
    {
        var test = await _testRepository.GetAsync(testId);
        return _mapper.Map<TestDto>(test);
    }
    
    public async Task AddTestAsync(Guid psychologistId, TestDto testDto)
    {
        var test = _mapper.Map<Test>(testDto);
        test.PsychologistId = psychologistId;
        _testRepository.Create(test);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateTestAsync(Guid id, TestDto testDto)
    {
        var test = await _testRepository.GetAsync(id);
        var testMapped = _mapper.Map(testDto, test);
        testMapped.Id = id;
        testMapped.PsychologistId = test.PsychologistId;
        _testRepository.Update(testMapped);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteTestAsync(Guid testId)
    {
        _testRepository.Delete(testId);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<TestDto>> GetAllStudentAssignedTests(Guid studentId)
    {
        var assignedTests =  await _assignedStudentTestRepository.GetAsync(
            filter: x=>x.StudentId == studentId,
            includeProperties: x=>x.Include(s => s.Test));
        var tests = assignedTests.Select(x => x.Test);
        return _mapper.Map<IEnumerable<TestDto>>(tests);
    }
    
    public async Task AssignTest(Guid testId, Guid studentId)
    {
        _assignedStudentTestRepository.Create(
            new AssignedStudentTest()
            {
                TestId = testId,
                StudentId = studentId,
                Date = DateTime.Now,
                IsCompleted = false
            });
        await _unitOfWork.SaveChangesAsync();
    }
}