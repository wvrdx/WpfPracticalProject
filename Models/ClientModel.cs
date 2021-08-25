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
    public class Client : ModelsBase
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public float DiscountRate { get; set; }
    }
}
