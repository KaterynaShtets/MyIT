using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Psychologist : BaseContract
{
    [Required]
    public string FullName { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public string? DiplomPath { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public DateTime DOB { get; set; }
    
    public ICollection<Test> Tests { get; set; }

    public ICollection<Session> Sessions { get; set; }
    
    public ICollection<PsychologistSpeciality> PsychologistSpecialities { get; set; }
}