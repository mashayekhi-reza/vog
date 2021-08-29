using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
