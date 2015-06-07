using System;
using System.Collections.Generic;
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

namespace WPF_Brush
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Label1.Background=new SolidColorBrush(SystemColors.GradientActiveCaptionColor);
            Label1.Background = new SolidColorBrush(Colors.OrangeRed);
            Label1.Background = SystemColors.ControlBrush;
            byte red = 10;
            byte green = 245;
            byte blue = 50;
            Label1.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
            //Argb设置颜色透明度，其中第一个参数是设置透明度的，255表示完全不透明，0表示完全透明
            Label1.Background = new SolidColorBrush(Color.FromArgb(255, red, green, blue));
        }

       
    }
}
