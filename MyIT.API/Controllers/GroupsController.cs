using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;

namespace MyIT.API.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupsController  : Controller
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid educationalProgramId)
    {
        var groups = await _groupService.GetAllGroupsAsync(educationalProgramId);

        return Ok(groups);
    }
    
    [HttpGet("{id:Guid}", Name = nameof(GroupsController) + nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var group = await _groupService.GetGroupByIdAsync(id);

        return Ok(group);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] Guid educationalProgramId, [FromBody, Required] GroupDto groupDto)
    {
        await _groupService.AddGroupAsync(educationalProgramId, groupDto);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody, Required] GroupDto groupDto)
    {
        await _groupService.UpdateGroupAsync(id, groupDto);

        return Ok();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _groupService.DeleteGroupAsync(id);

        return NoContent();
    }
}