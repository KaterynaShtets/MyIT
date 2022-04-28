namespace MyIT.BusinessLogic.DataTransferObjects;

public class CreateAndUpdateSessionDto : BaseDto
{
    public DateTime Date { get; set; }
    
    public bool IsHandled { get; set; }

    public string? Problem { get; set; }
}