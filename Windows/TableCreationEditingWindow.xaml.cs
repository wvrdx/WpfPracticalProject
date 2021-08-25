using System.Windows;
using WpfPracticalProject.Common;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Windows
{
    /// <summary>
    /// Interaction logic for TableCreationEditingWindow.xaml
    /// </summary>
    public partial class TableCreationEditingWindow : Window, ICloseable
    {
        public TableCreationEditingWindow()
        {
            InitializeComponent();
            DataContext = new TableCreateEditingViewModel();
        }
        public TableCreationEditingWindow(TableToView SelectedTable)
        {
            InitializeComponent();
            DataContext = new TableCreateEditingViewModel(SelectedTable);
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
