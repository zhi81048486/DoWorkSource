using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MouseButtonEvent
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Button2.AddHandler(Button.MouseUpEvent, new MouseButtonEventHandler(Button2_MouseUp), true);

        }    
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button2.Clicked");
        }

        private void Button2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Button2.MouseUp");
        }
        private void AddButton2_MouseUp(object sender,RoutedEventArgs e)
        {
            MessageBox.Show("Add Button2.MouseUP");
        }

        private void Button2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Preview Event");
        }

        private void textBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("TextBox_Double");
            e.Handled = false;
        }

        private void btnGo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Button_Double");
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ButtonClicked");
        }
    }
}
