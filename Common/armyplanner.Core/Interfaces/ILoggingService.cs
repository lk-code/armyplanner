using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;

namespace armyplanner.Core.Interfaces
{
    public interface ILoggingService
    {
        void LogMessage(string className, string method, string message);
        void LogException(Exception ex, string message = null, IDictionary<string, string> properties = null, params ErrorAttachmentLog[] attachments);
    }
}