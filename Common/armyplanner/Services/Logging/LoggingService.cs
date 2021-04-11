using armyplanner.Core.Interfaces;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;

namespace armyplanner.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        #region # properties #

        private readonly IConfigService _configService;

        #endregion

        #region # constructors #

        /// <summary>
        /// 
        /// </summary>
        public LoggingService(
            IConfigService configService)
        {
            this._configService = configService ?? throw new ArgumentNullException(nameof(configService));

            this.Initialize();
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
        /// <param name="userId"></param>
        public void SetLogUser(string userId)
        {
            AppCenter.SetUserId(userId);
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
        /// <param name="ex"></param>
        public void LogException(Exception ex)
        {
            this.LogException(ex, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception ex, string message = null, IDictionary<string, string> properties = null, params object[] attachments)
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

            this.LogException(ex, properties, attachments);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception ex, IDictionary<string, string> properties = null, params object[] attachments)
        {
            Crashes.TrackError(ex, properties, (attachments as ErrorAttachmentLog[]));
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

            AppCenter.Start(appCenterId,
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