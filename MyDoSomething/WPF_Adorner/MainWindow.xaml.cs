using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Adorner
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyTextBox.LostFocus += MyTextBox_LostFocus;
            MyTextBox.GotFocus += MyTextBox_GotFocus;

        }

        void t_GotFocus(object sender, RoutedEventArgs e)
        {
            if (t != null)
                MyTextBox.Focus();
        }

        void MyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(MyTextBox);
            Adorner[] adorners = layer.GetAdorners(MyTextBox);
            if (adorners != null)
            {
                foreach (Adorner adorner in adorners)
                {
                    if (adorner is TextBoxTipAdorner)
                        layer.Remove(adorner);
                }
            }
        }

        private TextBoxTipAdorner t;
        void MyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MyTextBox.Text.Trim()))
            {
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(MyTextBox);
                t = new TextBoxTipAdorner("请输入", MyTextBox);
                layer.Add(t);
            }
        }

    }

    /// <summary>
    /// 带提示文字的输入框
    /// </summary>
    public class TextBoxWithTip : TextBox
    {
        public static readonly DependencyProperty TipValueProperty = DependencyProperty.Register(
            "TipValue", typeof(string), typeof(TextBoxWithTip), new PropertyMetadata(default(string)));

        public string TipValue
        {
            get { return (string)GetValue(TipValueProperty); }
            set { SetValue(TipValueProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (string.IsNullOrEmpty(this.Text.Trim()))
            {
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
                layer.Add(new TextBoxTipAdorner(TipValue, this));
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
            Adorner[] adorners = layer.GetAdorners(this);
            if (adorners != null)
            {
                foreach (Adorner adorner in adorners)
                {
                    if (adorner is TextBoxTipAdorner)
                        layer.Remove(adorner);
                }
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (string.IsNullOrEmpty(this.Text.Trim()))
            {
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
                layer.Add(new TextBoxTipAdorner(TipValue, this));
            }
        }
    }
    public class TextBoxTipAdorner : Adorner
    {
        public string Str_Tips { get; set; }
        private UIElement adorElement { get; set; }

        public TextBoxTipAdorner(string str, UIElement adornerElement)
            : base(adornerElement)
        {
            Str_Tips = str;
            adorElement = adornerElement;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            adorElement.Focus();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawText(new FormattedText(Str_Tips, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,
     new Typeface("Verdana"), 12, System.Windows.Media.Brushes.Red), new System.Windows.Point(10, 10));
        }

    }

}
