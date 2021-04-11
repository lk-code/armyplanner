using armyplanner.Core.Test.Environment.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace armyplanner.Core.Test
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
                .AddAppCoreTest()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}