namespace MyIT.Contracts;

public class ChangeUserPasswordModel
{
    public string Username { get; set; }
    
    public string Password { get; set; }

    public string NewPassword { get; set; }
}