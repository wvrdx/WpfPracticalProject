using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    class TableCreateEditingViewModel : CloseableViewModelBase
    {
        private List<TableType> _typesList;
        private TableType _activeTableType;
        private bool _isAddButtonVisible;
        private bool _isSaveButtonVisible;
        private string _windowTitle;
        private int _activeTableTypeIndex;
        public string _activeTableName;
        private RelayCommand _addTableCommand;

        public string AddButtonVisiblity
        {
            get
            {
                if (_isAddButtonVisible) { return "Visible"; }
                else { return "Collapsed"; }
            }
            private set
            {
            }
        }
        public string SaveButtonVisiblity
        {
            get
            {
                if (_isSaveButtonVisible) { return "Visible"; }
                else { return "Collapsed"; }
            }
            private set
            {
            }
        }
        public string ActiveTableName
        {
            get
            {
                return _activeTableName;
            }
            set
            {
                _activeTableName = value;
                NotifyPropertyChanged("ActiveTableName");
            }
        }
        public TableType ActiveTableType
        {
            get
            {
                return _activeTableType;
            }
            set
            {
                _activeTableType = value;
                NotifyPropertyChanged("ActiveTableType");
            }
        }
        public int ActiveTableTypeIndex
        {
            get
            {
                return _activeTableTypeIndex;
            }
            set
            {
                _activeTableTypeIndex = value;
                NotifyPropertyChanged("ActiveTableTypeIndex");
            }
        }
        public List<TableType> TypesList
        {
            get
            {
                _typesList = GetTablesTypesList();
                return _typesList;
            }
            set
            {
                _typesList = value;
                NotifyPropertyChanged("TypesList");
            }
        }
        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
            }
        }
        public TableCreateEditingViewModel()
        {
            _windowTitle = "Add New Table";
            _isSaveButtonVisible = false;
            _isAddButtonVisible = true;
        }
        public TableCreateEditingViewModel(TableToView SelectedTable)
        {
            _isAddButtonVisible = false;
            _isSaveButtonVisible = true;
            _activeTableName = SelectedTable.TableName;
            _windowTitle = $"Edit Table \"{_activeTableName}\"";
            TableType _tableType = (from t in TypesList
                                    where t.ID.Equals(SelectedTable.TableTypeID)
                                    select t).First();
            _activeTableTypeIndex = _typesList.IndexOf(_tableType);
        }
        private List<TableType> GetTablesTypesList()
        {
            AppDataBaseContext db = new AppDataBaseContext();
            db.TableTypes.Load();
            return db.TableTypes.Local.ToList();
        }
        public RelayCommand AddTableCommand
        {
            get
            {
                AppDataBaseContext db = new AppDataBaseContext();
                return _addTableCommand ?? (_addTableCommand = new RelayCommand(obj =>
                {
                    Table table = new Table()
                    {
                        TableName = _activeTableName,
                        TypeID = _activeTableType.ID,
                        StatusID = 1
                    };
                    db.Tables.Add(table);
                    db.SaveChanges();
                    OnClosingRequest();
                }));
            }
        }
    }
}
