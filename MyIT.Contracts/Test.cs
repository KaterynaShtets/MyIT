using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Test : BaseContract
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public bool IsShared { get; set; }
    
    public string? ContentJson { get; set; }
    
    public Guid PsychologistId { get; set; }
    
    public Psychologist Psychologist { get; set; }
}