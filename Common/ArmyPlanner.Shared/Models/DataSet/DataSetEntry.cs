using System.ComponentModel;

namespace ArmyPlanner.Models.DataSet
{
    public class DataSetEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string GameTitle { get; set; }

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