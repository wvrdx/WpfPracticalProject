using System.Windows.Controls;
using WpfPracticalProject.Models;
using WpfPracticalProject.ViewModels;

namespace WpfPracticalProject.UserControls
{
    /// <summary>
    /// Interaction logic for TableParametersUserControl.xaml
    /// </summary>
    public partial class TableParametersUserControl : UserControl
    {
        public TableParametersUserControl()
        {
            InitializeComponent();
            DataContext = new TableParametersViewModel();
        }
    }
}
