using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/sessions")]
public class SessionsController : Controller
{
    private readonly ISessionService _studentService;

    public SessionsController(ISessionService sessionService)
    {
        _studentService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid studentId, [FromQuery] Guid psychologistId)
    {
        var sessions = await _studentService.GetAllPsychologistAndStudentSessionsAsync(studentId, psychologistId);

        return Ok(sessions);
    }

    [HttpGet("{id:Guid}", Name = nameof(SessionsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var session = await _studentService.GetSessionByIdAsync(id);

        return Ok(session);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid studentId, [FromQuery] Guid psychologistId, [FromBody, Required] CreateAndUpdateSessionDto sessionDto)
    {
        await _studentService.AddSessionAsync(studentId, psychologistId, sessionDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] CreateAndUpdateSessionDto sessionDto)
    {
        await _studentService.UpdateSessionAsync(id, sessionDto);

        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _studentService.DeleteSessionIdAsync(id);

        return NoContent();
    }
}