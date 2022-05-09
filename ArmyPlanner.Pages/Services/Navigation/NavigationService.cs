using ArmyPlanner.Pages.Interfaces;

namespace ArmyPlanner.Pages.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region properties

        private List<NavigationEntry> _mainNavigation;

        #endregion

        #region ctor

        public NavigationService()
        {
            this._mainNavigation = new List<NavigationEntry>();
        }

        #endregion

        #region logic

        public void Initialize()
        {
            // load main navigation

            this._mainNavigation.Clear();
            this._mainNavigation.Add(new NavigationEntry("", ""));
        }

        public List<NavigationEntry> GetMainNavigation()
        {
            return this._mainNavigation;
        }

        #endregion
    }
}
