using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/psychologists")]
public class PsychologistsController : Controller
{
    private readonly IPsychologistService _psychologistService;

    public PsychologistsController(IPsychologistService psychologistService)
    {
        _psychologistService = psychologistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var psychologists = await _psychologistService.GetAllPsychologistAsync();

        return Ok(psychologists);
    }

    [HttpGet("{id:Guid}", Name = nameof(PsychologistsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var psychologist = await _psychologistService.GetPsychologistByIdAsync(id);

        return Ok(psychologist);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody, Required] PsychologistDto psychologistDto)
    {
        await _psychologistService.AddPsychologistAsync(psychologistDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] PsychologistDto psychologistDto)
    {
        await _psychologistService.UpdatePsychologistAsync(id, psychologistDto);

        return Ok();
    }
    
    [HttpPut("verify/{id}")]
    public async Task<IActionResult> VerifyAsync(Guid id)
    {
        await _psychologistService.VerifyPsychologistAsync(id);

        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _psychologistService.DeletePsychologistAsync(id);

        return NoContent();
    }
}