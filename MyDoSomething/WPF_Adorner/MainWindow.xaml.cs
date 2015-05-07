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

        void MyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MyTextBox.Text.Trim()))
            {
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(MyTextBox);
                layer.Add(new TextBoxTipAdorner("请输入", MyTextBox));
                //使得AdornerLayer可以获取焦点
                layer.Focusable = true;
            }
        }
        private class TextBoxTipAdorner : Adorner
        {
            public string Str_Tips { get; set; }

            public TextBoxTipAdorner(string str, UIElement adornerElement)
                : base(adornerElement)
            {
                Str_Tips = str;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                drawingContext.DrawText(
      new FormattedText(Str_Tips,
         CultureInfo.GetCultureInfo("en-us"),
         FlowDirection.LeftToRight,
         new Typeface("Verdana"),
         12, System.Windows.Media.Brushes.Red),
         new System.Windows.Point(10, 10));


            }

        }
    }


}
