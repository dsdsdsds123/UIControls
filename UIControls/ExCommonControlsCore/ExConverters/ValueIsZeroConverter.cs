using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ExCommonControlsCore.ExConverters
{
    public class ValueIsZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return CornerRadiusIsZero(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool CornerRadiusIsZero(object value)
        {
            if (value != null && value.ToString() == "System.Windows.CornerRadius")
            {
                CornerRadius r = (CornerRadius)value;
                return r.TopLeft == 0 && r.TopRight == 0 && r.BottomLeft == 0 && r.BottomRight == 0;
            }
            return false;
        }

    }
}
