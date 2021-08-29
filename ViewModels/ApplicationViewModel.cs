using System.Collections.Generic;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject
{
    internal class ApplicationViewModel : ViewModelBase
    {
        private bool _isTableSelected;
        private Dictionary<string, object> _selectedColumns;
        private TableToView _selectedTable;

        public TableToView SelectedTable
        {
            get => _selectedTable;
            set
            {
                if (value != null)
                {
                    _selectedTable = value;
                    IsTableSelected = true;
                }
                else
                {
                    _selectedTable = value;
                    IsTableSelected = false;
                }

                NotifyPropertyChanged("SelectedTable");
            }
        }

        public bool IsTableSelected
        {
            get => _isTableSelected;
            set
            {
                _isTableSelected = value;
                NotifyPropertyChanged("IsTableSelected");
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