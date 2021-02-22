using System;
using System.Collections.Generic;
using armyplanner.Core.Interfaces;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace armyplanner.Core.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        #region # private properties #

        /// <summary>
        /// 
        /// </summary>
        private IConfigService _configService => DependencyService.Get<IConfigService>();

        /// <summary>
        /// 
        /// </summary>
        private Interfaces.IAppCenterService _appCenterService => DependencyService.Get<Interfaces.IAppCenterService>();

        #endregion

        #region # constructors #

        /// <summary>
        /// 
        /// </summary>
        public LoggingService()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~LoggingService()
        {

        }

        #endregion

        #region # public methods #

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        public void LogMessage(string className, string method, string message)
        {
            this._appCenterService.TrackEvent($"{className}::{method}() - {message}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception exception, string message = null, IDictionary<string, string> properties = null, params ErrorAttachmentLog[] attachments)
        {
            if (!string.IsNullOrEmpty(message)
                && !string.IsNullOrWhiteSpace(message))
            {
                if (properties == null)
                {
                    properties = new Dictionary<string, string>();
                }

                properties.Add("development_message", message);
            }

            this._appCenterService.TrackError(exception, properties, attachments);
        }

        #endregion
    }
}