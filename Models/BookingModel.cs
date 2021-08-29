using System;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class Booking : ModelsBase
    {
        public int ID { get; set; }
        public int BookerID { get; set; }
        public Client Booker { get; set; }
        public int TableID { get; set; }
        public Table BookedTable { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
    }
}