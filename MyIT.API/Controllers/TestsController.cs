using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/tests")]
public class TestController : Controller
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid psychologistId)
    {
        var tests = await _testService.GetAllTestAsync(psychologistId);

        return Ok(tests);
    }

    [HttpGet("{id:Guid}", Name = nameof(TestController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var test = await _testService.GetTestByIdAsync(id);

        return Ok(test);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid psychologistId, [FromBody, Required] TestDto testDto)
    {
        await _testService.AddTestAsync(psychologistId, testDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] TestDto testDto)
    {
        await _testService.UpdateTestAsync(id, testDto);

        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _testService.DeleteTestAsync(id);

        return NoContent();
    }
}