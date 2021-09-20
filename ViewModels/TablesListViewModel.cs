using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    public class TablesListViewModel : ViewModelBase
    {
        private List<Table> _loadedTables;
        private List<TableStatus> _loadedTableStatuses;
        private List<TableType> _loadedTableTypes;
        private RelayCommand _refreshTablesListCommand;
        private List<TableToView> _tablesListToView;
        private StringBuilder _columnNumbers;

        private ObservableCollection<Column> _availableColumns = new ObservableCollection<Column>
        {
            new Column { Order = 0, Header = "Table Name", DataField = "TableName", Visibility = true},
            new Column { Order = 1, Header = "Table Type", DataField = "TableType", Visibility = true },
            new Column { Order = 2, Header = "Table Rate", DataField = "TableRate", Visibility = true, Width = 80},
            new Column { Order = 3, Header = "Status", DataField = "TableStatus", Visibility = true, Width = 90}
        };

        public string SelectedColumnNumbers
        {
            get
            {
                return _columnNumbers.ToString();
            }
            set { }
        }

        public TablesListViewModel()
        {
            _tablesListToView = GetTablesList();
            _columnNumbers = new StringBuilder(CalculateColumnNumbers());
        }

        public ObservableCollection<Column> AvailableListedColumns
        {
            get => _availableColumns;
            set { }
        }

        public ObservableCollection<Column> SelectedColumns
        {
            get
            {
                return _availableColumns;
            }
            set
            {
                _availableColumns = value;
                NotifyPropertyChanged("SelectedColumns");
            }
        }

        public List<TableToView> TablesListToView
        {
            get => _tablesListToView;
            set
            {
                _tablesListToView = value;
                NotifyPropertyChanged("TablesListToView");
            }
        }

        public RelayCommand RefreshTablesListCommand
        {
            get
            {
                return _refreshTablesListCommand ?? (_refreshTablesListCommand = new RelayCommand(obj =>
                {
                    TablesListToView = GetTablesList();
                }));
            }
        }

        private List<TableToView> GetTablesList()
        {
            using (var db = new AppDataBaseContext())
            {
                var tableListElements = new List<TableToView>();
                db.Tables.Load();
                db.TableTypes.Load();
                db.TableStatuses.Load();
                _loadedTables = db.Tables.Local.ToList();
                _loadedTableTypes = db.TableTypes.Local.ToList();
                _loadedTableStatuses = db.TableStatuses.Local.ToList();
                foreach (var iteratedTable in _loadedTables)
                {
                    var tableListElementToAppend = new TableToView();
                    tableListElementToAppend.Id = iteratedTable.Id;
                    tableListElementToAppend.TableName = iteratedTable.TableName;
                    tableListElementToAppend.TableTypeId = (from type in _loadedTableTypes
                                                            where type.Id.Equals(iteratedTable.TypeId)
                                                            select type.Id).First();
                    tableListElementToAppend.TableType = (from type in _loadedTableTypes
                                                          where type.Id.Equals(iteratedTable.TypeId)
                                                          select type.TypeName).First().ToString();
                    tableListElementToAppend.TableRate = (from type in _loadedTableTypes
                                                          where type.Id.Equals(iteratedTable.TypeId)
                                                          select type.Rate).First().ToString();
                    tableListElementToAppend.TableStatusId = (from status in _loadedTableStatuses
                                                              where status.Id.Equals(iteratedTable.StatusId)
                                                              select status.Id).First();
                    tableListElementToAppend.TableStatus = (from status in _loadedTableStatuses
                                                            where status.Id.Equals(iteratedTable.StatusId)
                                                            select status.StatusName).First().ToString();
                    tableListElements.Add(tableListElementToAppend);
                }
                return tableListElements;
            }
        }

        private string CalculateColumnNumbers()
        {
            _columnNumbers = new StringBuilder();
            foreach (var column in _availableColumns)
            {
                if (!column.Visibility)
                {
                    _columnNumbers.Append(_availableColumns.IndexOf(column));
                    _columnNumbers.Append(",");
                }
            }
            return _columnNumbers.ToString().TrimEnd(',');
        }

        public void SetColumnVisibility(IEnumerable<String> selectedItems)
        {
            foreach (var column in _availableColumns)
            {
                if (selectedItems.Contains(column.Header))
                {
                    column.Visibility = true;
                }
                else if (!selectedItems.Contains(column.Header))
                {
                    column.Visibility = false;
                }
            }
            _columnNumbers = new StringBuilder(CalculateColumnNumbers());
            NotifyPropertyChanged("SelectedColumnNumbers");
        }
    }
    public class Column
    {
        public int Order { get; set; }
        public string Header { get; set; }
        public string DataField { get; set; }
        public int Width = 100;
        public bool Visibility { get; set; }
    }
}