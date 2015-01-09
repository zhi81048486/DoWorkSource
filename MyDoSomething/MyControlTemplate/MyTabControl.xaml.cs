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
    /// MyTabControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyTabControl : Window
    {
        public MyTabControl()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            //var item= myTabC.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(MyPWB.Password))
                {
                    MyPWB.Focus();
                }
            }
        }

        private void MyPWB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            MyPWB.Tag = (MyPWB.SecurePassword.Length == 0) ? "请输入密码" : string.Empty;
        }

        private void TabControl_Click(object sender, RoutedEventArgs e)
        {
            Button ButtonCode = e.OriginalSource as Button;
        }

    }
}
