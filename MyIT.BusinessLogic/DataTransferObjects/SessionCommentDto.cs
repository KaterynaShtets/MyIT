namespace MyIT.BusinessLogic.DataTransferObjects;

public class SessionCommentDto : BaseDto
{
    public string Comment { get; set; }

    public bool IsPublic { get; set; }

    public SessionDto Session { get; set; }
}