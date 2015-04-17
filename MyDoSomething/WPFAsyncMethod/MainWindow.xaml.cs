using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WPFAsyncMethod
{

    public delegate string DownLoadDel(string url);
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TextBoxURL.Text = "http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe";
            ButtonDown.Click += ButtonDown_Click;
        }

        void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxURL.Text.Trim()))
            {
                MessageBox.Show("URL can't be null!");
                return;
            }
            ButtonDown.Content = "Downloading";
            DownLoadDel downMethod = DoDownLoad;
            downMethod.BeginInvoke(TextBoxURL.Text, CallBack, downMethod);

        }

        private string DoDownLoad(string url)
        {
            string str = "";
            return str;
        }

        private void CallBack(IAsyncResult asy)
        {

        }
    }
}
