using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using MyIT.BusinessLogic.DataTransferObjects.Validators;
using MyIT.BusinessLogic.DependencyInjection;

namespace MyIT.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusinessLogicComponents(Configuration);
            
            services.AddCors(options => options.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddControllers();
            services.AddFluentValidation(x =>
            {
                //x.DisableDataAnnotationsValidation = true;
                x.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
                x.RegisterValidatorsFromAssemblyContaining<PsychologistValidator>();
                x.RegisterValidatorsFromAssemblyContaining<UniversityValidator>();
            });
            // services.Configure<BlobStorageOptions>(Configuration.GetSection("BlobStorageOptions"));
            // services.Configure<ClassifyEmotionsOptions>(Configuration.GetSection("ClassifyEmotionsOptions"));
            //
            // services.AddBusinessLogicComponents(Configuration);
            //
            // services.AddHttpClient<ClassifyEmotionsClient>();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyIT API V1",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MentalHealth API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
