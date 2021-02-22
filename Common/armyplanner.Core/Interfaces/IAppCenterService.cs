using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace armyplanner.Core.Interfaces
{
    public interface IAppCenterService
    {
        void TrackEvent(string name, IDictionary<string, string> properties = null);
        void TrackError(Exception exception, IDictionary<string, string> properties = null, params ErrorAttachmentLog[] attachments);
    }
}
