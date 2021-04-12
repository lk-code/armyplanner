using armyplanner.Core.Interfaces;
using armyplanner.EventArgs;
using System;

namespace armyplanner.ViewModels.Planner
{
    public class OverviewViewModel : BaseViewModel
    {
        #region Private Eigenschaften

        private readonly ILoggingService _loggingService;

        #endregion

        #region Properties

        #endregion

        #region Commands

        #endregion

        #region Konstruktoren

        /// <summary>
        /// 
        /// </summary>
        public OverviewViewModel(
            ILoggingService loggingService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
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
        }

        #endregion
    }
}