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
            this.Loaded += MainWindow_Loaded;
            mygrid.AddHandler(Grid.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.Grid_MouseLeftButtonDown), true);
            btnGo.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.Button_MouseLeftButtonDown), true);
            textBox1.AddHandler(TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.textBox1_MouseLeftButtonDown), true);

        }
        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Grid_PreviewMouseLeftButtonDown");
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Button_PreviewMouseLeftButtonDown");
        }
        private void textBox1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("textBox1_PreviewMouseLeftButtonDown");
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Grid_MouseLeftButtonDown");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button_Click");
        }
        private void textBox1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("textBox1_MouseLeftButtonDown");
        }
        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Button_MouseLeftButtonDown");
        }
        List<Person> p1;
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
             p1= new List<Person>() { new Person() { Name = "Liy", Age = "22", Sex = "G" }, new Person() { Name = "Lucy", Age = "23", Sex = "B" } };
            //MyListView.AddHandler(ListView.MouseLeftButtonDownEvent, new MouseButtonEventHandler(MyListView_MouseLeftButtonDown), true);
             Changed(p1);
        }


        //private void MyListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("PreviewMouseLeftButtonDown");
        //}

        //private void MyListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("PreviewMouseLeftButtonUP");
        //    e.Handled = false;
        //}

        //private void MyListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("MouseLeftButtonUp");
        //}
        //private void MyListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show("MouseLeftButtonDown");
        //}

        void Changed(List<Person> listC)
        {
            List<Person> p2 = new List<Person>();
            p2 = listC;
            p2.Add(new Person() { Name = "Tom", Age = "12", Sex = "B" });
            Debug.WriteLine("p2: "+p2.Count.ToString());
            Debug.WriteLine("P1: "+p1.Count.ToString());
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
    }
}
