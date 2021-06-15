using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.Models;
using ArmyPlanner.Models.DataSet;
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

        private void LoadDateSets()
        {
            this.AvailableDataSets.Clear();

            this.AvailableDataSets.Add(new DataSetEntry
            {
                Name = "Warhammer 40K",
                Type = ExplorerItemType.Folder,
                Children =
                {
                    new DataSetEntry
                    {
                        Name = "Tau Empire",
                        Type = ExplorerItemType.File,
                        IsDownloaded = true
                    },
                    new DataSetEntry
                    {
                        Name = "Astra Militarum",
                        Type = ExplorerItemType.File,
                        IsDownloaded = false
                    },
                    new DataSetEntry
                    {
                        Name = "Space Marines",
                        Type = ExplorerItemType.File,
                        IsDownloaded = false
                    }
                }
            });

            this.AvailableDataSets.Add(new DataSetEntry
            {
                Name = "Warhammer - Age of Sigmar",
                Type = ExplorerItemType.Folder,
                Children =
                {
                    new DataSetEntry
                    {
                        Name = "Menschen",
                        Type = ExplorerItemType.File,
                        IsDownloaded = true
                    },
                    new DataSetEntry
                    {
                        Name = "Zwerge",
                        Type = ExplorerItemType.File,
                        IsDownloaded = false
                    },
                    new DataSetEntry
                    {
                        Name = "Elfen",
                        Type = ExplorerItemType.File,
                        IsDownloaded = true
                    }
                }
            });
        }

    }

    #endregion
}