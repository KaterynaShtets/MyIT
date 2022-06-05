namespace MyIT.BusinessLogic.DataTransferObjects;

public class GroupDto : BaseDto
{
    public int Number { get; set; } // 1 

    public int Year { get; set; } // 2018

    public EducationalProgramDto EducationalProgram { get; set; } // PZPI
}