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
        private static Dictionary<string, Color> statusColorsMap = new Dictionary<string, Color>
        {
            { "DefaultStatus", Color.FromArgb(50,255,0,0) },
            { "Status1", Color.FromArgb(50,0,255,0) },
            { "Status2", Color.FromArgb(50,0,0,255) }
        };
        private ObservableCollection<Column> _availableColumns = new ObservableCollection<Column>
        {
            new Column {Order = 0, Header = "Table Name", DataField = "TableName", Visibility = true, CellTemplate = GridCellDataTemplates.TableNameCellDataTemplate("TableName")},
            new Column {Order = 1, Header = "Table Type", DataField = "TableType", Visibility = true, CellTemplate = GridCellDataTemplates.TableTypeCellDataTemplate(DatabaseHelpers.GetTablesTypesList(), "TableType")},
            new Column {Order = 2, Header = "Table Rate", DataField = "TableRate", Visibility = true, Width = 80},
            new Column {Order = 3, Header = "Status", DataField = "TableStatus", Visibility = true, Width = 90, CellTemplate = GridCellDataTemplates.TableStatusCellDataTemplate(statusColorsMap, "TableStatus")}
        };

        private StringBuilder _columnNumbers;
        private RelayCommand _refreshTablesListCommand;
        private ObservableCollection<TableToView> _tablesListToView;

        public TablesListViewModel()
        {
            _tablesListToView = DatabaseHelpers.GetTablesList();
            _columnNumbers = new StringBuilder(CalculateColumnNumbers());
        }

        public string SelectedColumnNumbers => _columnNumbers.ToString();

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

        private string CalculateColumnNumbers()
        {
            _columnNumbers = new StringBuilder();
            foreach (var column in _availableColumns)
            {
                if (column.Visibility) continue;
                _columnNumbers.Append(_availableColumns.IndexOf(column));
                _columnNumbers.Append(",");
            }

            return _columnNumbers.ToString().TrimEnd(',');
        }

        public void SetColumnVisibility(IEnumerable<string> selectedItems)
        {
            foreach (var column in _availableColumns)
            {
                var selectedItemsEnumerable = selectedItems as string[] ?? selectedItems.ToArray();
                if (selectedItemsEnumerable.Contains(column.Header))
                    column.Visibility = true;
                else if (!selectedItemsEnumerable.Contains(column.Header)) column.Visibility = false;
            }

            _columnNumbers = new StringBuilder(CalculateColumnNumbers());
            NotifyPropertyChanged("SelectedColumnNumbers");
        }
    }

    public class Column
    {
        public DataTemplate CellTemplate { get; set; }
        public int Width = 100;
        public int Order { get; set; }
        public string Header { get; set; }
        public string DataField { get; set; }
        public bool Visibility { get; set; }
    }
}