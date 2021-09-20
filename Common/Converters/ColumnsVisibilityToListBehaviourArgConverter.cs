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
    internal class ColumnsVisibilityToListBehaviourArgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var config = value as ObservableCollection<Column>;
            if (config != null)
            {
                List<int> columnsToHide = new List<int>();
                foreach (var column in config)
                {
                    if (!column.Visibility)
                    {
                        columnsToHide.Add(config.IndexOf(column));
                    }
                }
                return columnsToHide;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
