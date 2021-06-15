using ArmyPlanner.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ArmyPlanner.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel { get; set; } = null;

        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = this.ViewModel = (MainViewModel)App.ServiceProvider.GetService(typeof(MainViewModel));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel.Initialize(this.MainContentFrame);
            // this.ViewModel.Title = "Hello Lars";

#if NETFX_CORE
            // only at uwp
            this.InitializeAppWindow();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeAppWindow()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            // titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.Transparent;
            // titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.InactiveBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;


            //coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(this.AppTitleBar);
        }
    }
}
