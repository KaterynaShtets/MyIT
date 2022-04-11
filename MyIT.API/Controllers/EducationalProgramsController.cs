using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/educationalPrograms")]
public class EducationalProgramsController : Controller
{
    private readonly IEducationalProgramService _educationalProgramService;

    public EducationalProgramsController(IEducationalProgramService educationalProgramService)
    {
        _educationalProgramService = educationalProgramService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid facultyId)
    {
        var educationalPrograms = await _educationalProgramService.GetAllEducationalProgramsAsync(facultyId);

        return Ok(educationalPrograms);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(EducationalProgramsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var educationalProgram = await _educationalProgramService.GetEducationalProgramByIdAsync(id);

        return Ok(educationalProgram);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid facultyId, [FromBody, Required] EducationalProgramDto educationalProgramDto)
    {
        await _educationalProgramService.AddEducationalProgramAsync(facultyId, educationalProgramDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] EducationalProgramDto educationalProgramDto)
    {
        await _educationalProgramService.UpdateEducationalProgramAsync(id, educationalProgramDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _educationalProgramService.DeleteEducationalProgramAsync(id);

        return NoContent();
    }
}