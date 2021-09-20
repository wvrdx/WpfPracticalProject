using System.Collections.Generic;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class Table : ModelsBase
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int TypeId { get; set; }
        public TableType Type { get; set; }
        public int StatusId { get; set; }
        public TableStatus Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}