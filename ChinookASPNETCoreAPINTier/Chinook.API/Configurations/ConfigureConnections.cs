using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chinook.DataEFCoreCmpldQry;

namespace Chinook.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = String.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("ChinookDbWindows") ??
                                 "Server=.;Database=Chinook;Trusted_Connection=True;Application Name=ChinookASPNETCoreAPINTier";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                connection = configuration.GetConnectionString("ChinookDbDocker") ??
                                 "Server=localhost,1433;Database=Chinook;User=sa;Password=Pa55w0rd;Trusted_Connection=False;Application Name=ChinookASPNETCoreAPINTier";
            }
            
            services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}