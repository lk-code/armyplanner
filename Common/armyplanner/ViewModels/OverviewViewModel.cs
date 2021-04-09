using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using armyplanner.EventArgs;
using armyplanner.Core.Interfaces;
using armyplanner.Core.Models;
using armyplanner.Core.Mvvm;
using Xamarin.Forms;

namespace armyplanner.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        #region # private properties #

        /// <summary>
        /// 
        /// </summary>
        private ILoggingService _logService => DependencyService.Get<ILoggingService>();

        #endregion

        #region # properties #

        public ObservableCollection<Army> Armies { get; set; } = null;

        #endregion

        #region # commands #

        private ICommand _loadItemsCommand;
        /// <summary>
        /// 
        /// </summary>
        public ICommand LoadItemsCommand => _loadItemsCommand ?? (_loadItemsCommand = new RelayCommand((eventArgs) => { this.OnLoadItems(); }));

        #endregion

        #region # constructors #

        public OverviewViewModel()
        {
            this.Armies = new ObservableCollection<Army>();
        }

        #endregion

        #region # public methods #

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        protected override async void OnExecuteInitCommand(InitEventArgs eventArgs)
        {
            base.OnExecuteInitCommand(eventArgs);

            await Task.CompletedTask;

            this.LoadItemsCommand.Execute(null);
        }

        #endregion

        #region # private logic #

        private async void OnLoadItems()
        {
            await Task.CompletedTask;

            try
            {
                this.Armies.Clear();

                /*
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    this.Armies.Add(item);
                }
                /* */

                this.Armies.Add(new Army()
                {
                    Name = "Tau Empire 500 Punkte"
                });
                this.Armies.Add(new Army()
                {
                    Name = "Space Wolves 450 Punkte"
                });
                this.Armies.Add(new Army()
                {
                    Name = "Tau Empire 2500 Punkte"
                });
                this.Armies.Add(new Army()
                {
                    Name = "Tau Empire 1500 Punkte"
                });
            }
            catch (Exception exception)
            {
                this._logService.LogException(exception);
            }
            finally
            {

            }
        }

        #endregion
    }
}
