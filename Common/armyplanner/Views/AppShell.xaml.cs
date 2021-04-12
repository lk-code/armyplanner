using armyplanner.EventArgs;
using armyplanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace armyplanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : TabbedPage
    {
        /// <summary>
        /// 
        /// </summary>
        AppShellViewModel ViewModel;

        public AppShell()
        {
            InitializeComponent();

            BindingContext = this.ViewModel = armyplanner.App.ServiceProvider.GetService<AppShellViewModel>();

            this.ViewModel.TabbedPage = this;
            this.ViewModel.InitCommand.Execute(new InitEventArgs
            {
                Navigation = Navigation
            });
        }
    }
}