using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chinook.Data;

namespace Chinook.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("ChinookDb");
            services.AddDbContext<ChinookContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
