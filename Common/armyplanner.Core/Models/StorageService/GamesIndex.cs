using System;
using System.Collections.Generic;

namespace armyplanner.Core.Models.StorageService
{
    public class GamesIndex
    {
        public DateTime Created { get; set; } = DateTime.MinValue;
        public List<Game> Games { get; set; } = null;
    }
}
