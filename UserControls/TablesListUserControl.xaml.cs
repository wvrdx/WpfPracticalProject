using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using CustomControls;
using WpfPracticalProject.Common.Converters;
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
        private readonly TablesListViewModel _vm;
        private ObservableCollection<Column> _currentColumnsList;

        public TablesListUserControl()
        {
            InitializeComponent();
            _vm = new TablesListViewModel();
            _currentColumnsList = _vm.AvailableListedColumns;
            if (_currentColumnsList != null)
            {
                foreach (var column in _currentColumnsList)
                {
                    GridViewColumn gc = new GridViewColumn
                    {
                        Header = column.Header,
                        DisplayMemberBinding = new Binding(column.DataField),
                        Width = column.Width
                    };
                    gridView1.Columns.Add(gc);
                }
            }
            DataContext = _vm;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectedTable = (TableToView)tablesListView.SelectedItem;
            var SelectedTableIndex = tablesListView.SelectedIndex;
            var m = new TableCreationEditingWindow(SelectedTable);
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
            {
                _vm.RefreshTablesListCommand.Execute(null);
                tablesListView.SelectedIndex = SelectedTableIndex;
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new TableCreationEditingWindow();
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
            {
                _vm.RefreshTablesListCommand.Execute(null);
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
            var SelectedTable = (TableToView)tablesListView.SelectedItem;
            var m = new TableDeletionWindow(SelectedTable);
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
                _vm.RefreshTablesListCommand.Execute(null);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ((ListBox)sender).SelectedItems.Cast<String>();
            if(selectedItems != null) _vm.SetColumnVisibility(selectedItems);
        }
    }
}