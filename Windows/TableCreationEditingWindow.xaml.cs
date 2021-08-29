using System.Windows;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Windows
{
    /// <summary>
    /// Interaction logic for TableCreationEditingWindow.xaml
    /// </summary>
    public partial class TableCreationEditingWindow : Window
    {
        public TableCreationEditingWindow()
        {
            InitializeComponent();
            var vm = new TableCreateEditingViewModel();
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => this.DialogResult = true;
        }
        public TableCreationEditingWindow(TableToView SelectedTable)
        {
            InitializeComponent();
            var vm = new TableCreateEditingViewModel(SelectedTable);
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
