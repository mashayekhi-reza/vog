using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VogCodeChallenge.Domain.Repositories;
using VogCodeChallenge.Infrastructure.Repositories;

namespace VogCodeChallenge.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection RegisterInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VogDB");

            services.AddDbContext<VogDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
