using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class AssignedStudentTest : BaseContract
{
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public bool IsCompleted { get; set; }
    
    [Required]
    public string TestInterpretation { get; set; }
    
    [Required]
    public string ResultPath { get; set; }
    
    public Guid StudentId { get; set; }
    
    public Guid TestId { get; set; }
    
    public Student Student { get; set; }
    
    public Test Test { get; set; }
}