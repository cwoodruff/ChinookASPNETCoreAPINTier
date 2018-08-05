using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.API.Configurations
{
    public static class ConfigureAppSettings
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(_ => configuration.GetSection("AppSettings").Bind(_));

            return services;
        }
    }
}