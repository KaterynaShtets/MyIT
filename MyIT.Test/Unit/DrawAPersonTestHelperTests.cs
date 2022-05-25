using FluentAssertions;
using MyIT.BusinessLogic.DataTransferObjects.Enums;
using MyIT.BusinessLogic.Helpers;
using Xunit;

namespace MyIT.Test.Unit;

public class DrawAPersonTestHelperTests
{
    [Theory]
    [InlineData(910, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(811, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(820, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(712, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(721, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(730, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(613, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(622, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(631, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(640, PersonType.Supervisor, new [] { JobPosition.SoftwareArchitect , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedSupervisor(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(505, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    [InlineData(514, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    [InlineData(523, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    [InlineData(532, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    [InlineData(541, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    [InlineData(550, PersonType.ResponsibleExecutor, new [] { JobPosition.Designer , JobPosition.Developer, JobPosition.QAEngineer})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedResponsibleExecutor(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(406, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(415, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(424, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(433, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(442, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(451, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    [InlineData(460, PersonType.AnxiousAndSuspicious, new [] { JobPosition.Designer , JobPosition.QAEngineer, JobPosition.HR})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedAnxiousAndSuspicious(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(316, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(325, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(334, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(343, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(352, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(361, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    [InlineData(370, PersonType.Scientist, new [] { JobPosition.DevOps , JobPosition.QAEngineer, JobPosition.SoftwareArchitect})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedScientist(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(208, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(217, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(226, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(235, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(244, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(271, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    [InlineData(280, PersonType.Intuitive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.ProjectManager})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedIntuitive(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(118, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(127, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(136, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(145, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(019, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(028, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(037, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    [InlineData(046, PersonType.InventorAndDesignerAndArtist, new [] { JobPosition.SoftwareArchitect , JobPosition.Designer, JobPosition.BusinessAnalyst})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedInventorAndDesignerAndArtist(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(253, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(262, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(154, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(163, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(172, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(181, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(190, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(055, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(064, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(073, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(082, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    [InlineData(091, PersonType.Emotive, new [] { JobPosition.Designer , JobPosition.BusinessAnalyst, JobPosition.HR})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedEmotive(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
    
    [Theory]
    [InlineData(901, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    [InlineData(802, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    [InlineData(703, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    [InlineData(604, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    [InlineData(307, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    [InlineData(109, PersonType.NonEmotive, new [] { JobPosition.Developer , JobPosition.QAEngineer, JobPosition.ProjectManager})]
    public void DrawAPersonTestHelper_DrawAPersonResults_SuccessfullyParsedNonEmotive(int number, PersonType type , JobPosition[] jobPositions )
    {
        // Arrange & Act
        var result = DrawAPersonTestHelper.GetDrawAPersonTestResult(number);
        // Assert
        Assert.Equal(type, result.PersonType);
        jobPositions.Should().Equal(result.JobPositions);
    }
}