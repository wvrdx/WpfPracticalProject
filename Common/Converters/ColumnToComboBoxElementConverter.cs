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
    internal class ColumnToComboBoxElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnsList = value as ObservableCollection<Column>;
            List<string> toReturn = new List<string>();
            if (columnsList != null)
            {
                foreach (var column in columnsList)
                {
                    toReturn.Add(column.Header);
                }
            }
            return toReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
