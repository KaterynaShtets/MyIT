namespace MyIT.BusinessLogic.DataTransferObjects;

public class SessionDto : BaseDto
{
    public DateTime Date { get; set; }
    
    public bool IsHandled { get; set; }

    public string? Problem { get; set; }
    
    public IList<SessionCommentDto>? SessionComments { get; set; }
    
    public PsychologistDto Psychologist { get; set; }
}