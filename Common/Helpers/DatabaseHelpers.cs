﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.Common.Helpers
{
    internal static class DatabaseHelpers
    {
        public static ObservableCollection<TableToView> GetTablesList()
        {
            using (var db = new AppDataBaseContext())
            {
                db.Tables.Load();
                db.TableTypes.Load();
                db.TableStatuses.Load();
                var loadedTables = db.Tables.Local.ToList();
                var loadedTableTypes = db.TableTypes.Local.ToList();
                var loadedTableStatuses = db.TableStatuses.Local.ToList();
                return new ObservableCollection<TableToView>(loadedTables.Select(iteratedTable => new TableToView
                {
                    Id = iteratedTable.Id,
                    TableName = iteratedTable.TableName,
                    TableTypeId = (from type in loadedTableTypes
                                   where type.Id.Equals(iteratedTable.TypeId)
                                   select type.Id).First(),
                    TableType = (from type in loadedTableTypes
                                 where type.Id.Equals(iteratedTable.TypeId)
                                 select type.TypeName).First().ToString(),
                    TableRate = (from type in loadedTableTypes
                                 where type.Id.Equals(iteratedTable.TypeId)
                                 select type.Rate).First().ToString(),
                    TableStatusId = (from status in loadedTableStatuses
                                     where status.Id.Equals(iteratedTable.StatusId)
                                     select status.Id).First(),
                    TableStatus =
                            (from status in loadedTableStatuses
                             where status.Id.Equals(iteratedTable.StatusId)
                             select status.StatusName).First().ToString()
                })
                    .ToList());
            }
        }

        public static List<TableType> GetTablesTypesList()
        {
            using (var db = new AppDataBaseContext())
            {
                db.TableTypes.Load();
                return db.TableTypes.Local.ToList();
            }
        }

        public static void UpdateTable(TableToView tableToUpdate)
        {
            using (var db = new AppDataBaseContext())
            {
                var tableFromDB = db.Tables.SingleOrDefault(t => t.Id == tableToUpdate.Id);
                tableFromDB.TypeId = tableToUpdate.TableTypeId;
                tableFromDB.TableName = tableToUpdate.TableName;
                db.SaveChanges();
            }
        }
    }
}