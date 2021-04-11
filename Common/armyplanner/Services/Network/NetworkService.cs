using armyplanner.Core.Interfaces;
using Xamarin.Essentials;

namespace armyplanner.Services.Network
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
            return (Connectivity.NetworkAccess == NetworkAccess.Internet);
        }
    }
}