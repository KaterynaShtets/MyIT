using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class EducationalProgram : BaseContract
{
    [Required]
    public string Name { get; set; } // Програмна інженерія
    
    [Required]
    public string Code { get; set; } // PZPI
    
    [Required]
    public int SpecialityNumber { get; set; } //121
    
    [Required]
    public string Degree { get; set; } //Bachelor
      
    public Guid FacultyId { get; set; }
    
    public Faculty Faculty { get; set; }
    
    public ICollection<Group> Groups { get; set; }
}