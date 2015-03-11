using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConvert
{
    public class BoolToVisible :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                if (b)
                    return System.Windows.Visibility.Visible;
                else
                    return System.Windows.Visibility.Collapsed;
            }
            return System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(System.Windows.Visibility))
            {
                System.Windows.Visibility v = (System.Windows.Visibility)value;
                if (v == System.Windows.Visibility.Visible)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
