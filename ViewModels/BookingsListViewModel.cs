using System.Collections.Generic;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Common.Helpers;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    internal class BookingsListViewModel : ViewModelBase
    {
        private TableToView _selectedTable;

        public TableToView SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                NotifyPropertyChanged("SelectedTable");
            }
        }
    }
}