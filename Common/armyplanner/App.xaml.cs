using System.Reflection;
using armyplanner.Core.Interfaces;
using armyplanner.Core.Services.AppCenter;
using armyplanner.Core.Services.Config;
using armyplanner.Core.Services.Logging;
using armyplanner.Views;
using Xamarin.Forms;

namespace armyplanner
{
    public partial class App : Application
    {
        #region # constructors #

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDAyMzg1QDMxMzgyZTM0MmUzMFJyTjNzRnFQL3RnaGwwR3lzalU1T1Y0V2kwcVcyNUp0cjVkUk1IZzlabTQ9");

            InitializeComponent();

            this.LoadDependencyInjection();

            MainPage = new MainPage();
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
        private void LoadDependencyInjection()
        {
            // ConfigService
            DependencyService.Register<IConfigService, ConfigService>();
            DependencyService.Get<IConfigService>().Initialize(typeof(App).Namespace, "appsettings.json", IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly);

            // AppCenterService
            DependencyService.Register<IAppCenterService, AppCenterService>();
            (DependencyService.Get<IAppCenterService>() as IInitialized).Initialize();

            // LoggingService
            DependencyService.Register<ILoggingService, LoggingService>();
        }

        #endregion
    }
}
