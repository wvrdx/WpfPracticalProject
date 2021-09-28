using System.IO.Packaging;
using System.Linq;
using WpfPracticalProject.Common;
using WpfPracticalProject.Common.Helpers;
using static System.String;

namespace WpfPracticalProject.Models
{
    public class TableToView : ModelsBase
    {
        private string _tableType;
        private string _tableName;
        private string _tableRate;
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
                        UpdateTableName(value);
            }
        }
        public int TableTypeId { get; set; }

        public string TableType
        {
            get => _tableType;
            set
            {
                if (_tableType != null)
                {
                    UpdateTableType(value);
                }
                _tableType = value;
            }
        }
        public string TableRate
        {
            get => _tableRate;
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