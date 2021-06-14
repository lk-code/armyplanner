using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Models.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ArmyPlanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NavigationItem> _navigation;
        public ObservableCollection<NavigationItem> Navigation
        {
            get { return _navigation; }
            set { Set(ref _navigation, value); }
        }

        public MainViewModel(ILoggingService loggingService) : base(loggingService)
        {
            this.Navigation = new ObservableCollection<NavigationItem>()
            {
                new NavigationItem
                {
                    Title = "Home",
                    Glyph = Symbol.Home
                },
                new NavigationItem
                {
                    Title = "DataSets",
                    Glyph = Symbol.List
                }
            };
        }
    }
}
