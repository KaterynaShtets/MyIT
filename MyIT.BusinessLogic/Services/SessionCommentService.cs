using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class SessionCommentService : ISessionCommentService
{
    private readonly IRepository<SessionComment> _sessionCommentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SessionCommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _sessionCommentRepository = unitOfWork.GetRepository<SessionComment>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SessionCommentDto>> GetAllSessionCommentsAsync(Guid sessionId)
    {
        var sessionComments = await _sessionCommentRepository.GetAsync(x => x.SessionId == sessionId);
        return _mapper.Map<IEnumerable<SessionCommentDto>>(sessionComments);
    }

    public async Task<SessionCommentDto> GetSessionCommentByIdAsync(Guid sessionCommentId)
    {
        var sessionComment = await _sessionCommentRepository.GetAsync(sessionCommentId);
        return _mapper.Map<SessionCommentDto>(sessionComment);
    }

    public async Task AddSessionCommentAsync(Guid sessionId, SessionCommentDto sessionCommentDto)
    {
        var sessionComment = _mapper.Map<SessionComment>(sessionCommentDto);
        sessionComment.SessionId = sessionId;
        _sessionCommentRepository.Create(sessionComment);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateGroupAsync(Guid id, SessionCommentDto sessionCommentDto)
    {
        var sessionComment = await _sessionCommentRepository.GetAsync(id);
        var sessionCommentMapped = _mapper.Map(sessionCommentDto, sessionComment);
        sessionCommentMapped.Id = id;
        sessionCommentMapped.SessionId = sessionComment.SessionId;
        _sessionCommentRepository.Update(sessionCommentMapped);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteSessionCommentAsync(Guid sessionCommentId)
    {
        _sessionCommentRepository.Delete(sessionCommentId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<SessionCommentDto>> GetSessionCommentsForStudent(Guid studentId)
    {
        var comments = (await _sessionCommentRepository.GetAsync(
            filter: x => x.Session.StudentId == studentId,
            includeProperties: x => x.Include(sc => sc.Session.Psychologist))
            ).OrderBy(x => x.Session.Date);

        return _mapper.Map<IEnumerable<SessionCommentDto>>(comments);
    }
}