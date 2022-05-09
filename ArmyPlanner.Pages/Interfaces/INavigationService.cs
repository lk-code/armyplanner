using ArmyPlanner.Pages.Services.Navigation;

namespace ArmyPlanner.Pages.Interfaces
{
    public interface INavigationService
    {
        List<NavigationEntry> GetMainNavigation();
    }
}
