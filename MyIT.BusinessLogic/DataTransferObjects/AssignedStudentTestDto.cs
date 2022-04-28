namespace MyIT.BusinessLogic.DataTransferObjects;

public class AssignedStudentTestDto : BaseDto
{
    public DateTime Date { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public string? TestInterpretation { get; set; }
    
    public string? ResultJson { get; set; }
    
    public string? ResultInterpretationJson { get; set; }
}