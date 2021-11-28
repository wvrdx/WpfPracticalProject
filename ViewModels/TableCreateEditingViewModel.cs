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
        private string _activeTableName;
        private TableType _activeTableType;
        private int _activeTableTypeIndex;
        private RelayCommand _addTableCommand;
        private bool _isNameValid;
        private List<TableType> _typesList;
        private RelayCommand _updateTableCommand;
        private string _validationMessage;

        public TableCreateEditingViewModel()
        {
            WindowTitle = "Add New Table";
            IsSaveButtonVisible = false;
            IsAddButtonVisible = true;
            IsNameValid = true;
        }

        public TableCreateEditingViewModel(TableToView selectedTable)
        {
            IsAddButtonVisible = false;
            IsSaveButtonVisible = true;
            IsNameValid = true;
            _activeTableName = selectedTable.TableName;
            _activeTableId = selectedTable.Id;
            WindowTitle = $"Edit Table \"{_activeTableName}\"";
            var tableType = (from t in TypesList
                where t.Id.Equals(selectedTable.TableTypeId)
                select t).First();
            _activeTableTypeIndex = _typesList.IndexOf(tableType);
        }

        public bool IsAddButtonVisible { get; }

        public bool IsSaveButtonVisible { get; }

        public bool IsNameValid
        {
            get => _isNameValid;
            set
            {
                _isNameValid = value;
                NotifyPropertyChanged("IsNameValid");
            }
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

        public string ValidationMessage
        {
            get => _validationMessage;
            set
            {
                _validationMessage = value;
                NotifyPropertyChanged("ValidationMessage");
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

        public string WindowTitle { get; }

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
                            TypeId = _activeTableType.Id,
                            StatusId = 1
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
                        var table = db.Tables.SingleOrDefault(t => t.Id == _activeTableId);
                        table.TableName = _activeTableName;
                        table.TypeId = _activeTableType.Id;
                        db.SaveChanges();
                        OnClosingRequest();
                    }
                }, canExecute => CanExecuteEditUpdate()));
            }
        }

        public bool CanExecuteEditUpdate()
        {
            SetValidationResults();
            return !string.IsNullOrEmpty(_activeTableName) && _activeTableType != null && _activeTableName.Length <= 10;
        }

        private void SetValidationResults()
        {
            if (string.IsNullOrEmpty(_activeTableName))
            {
                ValidationMessage = "Table Name cannot be empty";
                IsNameValid = false;
            }
            else if (_activeTableName.Length > 10)
            {
                ValidationMessage = "Table Name cannot be longer than 10 characters";
                IsNameValid = false;
            }
            else
            {
                ValidationMessage = null;
                IsNameValid = true;
            }
        }

        private static List<TableType> GetTablesTypesList()
        {
            using (var db = new AppDataBaseContext())
            {
                db.TableTypes.Load();
                return db.TableTypes.Local.ToList();
            }
        }
    }
}