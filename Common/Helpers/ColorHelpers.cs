using System.Windows.Media;

namespace WpfPracticalProject.Common.Helpers
{
    public static class ColorHelpers
    {
        private const int RGBMAX = 255;

        public static Color InvertColor(Color colorToInvert)
        {
            return Color.FromArgb(colorToInvert.A, (byte) (RGBMAX - colorToInvert.R),
                (byte) (RGBMAX - colorToInvert.G), (byte) (RGBMAX - colorToInvert.B));
        }
    }
}