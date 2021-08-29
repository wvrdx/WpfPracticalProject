using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;
using WpfPracticalProject.Windows;

namespace WpfPracticalProject.UserControls
{
    /// <summary>
    ///     Interaction logic for TablesListUserControl.xaml
    /// </summary>
    public partial class TablesListUserControl : UserControl
    {
        private readonly TablesListViewModel vm;

        public TablesListUserControl()
        {
            InitializeComponent();
            vm = new TablesListViewModel();
            DataContext = vm;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectedTable = (TableToView) tablesListView.SelectedItem;
            var SelectedTableIndex = tablesListView.SelectedIndex;
            var m = new TableCreationEditingWindow(SelectedTable);
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
            {
                vm.RefreshTablesListCommand.Execute(null);
                tablesListView.SelectedIndex = SelectedTableIndex;
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new TableCreationEditingWindow();
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
            {
                vm.RefreshTablesListCommand.Execute(null);
                tablesListView.SelectedIndex = tablesListView.Items.Count - 1;
            }
        }

        private void tablesListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListViewItem))
                tablesListView.UnselectAll();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectedTable = (TableToView) tablesListView.SelectedItem;
            var m = new TableDeletionWindow(SelectedTable);
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
                vm.RefreshTablesListCommand.Execute(null);
        }
    }
}