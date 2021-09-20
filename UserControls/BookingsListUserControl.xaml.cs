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
        private BookingsListViewModel _vm;
        public BookingsListUserControl()
        {
            InitializeComponent();
            _vm = new BookingsListViewModel();
            DataContext = _vm;
        }

        public TableToView SelectedTable
        {
            get => (TableToView)GetValue(SelectedTableProperty);
            set
            {
                SetValue(SelectedTableProperty, value);
                _vm.SelectedTable = value;
            }
        }

        public static readonly DependencyProperty SelectedTableProperty =
            DependencyProperty.Register(
                "SelectedTable", typeof(TableToView),
                typeof(BookingsListUserControl)
            );
    }
}
