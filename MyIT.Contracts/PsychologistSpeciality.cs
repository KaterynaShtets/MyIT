namespace MyIT.Contracts;
 
public class PsychologistSpeciality : BaseContract
{
    public Psychologist Psychologist { get; set; }
    
    public Speciality Speciality { get; set; }
}