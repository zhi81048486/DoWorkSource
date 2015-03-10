using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MyControlTemplate
{
    public enum EDirectionType
    {
        Up = 0,
        Down,
        Left,
        Right
    }
    public class GridSplitterHelp : GridSplitter
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(GridSplitterHelp), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty ContentVisibleProperty = DependencyProperty.Register("ContentVisible", typeof(Visibility), typeof(GridSplitterHelp), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty DirectionTypeProperty = DependencyProperty.Register("DirectionType", typeof(EDirectionType), typeof(GridSplitterHelp), new PropertyMetadata(EDirectionType.Left));
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(GridSplitterHelp), new PropertyMetadata(true));

        public Visibility ContentVisible
        {
            get { return (Visibility)GetValue(ContentVisibleProperty); }
            set { SetValue(ContentVisibleProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public EDirectionType DirectionType
        {
            get { return (EDirectionType)GetValue(DirectionTypeProperty); }
            set { SetValue(DirectionTypeProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public event RoutedEventHandler OpenEvent;
        public event RoutedEventHandler CloseEvent;

        public GridSplitterHelp()
            : base()
        {
            if (null == this.Style)
            {
                //this.Resources = new ResourceDictionary() { Source = new Uri("/MyControlTemplate/MStyleMGridSplitter.xaml", UriKind.RelativeOrAbsolute) };
                //object style = this.FindResource("MGridSplitterStyle");
                //if (style is Style)
                //    this.Style = style as Style;
            }
            this.Loaded += MGridSplitter_Loaded;
        }
        private bool isLoad;
        void MGridSplitter_Loaded(object sender, RoutedEventArgs e)
        {
            if (isLoad)
                return;
            CheckBox b = (CheckBox)this.Template.FindName("CheckBox_Splitter", this);
            if (b != null && !isLoad)
            {
                this.isLoad = true;
                b.Checked += b_Checked;
                b.Unchecked += b_Unchecked;
                b.IsChecked = this.IsChecked;
            }
        }

        void b_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ContentVisible = System.Windows.Visibility.Collapsed;
            if (null != this.CloseEvent)
                this.CloseEvent(sender, e);
        }

        void b_Checked(object sender, RoutedEventArgs e)
        {
            this.ContentVisible = System.Windows.Visibility.Visible;
            if (null != this.OpenEvent)
                this.OpenEvent(sender, e);
        }

    }

    public class GridWidthToVisiblityConvertRight : IValueConverter
    {
        GridLength open = new GridLength(320);
        GridLength close = new GridLength(20);
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (null != value && value.GetType() == typeof(GridLength))
            {
                GridLength v = (GridLength)value;
                if (v.Value > 0)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null != value && value.GetType() == typeof(Visibility))
            {
                Visibility b = (Visibility)value;
                if (b == Visibility.Visible)
                    return open;
                else
                    return close;
            }
            return close;
        }
    }
}

