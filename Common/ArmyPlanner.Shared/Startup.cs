using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.Services.DataSet;
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

            // services
            .AddSingleton<ILoggingService, LoggingService>()
            .AddSingleton<IDataSetService, DataSetService>()

            // viewmodels
            .AddTransient<MainViewModel>()
            .AddTransient<SettingsViewModel>()
            .AddTransient<DataSetsViewModel>()

            .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}