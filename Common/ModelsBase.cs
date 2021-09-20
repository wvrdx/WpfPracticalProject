using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPracticalProject.Common
{
    public class ModelsBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}