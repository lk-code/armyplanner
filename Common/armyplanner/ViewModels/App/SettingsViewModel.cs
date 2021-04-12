using armyplanner.Core.Interfaces;
using armyplanner.EventArgs;
using System;

namespace armyplanner.ViewModels.App
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Private Eigenschaften

        private readonly ILoggingService _loggingService;
        private readonly IPreferencesServices _preferencesServices;

        #endregion

        #region Properties

        #endregion

        #region Commands

        #endregion

        #region Konstruktoren

        /// <summary>
        /// 
        /// </summary>
        public SettingsViewModel(
            ILoggingService loggingService,
            IPreferencesServices preferencesServices)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
            this._preferencesServices = preferencesServices ?? throw new ArgumentNullException(nameof(preferencesServices));
        }

        #endregion

        #region Workers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        protected override async void OnExecuteInitCommand(InitEventArgs eventArgs)
        {
            base.OnExecuteInitCommand(eventArgs);

            this.LoadDefaults();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDefaults()
        {
            try
            {
                //this.IsHistoryOrderDesc = this._preferencesServices.Get(PreferencesKeys.HISTORY_ORDER_DESC.ToLower(), this.IsHistoryOrderDesc);
            }
            catch (Exception exception)
            {
                this._loggingService.LogException(exception);
            }
        }

        #endregion
    }
}