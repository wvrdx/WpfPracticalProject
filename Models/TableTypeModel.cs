using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class TableType : ModelsBase
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public int Rate { get; set; }
    }
}
