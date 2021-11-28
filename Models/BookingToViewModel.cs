using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPracticalProject.Models
{
    public class BookingToView
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int BookerId { get; set; }
        public string BookerName { get; set; }
        public int BookingStatusId { get; set; }
        public string BookingStatusName { get; set; }
    }
}
