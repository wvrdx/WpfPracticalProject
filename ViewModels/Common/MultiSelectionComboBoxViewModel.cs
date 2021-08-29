using System.Collections.Generic;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.ViewModels.Common
{
    internal class MultiSelectionComboBoxViewModel : ViewModelBase
    {
        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedColumns;


        public MultiSelectionComboBoxViewModel()
        {
            Items = new Dictionary<string, object>();
            Items.Add("Table Name", 1);
            Items.Add("Table Type", 2);
            Items.Add("Status", 3);

            SelectedColumns = new Dictionary<string, object>();
            SelectedColumns.Add("Table Name", 1);
            SelectedColumns.Add("Table Type", 2);
            SelectedColumns.Add("Status", 3);
        }


        public Dictionary<string, object> Items
        {
            get => _items;
            set
            {
                _items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public Dictionary<string, object> SelectedColumns
        {
            get => _selectedColumns;
            set
            {
                _selectedColumns = value;
                NotifyPropertyChanged("SelectedColumns");
            }
        }
    }
}