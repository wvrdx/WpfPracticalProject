using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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
        private readonly ObservableCollection<Column> _currentColumnsList;
        private readonly TablesListViewModel _vm;

        public TablesListUserControl()
        {
            InitializeComponent();
            _vm = new TablesListViewModel();
            _currentColumnsList = _vm.AvailableListedColumns;
            if (_currentColumnsList != null)
                foreach (var column in _currentColumnsList)
                    if (column.Type == "TextBox")
                    {
                        var gc = GenerateTextboxColumn(column);
                        tablesDataDrid.Columns.Add(gc);
                    }
                    else if (column.Type == "ComboBox")
                    {
                        var gc = GenerateComboBoxColumn(column);
                        tablesDataDrid.Columns.Add(gc);
                    }

            DataContext = _vm;
            var resources = Resources;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectedTable = (TableToView) tablesDataDrid.SelectedItem;
            var SelectedTableIndex = tablesDataDrid.SelectedIndex;
            var m = new TableCreationEditingWindow(SelectedTable);
            m.ShowDialog();
            if (!m.DialogResult.HasValue || !m.DialogResult.Value) return;
            _vm.RefreshTablesListCommand.Execute(null);
            tablesDataDrid.SelectedIndex = SelectedTableIndex;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var m = new TableCreationEditingWindow();
            m.ShowDialog();
            if (!m.DialogResult.HasValue || !m.DialogResult.Value) return;
            _vm.RefreshTablesListCommand.Execute(null);
            tablesDataDrid.SelectedIndex = tablesDataDrid.Items.Count - 1;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectedTable = (TableToView) tablesDataDrid.SelectedItem;
            var m = new TableDeletionWindow(SelectedTable);
            m.ShowDialog();
            if (m.DialogResult.HasValue && m.DialogResult.Value)
                _vm.RefreshTablesListCommand.Execute(null);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItems = ((ListBox) sender).SelectedItems.Cast<string>();
            if (selectedItems != null) _vm.SetColumnVisibility(selectedItems);
        }

        private DataGridTextColumn GenerateTextboxColumn(Column column)
        {
            var gc = new DataGridTextColumn
            {
                Header = column.Header,
                Width = column.Width,
                Visibility = column.Visibility,
                IsReadOnly = column.IsReadOnly
            };
            if (column.StyleKey != null)
            {
                var style = FindResource(column.StyleKey) as Style;
                gc.CellStyle = style;
            }

            gc.Binding = new Binding
            {
                Path = new PropertyPath(column.DataField),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            return gc;
        }

        private DataGridComboBoxColumn GenerateComboBoxColumn(Column column)
        {
            var gc = new DataGridComboBoxColumn
            {
                Header = column.Header,
                Width = column.Width,
                IsReadOnly = column.IsReadOnly
            };
            if (column.StyleKey != null)
            {
                var style = FindResource(column.StyleKey) as Style;
                gc.CellStyle = style;
            }

            gc.SelectedItemBinding = new Binding
            {
                Path = new PropertyPath(column.DataField),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            gc.ItemsSource = _vm.TableTypesNamesList;
            //var editingElementStyle = new Style(typeof(ComboBox));
            //editingElementStyle.Setters.Add(new EventSetter(ComboBox.LostFocusEvent, new SelectionChangedEventHandler(OnComboboxSelectionChanged)));
            //editingElementStyle.Setters.Add(new EventSetter(ComboBox.GotFocusEvent, new SelectionChangedEventHandler(OnComboboxSelectionChanged)));
            //gc.EditingElementStyle = editingElementStyle;
            return gc;
        }

        private void OnComboboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow =
                (DataGridRow) tablesDataDrid.ItemContainerGenerator.ContainerFromIndex(tablesDataDrid.SelectedIndex);
            FocusManager.SetIsFocusScope(selectedRow, true);
            FocusManager.SetFocusedElement(selectedRow, selectedRow);
        }
    }
}