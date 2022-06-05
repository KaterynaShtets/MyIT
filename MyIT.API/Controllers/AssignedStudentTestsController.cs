﻿using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("upload")]
    public async Task<IActionResult> UploadDocumentToS3([FromQuery] Guid assignedStudentTestId, IFormFile file)
    {
        await _testService.UploadTestImageAsync(assignedStudentTestId, file);

        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AssignTestAsync([FromQuery] Guid testId, [FromQuery] Guid studentId)
    {
        var assignedTestId = await _testService.AssignTest(testId, studentId);

        return Ok(new { studentAssignedTestId = assignedTestId });
    }

    [HttpPost("{assignedTestId}")]
    public async Task<IActionResult> AddTestResultAsync([FromRoute] Guid assignedTestId, [FromBody] string resultJson)
    {
        await _testService.AddTestResultAsync(assignedTestId, resultJson);

        return Ok();
    }

    [HttpGet("getLastProfessionTestsResult")]
    public async Task<IActionResult> GetLastProfessionTestsResult([FromQuery] Guid studentId)
    {
        var result = await _testService.GetLastProfessionTestsResult(studentId);

        return Ok(result);
    }
}