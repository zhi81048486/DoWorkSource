using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MouseDownEvent
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ObservableCollection<string> zoneList = new ObservableCollection<string>();

        private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine((sender as FrameworkElement).Tag + " Preview");
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine((sender as FrameworkElement).Tag + " Bubble");
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ListView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("P_Down");
        }

        private void ListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("Down");
        }

        private void ListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Up");
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("P_LeftDown");
        }

        private void ListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("LeftDown");
        }


        private void test([CallerMemberName] string callerName = "")
        {

        }
    }
}
