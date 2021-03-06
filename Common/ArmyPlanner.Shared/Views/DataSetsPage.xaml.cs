using ArmyPlanner.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ArmyPlanner.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSetsPage : Page
    {
        private DataSetsViewModel ViewModel { get; set; } = null;

        public DataSetsPage()
        {
            this.InitializeComponent();

            this.DataContext = this.ViewModel = (DataSetsViewModel)App.ServiceProvider.GetService(typeof(DataSetsViewModel));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newSearchTextValue = (sender as TextBox).Text;

            this.ViewModel.SearchTextValueChangedCommand.Execute(newSearchTextValue);
        }

        private void GameFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
