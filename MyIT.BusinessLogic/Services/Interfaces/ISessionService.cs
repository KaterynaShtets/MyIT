﻿using MyIT.BusinessLogic.DataTransferObjects;

namespace MyIT.BusinessLogic.Services.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<SessionDto>> GetAllPsychologistAndStudentSessionsAsync(Guid studentId, Guid psychologistId);
    Task<SessionDto> GetSessionByIdAsync(Guid sessionId);
    Task AddSessionAsync(Guid studentId, Guid psychologistId, CreateAndUpdateSessionDto sessionDto);
    Task UpdateSessionAsync(Guid id, CreateAndUpdateSessionDto sessionDto);
    Task DeleteSessionIdAsync(Guid sessionId);
}