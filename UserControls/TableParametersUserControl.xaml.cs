using System.Windows.Controls;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.UserControls
{
    /// <summary>
    ///     Interaction logic for TableParametersUserControl.xaml
    /// </summary>
    public partial class TableParametersUserControl : UserControl
    {
        public TableParametersUserControl()
        {
            InitializeComponent();
            var vm = new TableParametersViewModel();
            DataContext = vm;
        }
    }
}