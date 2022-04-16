using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class Student : BaseContract
{
    [Required]
    public string FullName { get; set; }
    
    public string? PhotoPath { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public DateTime DOB { get; set; }
    
    public Guid GroupId { get; set; }
    
    public Group Group { get; set; }
    
    public ICollection<Session> Sessions { get; set; }
    
    public ICollection<AssignedStudentTest> AssignedStudentTests { get; set; }

}