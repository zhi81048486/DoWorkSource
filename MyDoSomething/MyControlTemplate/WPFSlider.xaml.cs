using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// WPFSlider.xaml 的交互逻辑
    /// </summary>
    public partial class WPFSlider : Window
    {
        List<string> liststr=new List<string>();
        
        public WPFSlider()
        {
            InitializeComponent();
            liststr.Add("hello");
            liststr.Add("hello1");
        }
        List<string> strs=new List<string>();
        void add(string str)
        {
            strs.Add(str);
        }

        void ok()
        {
            liststr = strs;
        }

        private void Button_Add_OnClick(object sender, RoutedEventArgs e)
        {
           add(TextBoxAdd.Text);
        }

        private void Button_OK_OnClick(object sender, RoutedEventArgs e)
        {
            ok();
        }
    }
}
