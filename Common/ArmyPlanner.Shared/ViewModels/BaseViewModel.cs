using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.ViewModels;
using System;

namespace ArmyPlanner.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        #region Properties

        private readonly ILoggingService _loggingService;

        #endregion

        #region Konstruktoren

        public BaseViewModel(ILoggingService loggingService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
        }

        #endregion

        #region Worker

        #endregion
    }
}
