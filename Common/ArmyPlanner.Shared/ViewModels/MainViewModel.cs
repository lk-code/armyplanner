using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Extensions;
using ArmyPlanner.Models.Navigation;
using ArmyPlanner.Mvvm;
using ArmyPlanner.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
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

        private Visibility _titleBarVisibility;
        public Visibility TitleBarVisibility
        {
            get { return _titleBarVisibility; }
            set { SetProperty(ref _titleBarVisibility, value); }
        }

        private ObservableCollection<NavigationItem> _navigation;
        public ObservableCollection<NavigationItem> Navigation
        {
            get { return _navigation; }
            set { SetProperty(ref _navigation, value); }
        }

        #endregion

        #region constrcutors

        public MainViewModel(ILoggingService loggingService) : base(loggingService)
        {
            this.InitializeNavigation();
        }

        #endregion

        #region logic

        public void Initialize(Frame contentFrame)
        {
            this._contentFrame = contentFrame ?? throw new System.ArgumentNullException(nameof(contentFrame));

            this.TitleBarVisibility = Visibility.Collapsed;
#if NETFX_CORE || HAS_UNO_WASM
            this.TitleBarVisibility = Visibility.Visible;
#endif
        }

        private void InitializeNavigation()
        {
            this.Navigation = new ObservableCollection<NavigationItem>()
            {
                new NavigationItem
                {
                    Title = "MainNavigation_Overview/Title".GetLocalized(),
                    Glyph = Symbol.Home,
                    ToolTip = "MainNavigation_Overview/Tooltip".GetLocalized(),
                    Target = typeof(OverviewPage)
                },
                new NavigationItem
                {
                    Title = "MainNavigation_DataSets/Title".GetLocalized(),
                    Glyph = Symbol.List,
                    ToolTip = "MainNavigation_DataSets/Tooltip".GetLocalized(),
                    Target = typeof(DataSetsPage)
                }
            };
        }

        private void HandleNavigationInvoked(NavigationViewItemInvokedEventArgs eventArgs)
        {
            bool isSettingsInvoked = eventArgs.IsSettingsInvoked;
            if(isSettingsInvoked)
            {
                this._contentFrame.Navigate(typeof(SettingsPage));

                return;
            }

            NavigationItem navigationItem = (eventArgs.InvokedItemContainer.DataContext as NavigationItem);

            if(navigationItem == null)
            {
                return;
            }

            this._contentFrame.Navigate(navigationItem.Target);
        }

        #endregion
    }
}
