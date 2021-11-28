using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using WpfPracticalProject.Common;
using WpfPracticalProject.Common.Helpers;
using WpfPracticalProject.Common.Templates;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.ViewModels
{
    public class TablesListViewModel : ViewModelBase
    {
        private static Dictionary<string, Color> _statusColorsMap = new Dictionary<string, Color>
        {
            { "DefaultStatus", Color.FromArgb(50,255,0,0) },
            { "Status1", Color.FromArgb(50,0,255,0) },
            { "Status2", Color.FromArgb(50,0,0,255) }
        };
        private ObservableCollection<Column> _availableColumns = new ObservableCollection<Column>
        {
            new Column {Type = "TextBox", Header = "Table Name", DataField = "TableName", Visibility = Visibility.Visible, IsReadOnly = false},
            new Column {Type = "ComboBox", Header = "Table Type", DataField = "TableType", Visibility = Visibility.Visible, IsReadOnly = false, StyleKey = "TableTypeStyle"},
            new Column {Type = "TextBox", Header = "Table Rate", DataField = "TableRate", Visibility = Visibility.Visible, IsReadOnly = true, Width = 80},
            new Column {Type = "TextBox", Header = "Status", DataField = "TableStatus", Visibility = Visibility.Visible, IsReadOnly = true, StyleKey = "TableStatusStyle" , Width = 90}
        };

        private RelayCommand _refreshTablesListCommand;
        private ObservableCollection<TableToView> _tablesListToView;
        private List<TableType> _tableTypesList;

        public TablesListViewModel()
        {
            _tablesListToView = DatabaseHelpers.GetTablesList();
            _tableTypesList = DatabaseHelpers.GetTablesTypesList();
        }

        public List<string> TableTypesNamesList => (from type in _tableTypesList select type.TypeName).ToList();
        public ObservableCollection<Column> AvailableListedColumns => _availableColumns;

        public ObservableCollection<Column> SelectedColumns
        {
            get => _availableColumns;
            set
            {
                _availableColumns = value;
                NotifyPropertyChanged("SelectedColumns");
            }
        }

        public ObservableCollection<TableToView> TablesListToView
        {
            get => _tablesListToView;
            private set
            {
                _tablesListToView = value;
                NotifyPropertyChanged("TablesListToView");
            }
        }

        public RelayCommand RefreshTablesListCommand
        {
            get
            {
                return _refreshTablesListCommand ?? (_refreshTablesListCommand = new RelayCommand(obj =>
                {
                    TablesListToView = DatabaseHelpers.GetTablesList();
                }));
            }
        }

        public void SetColumnVisibility(IEnumerable<string> selectedItems)
        {
            foreach (var column in _availableColumns)
            {
                var selectedItemsEnumerable = selectedItems as string[] ?? selectedItems.ToArray();
                if (selectedItemsEnumerable.Contains(column.Header))
                    column.Visibility = Visibility.Visible;
                else if (!selectedItemsEnumerable.Contains(column.Header)) column.Visibility = Visibility.Hidden;
            }
            NotifyPropertyChanged("SelectedColumnNumbers");
        }
    }

    public class Column : ModelsBase
    {
        private Visibility _visibility;
        public DataTemplate CellTemplate { get; set; }
        public int Width = 100;
        public string Header { get; set; }
        public string StyleKey { get; set; }
        public string DataField { get; set; }
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                NotifyPropertyChanged("Visibility");
            }
        }
        public string Type { get; set; }
        public bool IsReadOnly { get; set; }
    }
}