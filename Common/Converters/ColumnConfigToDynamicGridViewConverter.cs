using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.Common.Converters
{
    internal class ColumnConfigToDynamicGridViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var config = value as ObservableCollection<Column>;
            if (config != null)
            {
                var gridView = new GridView();
                foreach (var column in config)
                {
                    var binding = new Binding(column.DataField);
                    gridView.Columns.Add(new GridViewColumn { Header = column.Header, DisplayMemberBinding = binding , Width = column.Width});
                }
                return gridView;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
