using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfPracticalProject.Common.Behaviors
{
    public static class ListViewHelper
    {
        public static readonly DependencyProperty HideColumnsProperty =
            DependencyProperty.RegisterAttached("HideColumns", typeof(string), typeof(ListViewHelper),
                new FrameworkPropertyMetadata(HideColumnsChangedCallback));

        public static string GetHideColumns(UIElement element)
        {
            return (string) element.GetValue(HideColumnsProperty);
        }

        public static void SetHideColumns(UIElement element, string value)
        {
            element.SetValue(HideColumnsProperty, value);
        }

        private static void HideColumnsChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            List<GridViewColumn> columnsCache = null;
            var listView = (ListView) sender;
            var gridView = (GridView) listView.View;
            if (listView.Tag == null)
            {
                columnsCache = gridView.Columns.ToList();
                listView.Tag = columnsCache;
            }
            else
            {
                columnsCache = (List<GridViewColumn>) listView.Tag;
            }

            gridView.Columns.Clear();
            foreach (var column in columnsCache) gridView.Columns.Add(column);
            var newColumnsToHide = (string) args.NewValue;
            var columnToDeleteList = new List<GridViewColumn>();
            foreach (var singleString in newColumnsToHide.Split(','))
                if (int.TryParse(singleString, out var columnToHide))
                    columnToDeleteList.Add(gridView.Columns[columnToHide]);
            columnToDeleteList.ForEach(item => gridView.Columns.Remove(item));
        }
    }
}