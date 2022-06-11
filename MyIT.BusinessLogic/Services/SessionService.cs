using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;

namespace MyIT.BusinessLogic.Services;

public class SessionService: ISessionService
{
    private readonly IRepository<Session> _sessionRepository;
    private readonly IRepository<SessionComment> _sessionCommentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _sessionRepository = unitOfWork.GetRepository<Session>();
        _sessionCommentRepository = unitOfWork.GetRepository<SessionComment>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SessionDto>> GetAllPsychologistAndStudentSessionsAsync(Guid studentId, Guid psychologistId)
    {
        // todo on role select all comments for psuchologist and only public for student
        var sessions =  await _sessionRepository.GetAsync(x=>
            x.StudentId == studentId && x.PsychologistId == psychologistId,
            includeProperties: x=>x.Include(s => s.SessionComments));
        
        return _mapper.Map<IEnumerable<SessionDto>>(sessions);
    }

    public async Task<IEnumerable<SessionDto>> GetAllStudentSessionsAsync(Guid studentId)
    {
        var sessions = (await _sessionRepository.GetAsync(
            filter: x => x.StudentId == studentId,
            includeProperties: x => x.Include(s => s.Psychologist)))
            .OrderBy(x => (x.IsHandled, x.Date));

        return _mapper.Map<IEnumerable<SessionDto>>(sessions);
    }

    public async Task<SessionDto> GetSessionByIdAsync(Guid sessionId)
    {
        // todo on role select all comments for psuchologist and only public for student
        var group = await _sessionRepository.GetAsync(sessionId,
            includeProperties: x=>x.Include(s => s.SessionComments));
        return _mapper.Map<SessionDto>(group);
    }
    
    public async Task AddSessionAsync(Guid studentId, Guid psychologistId, CreateAndUpdateSessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);
        session.StudentId = studentId;
        session.PsychologistId = psychologistId;
        _sessionRepository.Create(session);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task HandleSessionAsync(Guid sessionId)
    {
        var session = await _sessionRepository.GetAsync(sessionId);
        session.IsHandled = true;
        _sessionRepository.Update(session);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task UpdateSessionAsync(Guid id, CreateAndUpdateSessionDto sessionDto)
    {
        var session = await _sessionRepository.GetAsync(id);
        var sessionMapped = _mapper.Map(sessionDto, session);
        sessionMapped.Id = id;
        sessionMapped.PsychologistId = session.PsychologistId;
        sessionMapped.StudentId = session.StudentId;
        _sessionRepository.Update(sessionMapped);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteSessionIdAsync(Guid sessionId)
    {
        _sessionRepository.Delete(sessionId);
        await _unitOfWork.SaveChangesAsync();
    }
}