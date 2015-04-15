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
    /// WPFButton.xaml 的交互逻辑
    /// </summary>
    public partial class WPFButton : Window
    {
        public WPFButton()
        {
            InitializeComponent();
        }

        private void MyRepeatButton_OnClick(object sender, RoutedEventArgs e)
        {
            Int32 Num = Convert.ToInt32(MyTextBox.Text);

            MyTextBox.Text = ((Num + 1).ToString());
        }
    }
}
