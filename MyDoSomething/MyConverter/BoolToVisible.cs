using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;

namespace MyConverter
{
    public class BoolToVisible : IValueConverter
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


    public class BoolToCollapsed : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                if (b)
                    return System.Windows.Visibility.Collapsed;
                else
                    return System.Windows.Visibility.Visible;
            }
            return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(System.Windows.Visibility))
            {
                System.Windows.Visibility v = (System.Windows.Visibility)value;
                if (v == System.Windows.Visibility.Visible)
                    return false;
                else
                    return true;
            }
            return true;
        }
    }

    public class BoolToMargin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                if (b)
                    return new Thickness(0, 0, 30, 0);
                else
                    return new Thickness(-3000, 0, 0, 0);
            }
            return System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
    public class BoolToReverseConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                return !b;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                return !b;
            }
            return false;
        }
    }

    public class BoolToBackgroundConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(bool))
            {
                bool b = (bool)value;
                if (b)
                 return   Brushes.Pink;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           return  null;
        }
    }

    public class VisibilityToReverseConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(Visibility))
            {
                Visibility visib = (Visibility)value;
                Visibility result = visib == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                return result;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}
