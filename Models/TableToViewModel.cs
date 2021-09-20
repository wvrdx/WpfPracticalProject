using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class TableToView : ModelsBase
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int TableTypeId { get; set; }
        public string TableType { get; set; }
        public string TableRate { get; set; }
        public int TableStatusId { get; set; }
        public string TableStatus { get; set; }
    }
}