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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MylistView.ItemsSource = getsou();
        }

        List<sou> getsou()
        {
            List<sou> l = new List<sou>();
            l.Add(new sou() { ff = "ffff", dd = "dddd" });
            l.Add(new sou() { ff = "ffff", dd = "dddd" }); l.Add(new sou() { ff = "ffff", dd = "dddd" }); l.Add(new sou() { ff = "ffff", dd = "dddd" }); l.Add(new sou() { ff = "ffff", dd = "dddd" });
            return l;
        }

        public class sou
        {
            public string ff { get; set; }
            public string dd { get; set; }
        }
    }
}
