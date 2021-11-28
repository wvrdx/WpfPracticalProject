using System.Collections.Generic;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Common.Helpers;
using WpfPracticalProject.Common.Resources;
using static System.String;

namespace WpfPracticalProject.Models
{
    public class TableToView : ModelsBase
    {
        private readonly string _priceUnit;
        private string _tableName;
        private string _tableRate;
        private string _tableType;

        public TableToView()
        {
            _priceUnit = Resources.Table_Price_Unit;
            IsInUse = false;
        }

        public bool IsInUse { get; }

        public List<BookingToView> BookingsList => DatabaseHelpers.GetTableBookings(this);

        public int Id { get; set; }

        public string TableName
        {
            get => _tableName;
            set
            {
                if (_tableName == null)
                    _tableName = value;
                else if (value != _tableName)
                    if (IsNullOrEmpty(value))
                    {
                        TableName = _tableName;
                        NotifyPropertyChanged("TableName");
                    }
                    else
                    {
                        UpdateTableName(value);
                    }
            }
        }

        public int TableTypeId { get; set; }

        public string TableType
        {
            get => _tableType;
            set
            {
                if (_tableType != null) UpdateTableType(value);
                _tableType = value;
                NotifyPropertyChanged("TableType");
            }
        }

        public string TableRate
        {
            get => _tableRate + " " + _priceUnit;
            set
            {
                _tableRate = value;
                NotifyPropertyChanged("TableRate");
            }
        }

        public int TableStatusId { get; set; }
        public string TableStatus { get; set; }

        private void UpdateTableType(string newTableType)
        {
            TableTypeId = (from tableType in DatabaseHelpers.GetTablesTypesList()
                where tableType.TypeName.Equals(newTableType)
                select tableType.Id).First();
            TableRate = (from tableType in DatabaseHelpers.GetTablesTypesList()
                where tableType.Id.Equals(TableTypeId)
                select tableType.Rate).First().ToString();
            DatabaseHelpers.UpdateTable(this);
        }

        private void UpdateTableName(string newTableName)
        {
            _tableName = newTableName;
            DatabaseHelpers.UpdateTable(this);
        }
    }
}