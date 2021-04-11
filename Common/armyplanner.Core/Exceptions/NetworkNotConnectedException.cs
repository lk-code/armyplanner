using System;

namespace armyplanner.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkNotConnectedException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public NetworkNotConnectedException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public NetworkNotConnectedException(string message) : base(message)
        {

        }
    }
}