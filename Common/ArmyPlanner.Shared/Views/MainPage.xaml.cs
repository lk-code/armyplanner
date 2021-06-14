using ArmyPlanner.ViewModels;
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
        /// <summary>
        /// 
        /// </summary>
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
            // this.ViewModel.Title = "Hello Lars";
        }
    }
}
