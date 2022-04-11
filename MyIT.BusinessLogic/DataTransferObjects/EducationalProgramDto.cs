namespace MyIT.BusinessLogic.DataTransferObjects;

public class EducationalProgramDto
{
    public string Name { get; set; }  = string.Empty;// Програмна інженерія
    
    public string Code { get; set; } = string.Empty; // PZPI
    
    public int SpecialityNumber { get; set; } //121
    
    public string Degree { get; set; } = string.Empty;  //Bachelor
}