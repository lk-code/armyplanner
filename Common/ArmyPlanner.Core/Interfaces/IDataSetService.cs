using ArmyPlanner.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyPlanner.Core.Interfaces
{
    public interface IDataSetService
    {
        Task<List<Game>> GetAvailableCodiziesAsync();
    }
}
