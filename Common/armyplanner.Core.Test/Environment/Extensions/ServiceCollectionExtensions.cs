using armyplanner.Core.Interfaces;
using armyplanner.Core.Services.Config;
using armyplanner.Core.Services.Storage;
using armyplanner.Core.Test.Environment.Services.Logging;
using armyplanner.Core.Test.Environment.Services.Network;
using Microsoft.Extensions.DependencyInjection;

namespace armyplanner.Core.Test.Environment.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppCoreTest(this IServiceCollection services)
        {
            // core-services
            services.AddSingleton<IConfigService, ConfigService>();
            services.AddSingleton<IStorageService, StorageService>();

            // test-services
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<INetworkService, NetworkService>();

            return services;
        }
    }
}
