using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using MyIT.BusinessLogic.AutoMapperProfiles;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.BusinessLogic.Services;
using MyIT.Contracts;
using MyIT.DataAccess.Interfaces;
using MyIT.Test.Helpers;
using Xunit;

namespace MyIT.Test.Unit;

public class EntitiesTest
{
    [Fact]
    public async Task GetAllUniversityAsync_SuccessfullyReturnAllUniversities()
    {
      // Arrange
      var universities = new List<University>();
      universities.Add(new University
      {
          City = "Kharkiv",
          Country = "Ukraine",
          EmailDomain = "@nure.ua",
          Faculties = new List<Faculty>(),
          Name = "Nure",
          SiteUrl = "Url"
      });
      var mockDataAccess = new Mock<IRepository<University>>();
      var mockUnitOfWork = new Mock<IUnitOfWork>();
      mockDataAccess.Setup(m => m.GetAllAsync(null))
          .ReturnsAsync(universities);
      mockUnitOfWork.Setup(m => m.GetRepository<University>())
          .Returns(mockDataAccess.Object);
      var productBusiness = new UniversityService(mockUnitOfWork.Object, MapperFactory.GetMapper());
      
      // Act
      var result = await productBusiness.GetAllUniversityAsync();
      
      // Assert
      var universitieDtos = new List<UniversityDto>
      {
          new UniversityDto
          {
              City = "Kharkiv",
              Country = "Ukraine",
              EmailDomain = "@nure.ua",
              Name = "Nure",
              SiteUrl = "Url"
          }
      };
      result.First().Should().BeEquivalentTo(universitieDtos.First());
    }
}