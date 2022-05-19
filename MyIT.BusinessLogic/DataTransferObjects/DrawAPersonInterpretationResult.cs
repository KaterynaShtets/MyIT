using MyIT.BusinessLogic.DataTransferObjects.Enums;

namespace MyIT.BusinessLogic.DataTransferObjects;

public class DrawAPersonInterpretationResult
{
    public PersonType PersonType { get; set; }
    
    public IEnumerable<JobPosition>? JobPositions { get; set; }
}