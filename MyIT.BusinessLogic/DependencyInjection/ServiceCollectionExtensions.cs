﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

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
            string secretName = "myint-main-db-secret";
            string region = "eu-west-1";
            string secret = "";
            
            string ak = Environment.GetEnvironmentVariable("ACCESS_KEY");
            string sk = Environment.GetEnvironmentVariable("SECRET_KEY");
            
            AWSCredentials creds = new BasicAWSCredentials(ak, sk);
            
            MemoryStream memoryStream = new MemoryStream();
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(creds, RegionEndpoint.GetBySystemName(region));
            GetSecretValueRequest request = new GetSecretValueRequest();
            request.SecretId = secretName;
            request.VersionStage = "AWSCURRENT";
            
            GetSecretValueResponse response = null;
            response = client.GetSecretValueAsync(request).Result;
            secret = response.SecretString;
            
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
            
            services.AddAutoMapper(typeof(ServiceCollectionExtensions));
        }
    }
}
