using ArmyPlanner.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ArmyPlanner.ViewModels
{
    public class BaseViewModel
    {
        #region Properties

        private readonly ILoggingService _loggingService;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Konstruktoren

        public BaseViewModel(ILoggingService loggingService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
        }

        #endregion

        #region Worker

        protected void Set<T>(ref T field, T newValue = default, bool broadcast = false, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
