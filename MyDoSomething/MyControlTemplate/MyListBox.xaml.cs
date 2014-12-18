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
    /// MyListBox.xaml 的交互逻辑
    /// </summary>
    public partial class MyListBox : Window
    {
        public MyListBox()
        {
            InitializeComponent();
            GetSource();
            this.MyLb.ItemsSource = ListSour;
        }

        List<Person> ListSour=new List<Person>();
        void GetSource()
        {
            for (int i = 0; i < 50; i++)
            {
                Person p = new Person() {Name = "Lily", Age = i};
                ListSour.Add(p);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

