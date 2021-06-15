using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.Models;
using ArmyPlanner.Models.DataSet;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArmyPlanner.ViewModels
{
    public class DataSetsViewModel : BaseViewModel
    {
        #region properties

        private readonly IDataSetService _dataSetService;

        private ObservableCollection<DataSetEntry> _availableDataSets;
        public ObservableCollection<DataSetEntry> AvailableDataSets
        {
            get { return _availableDataSets; }
            set { Set(ref _availableDataSets, value); }
        }

        #endregion

        #region constrcutors

        public DataSetsViewModel(ILoggingService loggingService,
            IDataSetService dataSetService) : base(loggingService)
        {
            this._dataSetService = dataSetService ?? throw new System.ArgumentNullException(nameof(dataSetService));

            this.AvailableDataSets = new ObservableCollection<DataSetEntry>();
        }

        #endregion

        #region logic

        public void Initialize()
        {
            this.LoadDateSets();
        }

        private async void LoadDateSets()
        {
            this.AvailableDataSets.Clear();

            List<Game> games = await this._dataSetService.GetAvailableCodiziesAsync();

            foreach(Game game in games)
            {
                if (game.Codices == null)
                {
                    continue;
                }

                foreach (Codex codex in game.Codices)
                {
                    this.AvailableDataSets.Add(new DataSetEntry(codex.Name, game.Title));
                }
            }
        }
    }

    #endregion
}