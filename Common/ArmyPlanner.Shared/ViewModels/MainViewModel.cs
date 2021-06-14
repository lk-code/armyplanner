using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Models.Navigation;
using ArmyPlanner.Mvvm;
using ArmyPlanner.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace ArmyPlanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region properties

        private Frame _contentFrame = null;

        private ICommand _navigationInvokedCommand;

        public ICommand NavigationInvokedCommand => _navigationInvokedCommand ?? (_navigationInvokedCommand = new RelayCommand<NavigationViewItemInvokedEventArgs>((eventArgs) => {
            this.HandleNavigationInvoked(eventArgs);
        }));

        private ObservableCollection<NavigationItem> _navigation;
        public ObservableCollection<NavigationItem> Navigation
        {
            get { return _navigation; }
            set { Set(ref _navigation, value); }
        }

        #endregion

        #region constrcutors

        public MainViewModel(ILoggingService loggingService) : base(loggingService)
        {
            this.Navigation = new ObservableCollection<NavigationItem>()
            {
                new NavigationItem
                {
                    Title = "~Overview",
                    Glyph = Symbol.Home,
                    ToolTip = "~Zurück zur Startseite",
                    Target = typeof(OverviewPage)
                },
                new NavigationItem
                {
                    Title = "~DataLists",
                    Glyph = Symbol.List,
                    ToolTip = "~Übersicht aller Datensätze",
                    Target = typeof(DataListsPage)
                }
            };
        }

        #endregion

        #region logic

        public void Initialize(Frame contentFrame)
        {
            this._contentFrame = contentFrame ?? throw new System.ArgumentNullException(nameof(contentFrame));
        }

        private void HandleNavigationInvoked(NavigationViewItemInvokedEventArgs eventArgs)
        {
            NavigationItem navigationItem = (eventArgs.InvokedItemContainer.DataContext as NavigationItem);
            this._contentFrame.Navigate(navigationItem.Target);
        }

        #endregion
    }
}
