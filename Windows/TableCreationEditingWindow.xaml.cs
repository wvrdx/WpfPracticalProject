using System.Windows;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Windows
{
    /// <summary>
    ///     Interaction logic for TableCreationEditingWindow.xaml
    /// </summary>
    public partial class TableCreationEditingWindow : Window
    {
        public TableCreationEditingWindow()
        {
            InitializeComponent();
            var vm = new TableCreateEditingViewModel();
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => DialogResult = true;
        }

        public TableCreationEditingWindow(TableToView SelectedTable)
        {
            InitializeComponent();
            var vm = new TableCreateEditingViewModel(SelectedTable);
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_MouseDown(object sender, RoutedEventArgs e)
        {
            grid1.Focus();
        }
    }
}