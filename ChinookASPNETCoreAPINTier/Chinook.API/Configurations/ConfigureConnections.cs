using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chinook.DataEFCore;
using Chinook.Domain.DbInfo;

namespace Chinook.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("ChinookDb") ??
                             "Server=.;Database=Chinook;Trusted_Connection=True;";
            services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));

            services.AddSingleton<IDbInfo>(new DbInfo(connection));

            return services;
        }
    }
}