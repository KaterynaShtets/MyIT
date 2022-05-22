using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.DataTransferObjects.Enums;

namespace MyIT.BusinessLogic.Helpers;

public static class DrawAPersonTestHelper
{
    private static readonly IDictionary<DrawAPersonInterpretationResult, int[]> DrawAPersonResults = new Dictionary<DrawAPersonInterpretationResult, int[]>
    {
        {   new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.Supervisor,
                JobPositions = new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager}
            },
            new[] { 910, 811, 820,  712, 721, 730, 613, 622, 631, 640 }
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.ResponsibleExecutor,
                JobPositions = new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer}
            },
            new[] { 505, 514, 523, 532, 541, 550 }
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.AnxiousAndSuspicious,
                JobPositions = new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR}
            },
            new[] { 406, 415, 424, 433, 442, 451, 460 }
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.Scientist,
                JobPositions = new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect}
            },
            new[] { 316, 325, 334, 343, 352, 361, 370 }
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.Intuitive,
                JobPositions = new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager}
            },
            new[] { 208, 217, 226, 235, 244, 271, 280 }
        },
        { 
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.InventorAndDesignerAndArtist,
                JobPositions = new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst}
            },
            new[] { 118, 127, 136, 145, 019, 028, 037, 046 }
            
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.Emotive,
                JobPositions = new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR}
            },
            new[] { 253, 262, 154, 163, 172, 181, 190, 055, 064, 073, 082, 091 }
        },
        {
            new DrawAPersonInterpretationResult
            {
                PersonType = PersonType.NonEmotive,
                JobPositions = new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager}
            },
            new[] { 901, 802, 703, 604, 307,  109 }
        }
    };

    public static DrawAPersonInterpretationResult GetDrawAPersonTestResult(int resultNumber)
    {
        return DrawAPersonResults.First(x => x.Value.Contains(resultNumber)).Key;
    }
    
    public static JobPosition GetITSpecialityTestResult(PersonType personType, int jobPositionIndex)
    {
        return DrawAPersonResults.First(x => x.Key.PersonType == personType).Key.JobPositions!.ElementAt(jobPositionIndex);
    }
}