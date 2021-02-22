using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using armyplanner.Core.Interfaces;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace armyplanner.Core.Services.AppCenter
{
    public class AppCenterService : IInitialized, Interfaces.IAppCenterService
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
        public AppCenterService()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~AppCenterService()
        {

        }

        #endregion

        #region # public methods #

        /// <summary>
        /// 
        /// </summary>
        public async void Initialize()
        {
            await this.InitializeAppCenterAsync();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void TrackError(Exception exception, IDictionary<string, string> properties = null, params ErrorAttachmentLog[] attachments)
        {
            Crashes.TrackError(exception, properties, attachments);
        }

        #endregion

        #region # private logic #

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAppCenterAsync()
        {
            string appCenterId = this.GetAppCenterId();

            Microsoft.AppCenter.AppCenter.Start(appCenterId,
                typeof(Analytics),
                typeof(Crashes));

            await Task.CompletedTask;
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