using armyplanner.EventArgs;
using armyplanner.ViewModels.Planner;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace armyplanner.Views.Planner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        OverviewViewModel ViewModel;

        public OverviewPage()
        {
            InitializeComponent();

            BindingContext = this.ViewModel = armyplanner.App.ServiceProvider.GetService<OverviewViewModel>();
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