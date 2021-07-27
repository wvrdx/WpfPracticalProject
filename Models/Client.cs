using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfPracticalProject.Models
{
    public class Client : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public float DiscountRate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
