using System.Windows;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Windows
{
    /// <summary>
    ///     Interaction logic for TableDeletionWindow.xaml
    /// </summary>
    public partial class TableDeletionWindow : Window
    {
        public TableDeletionWindow(TableToView SelectedTable)
        {
            InitializeComponent();
            var vm = new TableDeletionViewModel(SelectedTable);
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => DialogResult = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}