using armyplanner.EventArgs;
using armyplanner.ViewModels.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace armyplanner.Views.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        SettingsViewModel ViewModel;

        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = this.ViewModel = armyplanner.App.ServiceProvider.GetService<SettingsViewModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.ViewModel.InitCommand.Execute(new InitEventArgs
            {
                Navigation = Navigation
            });
        }
    }
}