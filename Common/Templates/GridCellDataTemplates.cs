using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using WpfPracticalProject.Common.Helpers;
using WpfPracticalProject.Models;

namespace WpfPracticalProject.Common.Templates
{
    public static class GridCellDataTemplates
    {
        public static DataTemplate TableTypeCellDataTemplate(IEnumerable<TableType> tableTypes, string bindedProperty)
        {
            var dataTemplateToReturn = new DataTemplate();
            var comboBoxFactory = new FrameworkElementFactory(typeof(ComboBox));
            comboBoxFactory.SetValue(ItemsControl.ItemsSourceProperty,
                tableTypes.Select(element => element.TypeName).ToList());
            comboBoxFactory.SetBinding(Selector.SelectedItemProperty, new Binding
            {
                Path = new PropertyPath(bindedProperty),
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
            dataTemplateToReturn.VisualTree = comboBoxFactory;
            return dataTemplateToReturn;
        }

        public static DataTemplate TableNameCellDataTemplate(string bindedProperty)
        {
            var dataTemplateToReturn = new DataTemplate();
            var textBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            textBoxFactory.SetBinding(TextBox.TextProperty, new Binding(bindedProperty));
            dataTemplateToReturn.VisualTree = textBoxFactory;
            return dataTemplateToReturn;
        }

        public static DataTemplate TableStatusCellDataTemplate(Dictionary<string, Color> statusColorsMap, string bindedProperty)
        {
            var dataTemplateToReturn = new DataTemplate();
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            var textBlockStyle = new Style();
            foreach (var statusColor in statusColorsMap)
            {
                var statusColorTrigger = new DataTrigger
                {
                    Binding = new Binding(bindedProperty),
                    Value = statusColor.Key
                };
                var statusBackgroundColorSetter = new Setter
                {
                    Property = TextBlock.BackgroundProperty,
                    Value = new SolidColorBrush(statusColor.Value)
                };
                statusColorTrigger.Setters.Add(statusBackgroundColorSetter);
                textBlockStyle.Triggers.Add(statusColorTrigger);
            }

            textBlockFactory.SetValue(FrameworkElement.StyleProperty, textBlockStyle);
            textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(bindedProperty));
            dataTemplateToReturn.VisualTree = textBlockFactory;
            return dataTemplateToReturn;
        }
    }
}