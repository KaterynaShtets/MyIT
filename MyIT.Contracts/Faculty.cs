using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Faculty : BaseContract
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Info { get; set; } = string.Empty;

    public Guid UniversityId { get; set; }
    
    public University University { get; set; }
    
    public ICollection<EducationalProgram> EducationalPrograms { get; set; }
}