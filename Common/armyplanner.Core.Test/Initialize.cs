using armyplanner.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace armyplanner.Core.Test
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Debug.WriteLine("Assembly Initialize");

            Startup.Init();

            // ConfigService
            IConfigService configService = Startup.ServiceProvider.GetService<IConfigService>();
            string configJson = @"{
                             ""Storage"": {
                                       ""Server"": ""https://armyplaner.blob.core.windows.net""
                             }
            }";
            configService.Initialize(JObject.Parse(configJson));

            Debug.WriteLine("Assembly Initialized");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Debug.WriteLine("Assembly Cleanup");

            Debug.WriteLine("Assembly Cleanup finished");
        }
    }
}
