using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.JSII.JsonModel.Spec;
using FluentAssertions;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.DataTransferObjects.Enums;
using MyIT.BusinessLogic.Helpers;
using Newtonsoft.Json;
using Xunit;

namespace MyIT.Test.Integration;

public class DrawAPersonTestTests
{
    [Fact]
    public void DrawAPersonTestAndItSpecialityTest_CalculateResult_Successfully()
    {
        // Arrange
        var personType = PersonType.Scientist;
        var personProffession = "SoftwareArchitect";
        var positions = new[] { JobPosition.DevOps, JobPosition.QAEngineer, JobPosition.SoftwareArchitect };
        var jsonFirst = "{'triangle':3,'square':4,'circle':3}";
        var jsonSecond = "{'a':3,'b':4,'c':15}";
        
        // Act
        var firstTestResult = FirstTestResultAsync(jsonFirst);
        
        // Assert 
        var personTypeResult = JsonConvert.DeserializeObject<DrawAPersonInterpretationResult>(firstTestResult)!.PersonType;
        var jobPositionsResult  = JsonConvert.DeserializeObject<DrawAPersonInterpretationResult>(firstTestResult)!.JobPositions;
        Assert.Equal(personType, personTypeResult);
        positions.Should().Equal(jobPositionsResult);
        
        // Act 
        var secondTestResult = SecondTestResultAsync(jsonSecond, firstTestResult);
        
        // Assert
        Assert.Equal(personProffession, secondTestResult);
    }
    
    
    private string FirstTestResultAsync(string resultJson)
    {
        var drawAPersonTestResult = JsonConvert.DeserializeObject<DrawAPersonTestResult>(resultJson);
        var resultNumber = drawAPersonTestResult!.Triangle * 100 + drawAPersonTestResult.Circle * 10 + drawAPersonTestResult.Square;
       return JsonConvert.SerializeObject(DrawAPersonTestHelper.GetDrawAPersonTestResult(resultNumber));
    }

    private string SecondTestResultAsync(string resultJson, string drawAPersonTestResult)
    {
        var itSpecialtyTestResult = JsonConvert.DeserializeObject<ITSpecialtyTestResult>(resultJson);
        var personType = JsonConvert.DeserializeObject<DrawAPersonInterpretationResult>(drawAPersonTestResult!)!.PersonType;
        var itSpecialtyIndex = GetItSpecialtyIndex(itSpecialtyTestResult!);
        
        return DrawAPersonTestHelper.GetITSpecialityTestResult(personType, itSpecialtyIndex).ToString();
    }
    
    private static int GetItSpecialtyIndex(ITSpecialtyTestResult itSpecialtyTestResult)
    {
        var results = new List<int> { itSpecialtyTestResult!.A, itSpecialtyTestResult.B, itSpecialtyTestResult.C };
        return results.IndexOf(results.Max());
    }
}