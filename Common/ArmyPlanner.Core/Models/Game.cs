using System.Collections.Generic;

namespace ArmyPlanner.Core.Models
{
    public class Game
    {
        public string Title { get; set; }
        public string StoragePath { get; set; }
        public List<Codex> Codices { get; set; }
    }
}
