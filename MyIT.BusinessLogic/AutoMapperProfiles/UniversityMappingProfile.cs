using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.Contracts;

namespace MyIT.BusinessLogic.AutoMapperProfiles;

public class UniversityMappingProfile : Profile
{
    public UniversityMappingProfile()
    {
        CreateMap<UniversityDto, University>()
            .ReverseMap();
        
        CreateMap<FacultyDto, Faculty>()
            .ReverseMap();
        
        CreateMap<EducationalProgramDto, EducationalProgram>()
            .ReverseMap();
        
        CreateMap<GroupDto, Group>()
            .ReverseMap();
        
        CreateMap<PsychologistDto, Psychologist>()
            .ReverseMap();
        
        CreateMap<StudentDto, Student>()
            .ReverseMap();
    }
}