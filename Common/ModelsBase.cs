using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPracticalProject.Common
{
    public class ModelsBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}