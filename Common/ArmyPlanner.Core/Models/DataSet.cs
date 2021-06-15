using System.Collections.Generic;

namespace ArmyPlanner.Core.Models
{
    public class DataSet
    {
        public enum ExplorerItemType { Folder, File };
        public string Name { get; set; }
        public ExplorerItemType Type { get; set; }

        private List<DataSet> _children;
        public List<DataSet> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<DataSet>();
                }
                return _children;
            }
            set
            {
                _children = value;
            }
        }
    }
}