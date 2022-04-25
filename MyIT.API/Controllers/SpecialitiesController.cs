using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/specialities")]
public class SpecialitiesController : Controller
{
    private readonly ISpecialityService _specialityService;

    public SpecialitiesController(ISpecialityService specialityService)
    {
        _specialityService = specialityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var universities = await _specialityService.GetAllSpecialityAsync();

        return Ok(universities);
    }
    
    [HttpGet("{psychologistId:Guid}", Name = nameof(SpecialitiesController) + nameof(GetAllPsychologistSpecialities))]
    public async Task<IActionResult> GetAllPsychologistSpecialities(Guid psychologistId)
    {
        var psychologistSpecialities = await _specialityService.GetAllPsychologistSpecialities(psychologistId);

        return Ok(psychologistSpecialities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody, Required] SpecialityDto specialityDto)
    {
        await _specialityService.AddSpecialityAsync(specialityDto);

        return Ok();
    }
    
    [HttpPost("{psychologistId:Guid}", Name = nameof(SpecialitiesController) + nameof(GetAllPsychologistSpecialities))]
    public async Task<IActionResult> AddPsychologistSpecialityAsync(Guid psychologistId,  [FromBody, Required] SpecialityDto specialityDto)
    {
        await _specialityService.AddPsychologistSpecialityAsync(psychologistId, specialityDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] SpecialityDto specialityDto)
    {
        await _specialityService.UpdateSpecialityAsync(id, specialityDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _specialityService.DeleteSpecialityAsync(id);

        return NoContent();
    }
}