using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;
using WpfPracticalProject.Common;

namespace WpfPracticalProject
{
    class ApplicationViewModel : ViewModelBase
    {
        private TableToView _selectedTable;
        private bool _isTableSelected;
        private Dictionary<string, object> _selectedColumns;
        public TableToView SelectedTable
        {
            get
            {
                return _selectedTable;
            }
            set
            {
                if(value != null)
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
            get
            {
                return _isTableSelected;
            }
            set
            {
                _isTableSelected = value;
                NotifyPropertyChanged("IsTableSelected");
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
    }
}
