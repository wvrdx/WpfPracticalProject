using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class TableType : ModelsBase
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int Rate { get; set; }
    }
}