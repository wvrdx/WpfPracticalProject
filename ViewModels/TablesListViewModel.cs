using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public TablesListViewModel()
        {
            _tablesListToView = GetTablesList();
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
                var _tableListElements = new List<TableToView>();
                db.Tables.Load();
                db.TableTypes.Load();
                db.TableStatuses.Load();
                _loadedTables = db.Tables.Local.ToList();
                _loadedTableTypes = db.TableTypes.Local.ToList();
                _loadedTableStatuses = db.TableStatuses.Local.ToList();
                foreach (var iteratedTable in _loadedTables)
                {
                    var tableListElementToAppend = new TableToView();
                    tableListElementToAppend.ID = iteratedTable.ID;
                    tableListElementToAppend.TableName = iteratedTable.TableName;
                    tableListElementToAppend.TableTypeID = (from type in _loadedTableTypes
                        where type.ID.Equals(iteratedTable.TypeID)
                        select type.ID).First();
                    tableListElementToAppend.TableType = (from type in _loadedTableTypes
                        where type.ID.Equals(iteratedTable.TypeID)
                        select type.TypeName).First().ToString();
                    tableListElementToAppend.TableStatus = (from status in _loadedTableStatuses
                        where status.ID.Equals(iteratedTable.StatusID)
                        select status.StatusName).First().ToString();
                    _tableListElements.Add(tableListElementToAppend);
                }

                return _tableListElements;
            }
        }
    }
}