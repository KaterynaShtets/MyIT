using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/faculties")]
public class FacultiesController  : Controller
{
    private readonly IFacultyService _facultyService;

    public FacultiesController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid universityId)
    {
        var faculties = await _facultyService.GetAllFacultiesAsync(universityId);

        return Ok(faculties);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(FacultiesController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var faculty = await _facultyService.GetFacultyByIdAsync(id);

        return Ok(faculty);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid universityId, [FromBody, Required] FacultyDto facultyDto)
    {
        await _facultyService.AddFacultyAsync(universityId, facultyDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] FacultyDto facultyDto)
    {
        await _facultyService.UpdateFacultyAsync(id, facultyDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _facultyService.DeleteFacultyAsync(id);

        return NoContent();
    }
}