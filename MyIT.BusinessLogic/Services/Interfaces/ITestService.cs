using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface ITestService
{
    Task<IEnumerable<TestDto>> GetAllTestAsync(Guid psychologistId);
    Task<IEnumerable<AssignedStudentTestDto>> GetAllStudentAssignedTests(Guid studentId);
    Task<TestDto> GetTestByIdAsync(Guid testId);
    Task AddTestAsync(Guid psychologistId, TestDto testDto);
    Task AssignTest(Guid testId, Guid studentId);
    Task UpdateTestAsync(Guid id, TestDto testDto);
    Task DeleteTestAsync(Guid testId);
    Task AddTestResultAsync(Guid assignedTestId, string resultJson);
}