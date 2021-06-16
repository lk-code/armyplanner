namespace ArmyPlanner.Models.DataSet
{
    public class GameEntry
    {
        public string Title { get; set; }
        public bool IsReset { get; set; }

        public GameEntry(string title, bool isReset = false)
        {
            this.Title = title;
            this.IsReset = isReset;
        }
    }
}
