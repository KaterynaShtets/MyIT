using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class SessionComment : BaseContract
{
    [Required]
    public string Comment { get; set; }
    
    [Required]
    public bool IsPublic { get; set; }
    
    public Guid SessionId { get; set; }
    
    public Session Session { get; set; }
}