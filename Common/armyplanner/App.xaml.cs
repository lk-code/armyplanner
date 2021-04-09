using armyplanner.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace armyplanner
{
    public partial class App : Application
    {
        #region # properties #

        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        #endregion

        #region # constructors #

        public App(IServiceProvider serviceProvider)
        {
            App.ServiceProvider = serviceProvider;

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDAyMzg1QDMxMzgyZTM0MmUzMFJyTjNzRnFQL3RnaGwwR3lzalU1T1Y0V2kwcVcyNUp0cjVkUk1IZzlabTQ9");

            InitializeComponent();

            VersionTracking.Track();

            this.LoadConfig();

            MainPage = new Views.MainPage();
        }

        #endregion

        #region # public methods #

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #endregion

        #region # private logic #

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void LoadConfig()
        {
            string appNamespace = typeof(App).Namespace;
            string settingsFile = "appsettings.json";
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            string resourceFileName = $"{appNamespace}.{settingsFile}";

            Stream stream = assembly.GetManifestResourceStream(resourceFileName);

            JObject jObject = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();

                jObject = JObject.Parse(json);
            }

            var d = App.ServiceProvider.GetService<IConfigService>();
            d.Initialize(jObject);
        }

        #endregion
    }
}
