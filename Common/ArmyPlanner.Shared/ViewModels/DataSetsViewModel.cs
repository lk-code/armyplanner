using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.Models;
using ArmyPlanner.Extensions;
using ArmyPlanner.Models.DataSet;
using ArmyPlanner.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ArmyPlanner.ViewModels
{
    public class DataSetsViewModel : BaseViewModel
    {
        #region properties

        private readonly IDataSetService _dataSetService;

        private List<Game> _availableDataSets = null;

        private ICommand _searchTextValueChangedCommand;
        private ICommand _gameFilterSelectionChangedCommand;
        private ICommand _refreshDataSetsCommand;

        public ICommand SearchTextValueChangedCommand => _searchTextValueChangedCommand ?? (_searchTextValueChangedCommand = new RelayCommand<string>((eventArgs) => {
            this.ApplyDataSetsFilter(eventArgs);
        }));
        public ICommand GameFilterSelectionChangedCommand => _gameFilterSelectionChangedCommand ?? (_gameFilterSelectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>((eventArgs) => {
            this.ApplyDataSetsFilter(this.SearchTextValue);
        }));
        public ICommand RefreshDataSetsCommand => _refreshDataSetsCommand ?? (_refreshDataSetsCommand = new RelayCommand<SelectionChangedEventArgs>((eventArgs) => {
            this.LoadDataSets();
        }));

        private ObservableCollection<DataSetEntry> _availableDataSetsCollection;
        public ObservableCollection<DataSetEntry> AvailableDataSetsCollection
        {
            get { return _availableDataSetsCollection; }
            set { SetProperty(ref _availableDataSetsCollection, value); }
        }
        private ObservableCollection<string> _dataSetsSearchSuggestions;
        public ObservableCollection<string> DataSetsSearchSuggestions
        {
            get { return _dataSetsSearchSuggestions; }
            set { SetProperty(ref _dataSetsSearchSuggestions, value); }
        }
        private ObservableCollection<GameEntry> _gameFilterCollection;
        public ObservableCollection<GameEntry> GameFilterCollection
        {
            get { return _gameFilterCollection; }
            set { SetProperty(ref _gameFilterCollection, value); }
        }
        private string _searchTextValue;
        public string SearchTextValue
        {
            get { return _searchTextValue; }
            set { SetProperty(ref _searchTextValue, value); }
        }
        private GameEntry _selectedGameFilterEntry;
        public GameEntry SelectedGameFilterEntry
        {
            get { return _selectedGameFilterEntry; }
            set { SetProperty(ref _selectedGameFilterEntry, value); }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set {
                SetProperty(ref _isLoading, value);
                if(value == true)
                {
                    this.IsAvailableDataSetsVisibility = Visibility.Collapsed;
                } else
                {
                    this.IsAvailableDataSetsVisibility = Visibility.Visible;
                }
            }
        }
        private Visibility _isAvailableDataSetsVisibility;
        public Visibility IsAvailableDataSetsVisibility
        {
            get { return _isAvailableDataSetsVisibility; }
            set { SetProperty(ref _isAvailableDataSetsVisibility, value); }
        }

        #endregion

        #region constrcutors

        public DataSetsViewModel(ILoggingService loggingService,
            IDataSetService dataSetService) : base(loggingService)
        {
            this._dataSetService = dataSetService ?? throw new System.ArgumentNullException(nameof(dataSetService));

            this._availableDataSets = new List<Game>();
            this.AvailableDataSetsCollection = new ObservableCollection<DataSetEntry>();
            this.GameFilterCollection = new ObservableCollection<GameEntry>();
        }

        #endregion

        #region logic

        public void Initialize()
        {
            this.LoadDataSets();
        }

        private void ApplyDataSets(List<Game> games)
        {
            this.AvailableDataSetsCollection.Clear();

            foreach (Game game in games)
            {
                if (game.Codices == null)
                {
                    continue;
                }

                foreach (Codex codex in game.Codices)
                {
                    this.AvailableDataSetsCollection.Add(new DataSetEntry(codex.Name, game.Title));
                }
            }
        }

        private void ApplyDataSetsFilter(string searchTextValue)
        {
            bool hasGameFilter = ((this.SelectedGameFilterEntry == null) ? false : !this.SelectedGameFilterEntry.IsReset);

            if (string.IsNullOrEmpty(searchTextValue))
            {
                if (hasGameFilter == true)
                {
                    this.ApplyDataSets(this._availableDataSets.Where(g => g.Title.ToLowerInvariant().Equals(this.SelectedGameFilterEntry.Title.ToLowerInvariant())).ToList());
                }
                else
                {
                    this.ApplyDataSets(this._availableDataSets);
                }
                return;
            }

            List<Game> availableDataSetsForWork = this._availableDataSets;

            List<Game> filteredGames = availableDataSetsForWork
                .Where(g => {
                    if(hasGameFilter == true)
                    {
                        return (g.Title.ToLowerInvariant().Equals(this.SelectedGameFilterEntry.Title.ToLowerInvariant()) && g.Codices.Any(c => c.Name.ToLowerInvariant().Contains(searchTextValue.ToLowerInvariant())));
                    } else
                    {
                        return g.Codices.Any(c => c.Name.ToLowerInvariant().Contains(searchTextValue.ToLowerInvariant()));
                    }
                })
                .Select(g => new Game
                {
                    Title = g.Title,
                    StoragePath = g.StoragePath,
                    Codices = g.Codices.Where(c => c.Name.ToLowerInvariant().Contains(searchTextValue.ToLowerInvariant()))
                        .Select(c => new Codex
                        {
                            Name = c.Name
                        }).ToList()
                })
                .ToList();

            this.ApplyDataSets(filteredGames);
        }

        private async void LoadDataSets()
        {
            this.IsLoading = true;

            this._availableDataSets.Clear();
            this._availableDataSets = await this._dataSetService.GetAvailableCodiziesAsync();

            this.GameFilterCollection.Clear();
            this.GameFilterCollection.Add(new GameEntry("DataSets_GameFilterComboBox_AllGames/Text".GetLocalized(), true));

            this.SearchTextValue = string.Empty;
            this.SelectedGameFilterEntry = this.GameFilterCollection.First();

            foreach (Game game in this._availableDataSets)
            {
                if (game.Codices == null)
                {
                    continue;
                }

                this.GameFilterCollection.Add(new GameEntry(game.Title));
            }

            this.ApplyDataSetsFilter(this.SearchTextValue);

            this.IsLoading = false;
        }
    }

    #endregion
}