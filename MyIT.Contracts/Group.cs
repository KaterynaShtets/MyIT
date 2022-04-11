using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Group : BaseContract
{
    [Required]
    public int Number { get; set; } // 1 
    
    [Required]
    public int Year { get; set; } // 2018
    
    public Guid EducationalProgramId { get; set; }
    
    public EducationalProgram EducationalProgram { get; set; }
    
    public ICollection<Student> Students { get; set; }
}