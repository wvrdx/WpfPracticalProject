using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class Client : ModelsBase
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public float DiscountRate { get; set; }
    }
}