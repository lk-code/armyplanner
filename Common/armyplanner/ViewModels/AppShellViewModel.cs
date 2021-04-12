using armyplanner.Core.Interfaces;
using armyplanner.EventArgs;
using armyplanner.Views.App;
using armyplanner.Views.Planner;
using System;
using Xamarin.Forms;

namespace armyplanner.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        #region Private Eigenschaften

        private readonly IConfigService _configService;

        #endregion

        #region Properties

        TabbedPage _tabbedPage = null;

        /// <summary>
        /// 
        /// </summary>
        public TabbedPage TabbedPage
        {
            get { return _tabbedPage; }
            set { SetProperty(ref _tabbedPage, value); }
        }

        #endregion

        #region Commands

        #endregion

        #region Konstruktoren

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configService"></param>
        public AppShellViewModel(IConfigService configService)
        {
            this._configService = configService ?? throw new ArgumentNullException(nameof(configService));
        }

        #endregion

        #region Workers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        protected override void OnExecuteInitCommand(InitEventArgs eventArgs)
        {
            base.OnExecuteInitCommand(eventArgs);

            if (this.TabbedPage == null)
            {
                this.TabbedPage = new TabbedPage();
            }

            this.AddArmyPage();
            this.AddSettingsPage();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddArmyPage()
        {
            this.AddPage<OverviewPage>("Armee-Planer", "tab_overview.png");
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddSettingsPage()
        {
            this.AddPage<SettingsPage>("Einstellungen", "tab_settings.png");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="useLargeTitles"></param>
        private void AddPage<T>(string title, string icon, bool useLargeTitles = true)
        {
            Page page = (Activator.CreateInstance(typeof(T)) as Page);

            if (page == null)
            {
                return;
            }

            NavigationPage navigationPage = new NavigationPage(page);
            navigationPage.Title = title;
            navigationPage.IconImageSource = icon;

            if (useLargeTitles == true)
            {
                Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(navigationPage, true);
            }

            this.TabbedPage.Children.Add(navigationPage);
        }

        #endregion
    }
}