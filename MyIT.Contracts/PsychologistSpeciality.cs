namespace MyIT.Contracts;
 
public class PsychologistSpeciality : BaseContract
{
    public Psychologist Psychologist { get; set; }
    
    public Guid PsychologistId { get; set; }
    public Speciality Speciality { get; set; }
    
    public Guid SpecialityId { get; set; }
}