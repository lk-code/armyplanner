using armyplanner.Core.Interfaces;
using armyplanner.Core.Services.Config;
using armyplanner.Core.Services.Storage;
using armyplanner.Services.Logging;
using armyplanner.Services.Network;
using armyplanner.Services.Preferences;
using armyplanner.ViewModels;
using armyplanner.ViewModels.App;
using armyplanner.ViewModels.Planner;
using Microsoft.Extensions.DependencyInjection;

namespace armyplanner.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            // core-services
            services.AddSingleton<IConfigService, ConfigService>();
            services.AddSingleton<IStorageService, StorageService>();

            // platform-services
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<INetworkService, NetworkService>();
            services.AddSingleton<IPreferencesServices, PreferencesServices>();

            // viewmodels
            services.AddTransient<AppShellViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<OverviewViewModel>();

            return services;
        }
    }
}
