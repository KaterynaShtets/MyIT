using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Speciality  : BaseContract
{
    [Required]
    public string Name { get; set; }
    
    public ICollection<PsychologistSpeciality> PsychologistSpecialities { get; set; }
}