using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Common.Converters
{
    internal class ColumnToSelectedColumnsConverter : IValueConverter
    {
        private ObservableCollection<Column> _allColumns;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnsList = value as ObservableCollection<Column>;
            _allColumns = new ObservableCollection<Column>(columnsList);
            var toReturn = new List<string>();
            toReturn.AddRange(from column in columnsList where column.Visibility select column.Header);
            return toReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnsDict = value as List<string>;
            foreach (var column in _allColumns)
            {
                if (columnsDict != null && columnsDict.Contains(column.Header))
                    _allColumns[_allColumns.IndexOf(column)].Visibility = true;
                else
                    _allColumns[_allColumns.IndexOf(column)].Visibility = false;
            }
            return _allColumns;
        }
    }
}
