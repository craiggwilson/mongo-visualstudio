using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MongoDB.VisualStudio.Explorer
{
    public class ThicknessIndentationValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var t1 = (Thickness)values[0];
            var depth = (int)values[1];
            var multiplier = int.Parse((string)parameter);

            return new Thickness(t1.Left + (multiplier * depth), t1.Top, t1.Right, t1.Bottom);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}