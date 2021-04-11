using armyplanner.Core.Models.StorageService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace armyplanner.Core.Interfaces
{
    public interface IStorageService
    {
        Task<List<Game>> GetGamesAsync(bool force = false);
    }
}
