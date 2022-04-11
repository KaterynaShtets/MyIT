using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface IGroupService
{
    Task<IEnumerable<GroupDto>> GetAllGroupsAsync(Guid educationalProgramId);
    Task<GroupDto> GetGroupByIdAsync(Guid groupId);
    Task AddGroupAsync(Guid educationalProgramId, GroupDto groupDto);
    Task UpdateGroupAsync(Guid id, GroupDto groupDto);
    Task DeleteGroupAsync(Guid groupId);
}