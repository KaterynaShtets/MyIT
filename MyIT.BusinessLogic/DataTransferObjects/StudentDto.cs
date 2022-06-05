namespace MyIT.BusinessLogic.DataTransferObjects;

public class StudentDto : BaseDto
{
    public string FullName { get; set; }

    public string Email { get; set; }
    
    public DateTime DOB { get; set; }

    public GroupDto Group { get; set; }
}