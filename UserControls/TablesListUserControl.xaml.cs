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
using WpfPracticalProject.Windows;

namespace WpfPracticalProject.UserControls
{
    /// <summary>
    /// Interaction logic for TablesListUserControl.xaml
    /// </summary>
    public partial class TablesListUserControl : UserControl
    {
        public TablesListUserControl()
        {
            InitializeComponent();
            DataContext = new TablesListViewModel();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            TableToView SelectedTable = (TableToView)tablesListView.SelectedItem;
            TableCreationEditingWindow m = new TableCreationEditingWindow(SelectedTable);
            m.ShowDialog();
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            TableCreationEditingWindow m = new TableCreationEditingWindow();
            m.ShowDialog();
        }
        private void tablesListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListViewItem))
                tablesListView.UnselectAll();
        }
    }
}
