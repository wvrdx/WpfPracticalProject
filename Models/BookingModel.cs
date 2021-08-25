using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
