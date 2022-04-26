using System.ComponentModel.DataAnnotations;

namespace MyIT.Contracts;

public class AssignedStudentTest : BaseContract
{
    public DateTime Date { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public string? TestInterpretation { get; set; }
    
    public string? ResultJson { get; set; }
    
    public string? ResultInterpretationJson { get; set; }
    
    public Guid StudentId { get; set; }
    
    public Guid TestId { get; set; }
    
    public Student Student { get; set; }
    
    public Test Test { get; set; }
}