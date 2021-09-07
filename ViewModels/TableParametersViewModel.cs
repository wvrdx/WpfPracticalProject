using System.Windows.Media;
using WpfPracticalProject.Common;

namespace WpfPracticalProject.ViewModels
{
    public class TableParametersViewModel : ViewModelBase
    {
        public TableParametersViewModel()
        {
            StarShapedButtonStyleColours = new GradientStopCollection
            {
                new GradientStop(Colors.Red, 0.0),
                new GradientStop(Colors.Green, 0.5),
                new GradientStop(Colors.Blue, 1.0)
            };
        }

        public GradientStopCollection StarShapedButtonStyleColours { get; set; }
    }
}