using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Session : BaseContract
{
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public bool IsHandled { get; set; }

    public string? Problem { get; set; }
    
    public Guid StudentId { get; set; }
    
    public Guid PsychologistId { get; set; }
    
    public Student Student { get; set; }
    
    public Psychologist Psychologist { get; set; }
    
    public ICollection<SessionComments> SessionComments { get; set; }
}