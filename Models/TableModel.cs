using System.Collections.Generic;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class Table : ModelsBase
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public int TypeID { get; set; }
        public TableType Type { get; set; }
        public int StatusID { get; set; }
        public TableStatus Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}