namespace MyIT.BusinessLogic.DataTransferObjects;

public class TestDto : BaseDto
{
    public string Name { get; set; }
    
    public bool IsShared { get; set; }
    
    public string? ContentJson { get; set; }
}