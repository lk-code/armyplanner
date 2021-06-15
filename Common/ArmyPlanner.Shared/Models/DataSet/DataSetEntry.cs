using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ArmyPlanner.Models.DataSet
{
    public class DataSetEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string GameTitle { get; set; }
        /*
        public ExplorerItemType Type { get; set; }
        /* */
        /*
        private ObservableCollection<DataSetEntry> _children;
        public ObservableCollection<DataSetEntry> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new ObservableCollection<DataSetEntry>();
                }
                return _children;
            }
            set
            {
                _children = value;
            }
        }
        /* */

        /*
        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }
        /* */

        private bool _isDownloaded;
        public bool IsDownloaded
        {
            get { return _isDownloaded; }
            set
            {
                if (_isDownloaded != value)
                {
                    _isDownloaded = value;
                    NotifyPropertyChanged("IsDownloaded");
                }
            }
        }

        public DataSetEntry(string name, string gameTitle)
        {
            this.Name = name;
            this.GameTitle = gameTitle;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}