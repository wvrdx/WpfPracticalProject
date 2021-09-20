using System;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class Booking : ModelsBase
    {
        public int Id { get; set; }
        public int BookerId { get; set; }
        public Client Booker { get; set; }
        public int TableId { get; set; }
        public int BookingStatusId { get; set; }
        public BookingStatus Status { get; set; }
        public Table BookedTable { get; set; }
        public DateTime BookedFrom { get; set; }
        public DateTime BookedTo { get; set; }
    }
}