using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyIT.DataAccess.Interfaces;
using MyIT.DataAccess.Utils;

namespace MyIT.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyITDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, MyITDbContext>(provider => provider.GetService<MyITDbContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}