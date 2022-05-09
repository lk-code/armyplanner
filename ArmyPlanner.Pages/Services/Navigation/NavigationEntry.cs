namespace ArmyPlanner.Pages.Services.Navigation
{
    public class NavigationEntry
    {
        public string Title { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public List<NavigationEntry> Children { get; set; }

        public NavigationEntry(string title, string href)
        {
            this.Children = new List<NavigationEntry>();

            this.Title = title;
            this.Href = href;
        }
    }
}
