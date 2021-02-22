using System.Collections.Generic;
using armyplanner.Models.Navigation;
using Xamarin.Forms;

namespace armyplanner.Views
{
    public partial class MenuPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        /// <summary>
        /// 
        /// </summary>
        List<MenuEntry> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<MenuEntry>
            {
                new MenuEntry {Id = MenuItemType.Overview, Title="Overview" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((MenuEntry)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}