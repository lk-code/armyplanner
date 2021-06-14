using System;
using Windows.UI.Xaml.Controls;

namespace ArmyPlanner.Models.Navigation
{
    public class NavigationItem
    {
        public string Title { get; set; }
        public Symbol Glyph { get; set; }
        public string ToolTip { get; set; }
        public Type Target { get; set; }
    }
}
