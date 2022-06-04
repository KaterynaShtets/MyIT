using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

using MyIT.BusinessLogic.Services;
using MyIT.BusinessLogic.Services.Interfaces;
using MyIT.DataAccess.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace MyIT.BusinessLogic.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicComponents(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            string secretName = "arn:aws:secretsmanager:eu-west-1:768105649397:secret:myint-main-db-secret-i4u9KE";
            string region = "eu-west-1";
            string secret = "";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest();
            request.SecretId = secretName;
            request.VersionStage = "AWSCURRENT";

            GetSecretValueResponse response = null;
            response = client.GetSecretValueAsync(request).Result;
            secret = JObject.Parse(response.SecretString)["connection-string"]
                .ToString();

            services.AddUnitOfWork(secret);
            
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IEducationalProgramService, EducationalProgramService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPsychologistService, PsychologistService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISessionCommentService, SessionCommentService>();
            services.AddScoped<ISpecialityService, SpecialtyService>();
            services.AddScoped<ITestService, TestService>();
            
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));
        }
    }
}
