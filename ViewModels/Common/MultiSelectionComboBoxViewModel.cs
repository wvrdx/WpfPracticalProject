using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.ViewModels.Common
{
    class MultiSelectionComboBoxViewModel : ViewModelBase
    {

        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedColumns;


        public Dictionary<string, object> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public Dictionary<string, object> SelectedColumns
        {
            get
            {
                return _selectedColumns;
            }
            set
            {
                _selectedColumns = value;
                NotifyPropertyChanged("SelectedColumns");
            }
        }



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
    }
}
