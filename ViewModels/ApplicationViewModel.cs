using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject
{
    internal class ApplicationViewModel : ViewModelBase
    {
        private bool _isTableSelected;
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
    }
}