namespace MyIT.BusinessLogic.DataTransferObjects;

public class PsychologistDto : BaseDto
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public DateTime DOB { get; set; }
}