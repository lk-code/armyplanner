using System;
using System.Collections.Generic;

namespace armyplanner.Core.Interfaces
{
    public interface ILoggingService
    {
        void LogMessage(string className, string method, string message);
        void LogException(Exception ex);
        void LogException(Exception ex, IDictionary<string, string> properties = null, params object[] attachments);
        void LogException(Exception ex, string message = null, IDictionary<string, string> properties = null, params object[] attachments);
        void SetLogUser(string userId);
    }
}