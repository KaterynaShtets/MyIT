namespace MyIT.Contracts;

public class SessionComments : BaseContract
{
    public string? Comment { get; set; }
    
    public Guid SessionId { get; set; }
    
    public Session Session { get; set; }
}