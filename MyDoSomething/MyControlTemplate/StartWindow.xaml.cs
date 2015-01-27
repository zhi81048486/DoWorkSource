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
using System.Windows.Shapes;

namespace MyControlTemplate
{
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ControlInfo ci = new ControlInfo();
            ci.ShowDialog();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ListViewTest lvt = new ListViewTest(); lvt.ShowDialog();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            ListVIewTest2 lvt2 = new ListVIewTest2(); lvt2.ShowDialog();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            MyListBox lb = new MyListBox(); lb.ShowDialog();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            MyTabControl tc = new MyTabControl(); tc.ShowDialog();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            ListViewHeaderFilter lvhf = new ListViewHeaderFilter(); lvhf.ShowDialog();
        }
    }
}
