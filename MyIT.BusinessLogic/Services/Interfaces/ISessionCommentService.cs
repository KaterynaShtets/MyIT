using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface ISessionCommentService
{
    Task<IEnumerable<SessionCommentDto>> GetAllSessionCommentsAsync(Guid sessionId);
    Task<SessionCommentDto> GetSessionCommentByIdAsync(Guid sessionCommentId);
    Task AddSessionCommentAsync(Guid sessionId, SessionCommentDto sessionCommentDto);
    Task UpdateGroupAsync(Guid id, SessionCommentDto sessionCommentDto);
    Task DeleteSessionCommentAsync(Guid sessionCommentId);
}