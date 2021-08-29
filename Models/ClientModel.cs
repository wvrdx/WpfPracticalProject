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