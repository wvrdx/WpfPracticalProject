using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfPracticalProject.Common.Behaviors
{
    public static class ListViewBehavior
    {
        public static readonly DependencyProperty HideColumnsProperty = DependencyProperty.RegisterAttached("HideColumns", typeof(string), typeof(ListViewBehavior), new FrameworkPropertyMetadata(HideColumnsChangedCallback));

        public static string GetHideColumns(UIElement element)
        {
            return (string)element.GetValue(HideColumnsProperty);
        }

        public static void SetHideColumns(UIElement element, string value)
        {
            element.SetValue(HideColumnsProperty, value);
        }

        private static void HideColumnsChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            List<GridViewColumn> columnsCache = null;
            ListView lv = (ListView)sender;
            GridView gv = (GridView)lv.View;
            if (lv.Tag == null)
            {
                columnsCache = new List<GridViewColumn>();
                foreach (GridViewColumn col in gv.Columns)
                {
                    columnsCache.Add(col);
                }
                lv.Tag = columnsCache;
            }
            else
            {
                columnsCache = (List<GridViewColumn>)lv.Tag;
            }
            gv.Columns.Clear();
            foreach (GridViewColumn cl in columnsCache)
            {
                gv.Columns.Add(cl);
            }
            string newColumnsToHide = (string)args.NewValue;
            List<GridViewColumn> columntoDeleteList = new List<GridViewColumn>();
            foreach (string s in newColumnsToHide.Split(','))
            {
                int columnToHide;
                if (int.TryParse(s, out columnToHide))
                {
                    columntoDeleteList.Add(gv.Columns[columnToHide]);
                }
            }
            columntoDeleteList.ForEach(w => gv.Columns.Remove(w));
        }
    }
}
