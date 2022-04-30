using AutoMapper;
using MyIT.BusinessLogic.DataTransferObjects;
using MyIT.Contracts;

namespace MyIT.BusinessLogic.AutoMapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
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
        
        CreateMap<SessionDto, Session>()
            .ReverseMap();
        
        CreateMap<CreateAndUpdateSessionDto, Session>()
            .ReverseMap();
        
        CreateMap<SessionCommentDto, SessionComment>()
            .ReverseMap();
        
        CreateMap<SpecialityDto, Speciality>()
            .ReverseMap();
        
        CreateMap<TestDto, Test>()
            .ReverseMap();

        CreateMap<AssignedStudentTestDto, AssignedStudentTest>()
            .ReverseMap();
    }
}