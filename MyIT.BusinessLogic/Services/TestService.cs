using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Helpers;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;
using Newtonsoft.Json;

namespace MyIT.BusinessLogic.Services;

public class TestService : ITestService
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
        var tests = await _testRepository.GetAsync(x => x.PsychologistId == psychologistId);
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

    public async Task AddTestResultAsync(Guid assignedTestId, string resultJson)
    {
        var assignedTest = await _assignedStudentTestRepository.GetAsync(
            assignedTestId,
            includeProperties: x => x.Include(at => at.Test));

        assignedTest.IsCompleted = true;
        assignedTest.ResultJson = resultJson;

        if (!string.IsNullOrEmpty(resultJson))
        {
            var resultInterpretationJson = string.Empty;
            
            if (assignedTest.Test.Name == "Draw a person")
            {
                var drawAPersonTestResult = JsonConvert.DeserializeObject<DrawAPersonTestResult>(resultJson);
                var resultNumber = drawAPersonTestResult!.Triangle * 100 + drawAPersonTestResult.Circle * 10 + drawAPersonTestResult.Square;
                resultInterpretationJson = JsonConvert.SerializeObject(DrawAPersonTestHelper.GetDrawAPersonTestResult(resultNumber));
            }
            
            if (assignedTest.Test.Name == "IT speciality test")
            {
                var itSpecialtyTestResult = JsonConvert.DeserializeObject<ITSpecialtyTestResult>(resultJson);
                var drawAPersonTestResult = (await _assignedStudentTestRepository
                    .GetAsync(filter: x => x.StudentId == assignedTest.StudentId && x.Test.Name == "Draw a person")).First().ResultInterpretationJson;
                var personType = JsonConvert.DeserializeObject<DrawAPersonInterpretationResult>(drawAPersonTestResult!)!.PersonType;
                var itSpecialtyIndex = GetItSpecialtyIndex(itSpecialtyTestResult!);
                resultInterpretationJson = DrawAPersonTestHelper.GetITSpecialityTestResult(personType, itSpecialtyIndex).ToString();
            }

            assignedTest.ResultInterpretationJson = resultInterpretationJson;
        }
        
        _assignedStudentTestRepository.Update(assignedTest);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ProfessionTestsResult> GetLastProfessionTestsResult(Guid studentId)
    {
        var recentDrawTestResult = (await _assignedStudentTestRepository.GetAsync(
            filter: x => x.StudentId == studentId && x.Test.Name == "Draw a person"))
            .OrderByDescending(x => x.Date)
            .FirstOrDefault()?
            .ResultInterpretationJson;

        var recentDrawTestResultString = JsonConvert
            .DeserializeObject<DrawAPersonInterpretationResult>(recentDrawTestResult)?
            .PersonType
            .ToString();

        var recentSpecialityTestResultString = (await _assignedStudentTestRepository.GetAsync(
            filter: x => x.StudentId == studentId && x.Test.Name == "IT speciality test"))
            .OrderByDescending(x => x.Date)
            .FirstOrDefault()?
            .ResultInterpretationJson;

        return new ProfessionTestsResult
        {
            Profession = recentSpecialityTestResultString,
            EmotionType = recentDrawTestResultString
        };
    }

    public async Task<IEnumerable<AssignedStudentTestDto>> GetAllStudentAssignedTests(Guid studentId)
    {
        var assignedTests = await _assignedStudentTestRepository.GetAsync(
            filter: x => x.StudentId == studentId,
            includeProperties: x => x.Include(s => s.Test));
        return _mapper.Map<IEnumerable<AssignedStudentTestDto>>(assignedTests);
    }

    public async Task<Guid> AssignTest(Guid testId, Guid studentId)
    {
        var assignedTestId = _assignedStudentTestRepository.Create(
            new AssignedStudentTest()
            {
                TestId = testId,
                StudentId = studentId,
                Date = DateTime.Now,
                IsCompleted = false
            });
        await _unitOfWork.SaveChangesAsync();
        return assignedTestId;
    }

    private static int GetItSpecialtyIndex(ITSpecialtyTestResult itSpecialtyTestResult)
    {
        var results = new List<int> { itSpecialtyTestResult!.A, itSpecialtyTestResult.B, itSpecialtyTestResult.C };
        return results.IndexOf(results.Max());
    }
}