using armyplanner.EventArgs;
using armyplanner.ViewModels;
using Xamarin.Forms;

namespace armyplanner.Views
{
    public partial class OverviewPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        OverviewViewModel ViewModel;

        public OverviewPage()
        {
            InitializeComponent();

            BindingContext = this.ViewModel = new OverviewViewModel();
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
