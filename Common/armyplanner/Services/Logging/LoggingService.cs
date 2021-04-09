using System;
using System.Collections.Generic;
using armyplanner.Core.Interfaces;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace armyplanner.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        #region # private properties #

        /// <summary>
        /// 
        /// </summary>
        private IConfigService _configService => DependencyService.Get<IConfigService>();

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
        public void Initialize()
        {
            this.InitializeAppCenter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        public void LogMessage(string className, string method, string message)
        {
            Analytics.TrackEvent($"{className}::{method}() - {message}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception exception, string message = null, IDictionary<string, string> properties = null, params object[] attachments)
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

            Crashes.TrackError(exception, properties, (attachments as ErrorAttachmentLog[]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        public void TrackEvent(string name, IDictionary<string, string> properties = null)
        {
            Analytics.TrackEvent(name, properties);
        }

        #endregion

        #region # private logic #

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void InitializeAppCenter()
        {
            string appCenterId = this.GetAppCenterId();

            Microsoft.AppCenter.AppCenter.Start(appCenterId,
                typeof(Analytics),
                typeof(Crashes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetAppCenterId()
        {
            string androidAppSecret = this._configService.Get("AppCenter:AndroidAppSecret");
            string iosAppSecret = this._configService.Get("AppCenter:iOSAppSecret");
            string uwpAppSecret = this._configService.Get("AppCenter:UwpAppSecret");

            string appCenterId = $"android={androidAppSecret};ios={iosAppSecret};uwp={uwpAppSecret}";

            return appCenterId;
        }

        #endregion
    }
}