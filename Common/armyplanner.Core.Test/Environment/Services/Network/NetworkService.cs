using armyplanner.Core.Interfaces;

namespace armyplanner.Core.Test.Environment.Services.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkService : INetworkService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return true;
        }
    }
}
