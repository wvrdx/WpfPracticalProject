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
using System.Windows.Shapes;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Windows
{
    /// <summary>
    /// Interaction logic for TableDeletionWindow.xaml
    /// </summary>
    public partial class TableDeletionWindow : Window
    {
        public TableDeletionWindow(TableToView SelectedTable)
        {
            InitializeComponent();
            var vm = new TableDeletionViewModel(SelectedTable);
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => this.DialogResult = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
