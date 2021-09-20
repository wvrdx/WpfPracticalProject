using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.UserControls
{
    /// <summary>
    /// Interaction logic for BookingsListUserControl.xaml
    /// </summary>
    public partial class BookingsListUserControl : UserControl
    {
        BookingsListViewModel vm;
        public BookingsListUserControl()
        {
            InitializeComponent();
            vm = new BookingsListViewModel();
            DataContext = vm;
        }
    }
}
