using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/sessionComments")]
public class SessionCommentsController: Controller
{
    private readonly ISessionCommentService _sessionCommentService;

    public SessionCommentsController(ISessionCommentService sessionCommentService)
    {
        _sessionCommentService = sessionCommentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid sessionId)
    {
        var sessionComments = await _sessionCommentService.GetAllSessionCommentsAsync(sessionId);

        return Ok(sessionComments);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(SessionCommentsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var sessionComment = await _sessionCommentService.GetSessionCommentByIdAsync(id);

        return Ok(sessionComment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid sessionId, [FromBody, Required] SessionCommentDto sessionCommentDto)
    {
        await _sessionCommentService.AddSessionCommentAsync(sessionId, sessionCommentDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] SessionCommentDto sessionCommentDto)
    {
        await _sessionCommentService.UpdateGroupAsync(id, sessionCommentDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _sessionCommentService.DeleteSessionCommentAsync(id);

        return NoContent();
    }

    [HttpGet("getSessionCommentsForStudent")]
    public async Task<IActionResult> GetForStudent([FromQuery] Guid studentId)
    {
        var comments = await _sessionCommentService.GetSessionCommentsForStudent(studentId);

        return Ok(comments);
    }
}