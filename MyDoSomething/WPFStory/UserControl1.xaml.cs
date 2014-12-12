using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStory
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public event EventHandler BeginEvent;
        public event EventHandler BackEvent;

        private void Button_Begin_Click(object sender, RoutedEventArgs e)
        {
            this.MyStackPanel.Visibility = Visibility.Collapsed;
            this.PinkPanel.Visibility = Visibility.Visible;
            BeginEvent(sender, e);

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.MyStackPanel.Visibility = Visibility.Visible;
            this.PinkPanel.Visibility = Visibility.Collapsed;
            BackEvent(sender, e);
        }
    }
}
