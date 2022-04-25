using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/psychologistSpecialties")]
public class PsychologistSpecialtiesController : Controller
{
    private readonly IPsychologistService _psychologistService;

    public PsychologistSpecialtiesController(IPsychologistService psychologistService)
    {
        _psychologistService = psychologistService;
    }
    
    [HttpGet("{specialityId:Guid}", Name = nameof(PsychologistSpecialtiesController) + nameof(GetAllPsychologistsBySpeciality))]
    public async Task<IActionResult> GetAllPsychologistsBySpeciality(Guid specialityId)
    {
        var psychologistsBySpeciality = await _psychologistService.GetAllPsychologistsBySpeciality(specialityId);

        return Ok(psychologistsBySpeciality);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPsychologistSpecialityAsync([FromQuery]Guid psychologistId,[FromQuery] Guid specialityId)
    {
        await _psychologistService.AddPsychologistSpecialityAsync(psychologistId, specialityId);

        return Ok();
    }
}