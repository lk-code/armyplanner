using armyplanner.Core.Interfaces;
using armyplanner.Core.Services.Config;
using armyplanner.Services.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace armyplanner.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            // core-services
            services.AddSingleton<IConfigService, ConfigService>();

            // platform-services
            services.AddSingleton<ILoggingService, LoggingService>();

            // viewmodels
            //services.AddTransient<AppShellViewModel>();

            return services;
        }
    }
}
