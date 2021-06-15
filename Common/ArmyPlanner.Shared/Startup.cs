using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Services.Logging;
using ArmyPlanner.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ArmyPlanner
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            ServiceProvider serviceProvider = new ServiceCollection()

            // core-services
            // .AddSingleton<IConfigService, ConfigService>()

            // platform-services
            .AddSingleton<ILoggingService, LoggingService>()

            // viewmodels
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>()

            .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}