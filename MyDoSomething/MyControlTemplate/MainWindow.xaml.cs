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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyControlTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public CheckBox AllCheckBox { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.MyListView.ItemsSource = DoSource();
        }
        List<ListSource> DoSource()
        {
            List<ListSource>List_S=new List<ListSource>();
            for (int i = 0; i < 1000; i++)
			{
                ListSource s = new ListSource() { First = "First" + i.ToString(), Second = "Second" + i.ToString(), Third = "Third" + i.ToString(), Forth = "Forth" + i.ToString(), Firth = "Firth" + i.ToString(), Sixth = "Sixth" + i.ToString() };
                 List_S.Add(s);
			}
            return List_S;
        }

        private void CheckBox_All_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            if (cbox.IsChecked.Value==true)
            {
                this.MyListView.SelectAll();
                Console.WriteLine("Checked");
            }
            else
            {
                this.MyListView.UnselectAll();
                Console.WriteLine("UnChecked");
            }
        }

        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("SelectionChanged");
            int SelectedNum= this.MyListView.SelectedItems.Count;
            int AllNum = this.MyListView.Items.Count;
            if (SelectedNum == AllNum)
                AllCheckBox.IsChecked = true;
            else if (SelectedNum == 0)
                AllCheckBox.IsChecked = false;
            else
                AllCheckBox.IsChecked = null;
        }

        private void CheckBox_All_Loaded(object sender, RoutedEventArgs e)
        {            
            AllCheckBox = sender as CheckBox;
        }
    }
    public class ListSource
    {
        public string First{get;set;}
        public string Second{get;set;}
        public string Third{get;set;}
        public string Forth{get;set;}
        public string Firth{get;set;}
        public string Sixth{get;set;}
    }
}
