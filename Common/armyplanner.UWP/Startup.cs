using armyplanner.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace armyplanner.UWP
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider Init()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddApp()
                //.AddSingleton<IPlatformSecureAuthService, PlatformSecureAuthService>()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}