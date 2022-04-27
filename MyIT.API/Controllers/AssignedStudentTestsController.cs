using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/assignedStudentTests")]
public class AssignedStudentTestsController : Controller
{
    private readonly ITestService _testService;

    public AssignedStudentTestsController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid studentId)
    {
        var tests = await _testService.GetAllStudentAssignedTests(studentId);

        return Ok(tests);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPsychologistSpecialityAsync([FromQuery]Guid testId,[FromQuery] Guid studentId)
    {
        await _testService.AssignTest(testId, studentId);

        return Ok();
    }
    
}