using armyplanner.Core.Mvvm;
using armyplanner.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace armyplanner.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        private INavigation _navigation = null;
        /// <summary>
        /// 
        /// </summary>
        public INavigation Navigation
        {
            get { return _navigation; }
            set { SetProperty(ref _navigation, value); }
        }

        #endregion

        #region # commands #

        private ICommand _initCommand;
        /// <summary>
        /// 
        /// </summary>
        public ICommand InitCommand => _initCommand ?? (_initCommand = new RelayCommand((eventArgs) => {
            this.OnExecuteInitCommand(eventArgs as InitEventArgs);
        }));

        #endregion

        #region # constructors #

        /// <summary>
        /// 
        /// </summary>
        public BaseViewModel()
        {

        }

        #endregion

        #region # public methods #

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        protected virtual async void OnExecuteInitCommand(InitEventArgs eventArgs)
        {
            await Task.CompletedTask;

            if (eventArgs != null)
            {
                this.Navigation = eventArgs.Navigation;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="styleName"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        protected Style GetStyleByName(string styleName, Type targetType)
        {
            try
            {
                List<Style> resources = (Application.Current.Resources[styleName] as List<Style>);
                var detectedResources = resources.Where(x => x.TargetType.Equals(targetType));

                if (detectedResources.Count() > 0)
                {
                    return detectedResources.First();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="styleName"></param>
        /// <param name="style"></param>
        protected void SetStyle(string styleName, Style style)
        {
            try
            {
                Application.Current.Resources[styleName] = style;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region # private logic #

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <param name="onChanged"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore,
            T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }

        #endregion
    }
}