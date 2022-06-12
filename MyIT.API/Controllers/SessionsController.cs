using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/sessions")]
public class SessionsController : Controller
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid studentId, [FromQuery] Guid psychologistId)
    {
        var sessions = await _sessionService.GetAllPsychologistAndStudentSessionsAsync(studentId, psychologistId);

        return Ok(sessions);
    }

    [HttpGet("{id:Guid}", Name = nameof(SessionsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var session = await _sessionService.GetSessionByIdAsync(id);

        return Ok(session);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid studentId, [FromQuery] Guid psychologistId, [FromBody, Required] CreateAndUpdateSessionDto sessionDto)
    {
        await _sessionService.AddSessionAsync(studentId, psychologistId, sessionDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] CreateAndUpdateSessionDto sessionDto)
    {
        await _sessionService.UpdateSessionAsync(id, sessionDto);

        return Ok();
    }
    
    [HttpPut("handle/{id}")]
    public async Task<IActionResult> HandleAsync(Guid id)
    {
        await _sessionService.HandleSessionAsync(id);

        return Ok();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _sessionService.DeleteSessionIdAsync(id);

        return NoContent();
    }

    [HttpGet("getSessionsForStudent")]
    public async Task<IActionResult> GetSessionsForStudent([FromQuery] Guid studentId)
    {
        var sessions = await _sessionService.GetAllStudentSessionsAsync(studentId);

        return Ok(sessions);
    }

    [HttpGet("getSessionsForPsychologist")]
    public async Task<IActionResult> GetSessionsForPsychologist([FromQuery] Guid psychologistId)
    {
        var sessions = await _sessionService.GetAllPsychologistSessionsAsync(psychologistId);

        return Ok(sessions);
    }
}