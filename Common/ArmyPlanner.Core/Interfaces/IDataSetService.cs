using System.Collections.Generic;

namespace ArmyPlanner.Core.Interfaces
{
    public interface IDataSetService
    {
        List<string> GetAvailableEntries();
    }
}
