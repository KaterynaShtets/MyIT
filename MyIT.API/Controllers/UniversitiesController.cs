using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/universities")]
public class UniversitiesController : Controller
{
    private readonly IUniversityService _universityService;

    public UniversitiesController(IUniversityService universityService)
    {
        _universityService = universityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var universities = await _universityService.GetAllUniversityAsync();

        return Ok(universities);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(UniversitiesController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var university = await _universityService.GetUniversityByIdAsync(id);

        return Ok(university);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody, Required] UniversityDto university)
    {
        await _universityService.AddUniversityAsync(university);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] UniversityDto university)
    {
        await _universityService.UpdateUniversityAsync(id, university);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _universityService.DeleteUniversityAsync(id);

        return NoContent();
    }
}