using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    internal class TableCreateEditingViewModel : CloseableViewModelBase
    {
        private readonly int _activeTableId;
        private readonly bool _isAddButtonVisible;
        private readonly bool _isSaveButtonVisible;
        private string _activeTableName;
        private TableType _activeTableType;
        private int _activeTableTypeIndex;
        private RelayCommand _addTableCommand;
        private List<TableType> _typesList;
        private RelayCommand _updateTableCommand;

        public TableCreateEditingViewModel()
        {
            WindowTitle = "Add New Table";
            _isSaveButtonVisible = false;
            _isAddButtonVisible = true;
        }

        public TableCreateEditingViewModel(TableToView selectedTable)
        {
            _isAddButtonVisible = false;
            _isSaveButtonVisible = true;
            _activeTableName = selectedTable.TableName;
            _activeTableId = selectedTable.ID;
            WindowTitle = $"Edit Table \"{_activeTableName}\"";
            var tableType = (from t in TypesList
                             where t.ID.Equals(selectedTable.TableTypeID)
                             select t).First();
            _activeTableTypeIndex = _typesList.IndexOf(tableType);
        }

        public bool IsAddButtonVisible
        {
            get => _isAddButtonVisible;
            private set { }
        }

        public bool IsSaveButtonVisible
        {
            get => _isSaveButtonVisible;
            private set { }
        }

        public string ActiveTableName
        {
            get => _activeTableName;
            set
            {
                _activeTableName = value;
                NotifyPropertyChanged("ActiveTableName");
            }
        }

        public TableType ActiveTableType
        {
            get => _activeTableType;
            set
            {
                _activeTableType = value;
                NotifyPropertyChanged("ActiveTableType");
            }
        }

        public int ActiveTableTypeIndex
        {
            get => _activeTableTypeIndex;
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

        public string WindowTitle { get; set; }

        public RelayCommand AddTableCommand
        {
            get
            {
                return _addTableCommand ?? (_addTableCommand = new RelayCommand(obj =>
                {
                    using (var db = new AppDataBaseContext())
                    {
                        var table = new Table
                        {
                            TableName = _activeTableName,
                            TypeID = _activeTableType.ID,
                            StatusID = 1
                        };
                        db.Tables.Add(table);
                        db.SaveChanges();
                        OnClosingRequest();
                    }
                }, canExecute => CanExecuteEditUpdate()));
            }
        }

        public RelayCommand UpdateTableCommand
        {
            get
            {
                return _updateTableCommand ?? (_updateTableCommand = new RelayCommand(obj =>
                {
                    using (var db = new AppDataBaseContext())
                    {
                        var table = db.Tables.SingleOrDefault(t => t.ID == _activeTableId);
                        table.TableName = _activeTableName;
                        table.TypeID = _activeTableType.ID;
                        db.SaveChanges();
                        OnClosingRequest();
                    }
                }, canExecute => CanExecuteEditUpdate()));
            }
        }

        public bool CanExecuteEditUpdate()
        {
            return !string.IsNullOrEmpty(_activeTableName) && _activeTableType != null;
        }

        private List<TableType> GetTablesTypesList()
        {
            using (var db = new AppDataBaseContext())
            {
                db.TableTypes.Load();
                return db.TableTypes.Local.ToList();
            }
        }
    }
}