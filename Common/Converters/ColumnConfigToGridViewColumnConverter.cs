using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Common.Converters
{
    internal class ColumnConfigToGridViewColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnsList = value as ObservableCollection<Column>;
            List<GridViewColumn> toReturn = new List<GridViewColumn>();
            if (columnsList != null)
            {
                foreach (var column in columnsList)
                {
                    GridViewColumn gc = new GridViewColumn
                    {
                        Header = column.Header,
                        DisplayMemberBinding = new Binding(column.DataField),
                        Width = column.Width
                    };
                    toReturn.Add(gc);
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
