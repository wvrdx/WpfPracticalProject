using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;
using WpfPracticalProject.UserControls;

namespace WpfPracticalProject.ViewModels
{
    public class TablesListViewModel : ViewModelBase
    {
        private AppDataBaseContext db = new AppDataBaseContext();
        private List<TableToView> _tablesListToView;
        private RelayCommand _deleteTableCommand;
        private List<Table> _loadedTables;
        private List<TableType> _loadedTableTypes;
        private List<TableStatus> _loadedTableStatuses;
        public List<TableToView> TablesListToView
        {
            get
            {
                _tablesListToView = GetTablesList();
                return _tablesListToView;
            }
            set
            {
                _tablesListToView = value;
                NotifyPropertyChanged("TablesListToView");
            }
        }

        private List<TableToView> GetTablesList()
        {
            List<TableToView> _tableListElements = new List<TableToView>();
            db.Tables.Load();
            db.TableTypes.Load();
            db.TableStatuses.Load();
            _loadedTables = db.Tables.Local.ToList();
            _loadedTableTypes = db.TableTypes.Local.ToList();
            _loadedTableStatuses = db.TableStatuses.Local.ToList();
            foreach(Table iteratedTable in _loadedTables)
            {
                TableToView tableListElementToAppend = new TableToView();
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
        public RelayCommand DeleteTableCommand
        {
            get
            {
                return _deleteTableCommand ?? (_deleteTableCommand = new RelayCommand(obj =>
                {
                    Table tableToDelete = new Table();
                    db.Tables.Remove(tableToDelete);
                    db.SaveChanges();
                    NotifyPropertyChanged("TablesListToView");
                }));
            }
        }
    }
}
