using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyIT.BusinessLogic.Services;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.DataAccess.DependencyInjection;

namespace MyIT.BusinessLogic.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicComponents(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddUnitOfWork(configuration.GetConnectionString("MyITDbConnectionString"));

            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IEducationalProgramService, EducationalProgramService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPsychologistService, PsychologistService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISessionCommentService, SessionCommentService>();
            services.AddScoped<ISpecialityService, SpecialtyService>();
            
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));
        }
    }
}
