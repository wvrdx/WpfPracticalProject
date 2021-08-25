using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
