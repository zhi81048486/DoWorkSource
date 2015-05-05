using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_MulitFilter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoSource();
            //this.DataContext = lists;
            this.Button_Add.Click += Button_Add_Click;
        }

        void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddPerson();
            Console.WriteLine(this.ListView_Filter.Items.Count);
        }

        private CollectionViewSource CVS;
        private ObservableCollection<Persons> lists;
        void DoSource()
        {
            lists = new ObservableCollection<Persons>()
            {
                new Persons(){Name = "Llly",Age="53",Country = "USA",Sex="Girl"},
                new Persons(){Name = "Tom",Age="23",Country = "USA",Sex="Girl"},
                new Persons(){Name = "Josn",Age="13",Country = "Mexico",Sex="Girl"},
                new Persons(){Name = "James",Age="63",Country = "Canada",Sex="Boy"},
                new Persons(){Name = "Joe",Age="20",Country = "Canada",Sex="Boy"},
                new Persons(){Name = "Han",Age="18",Country = "Japan",Sex="Boy"},
                new Persons(){Name = "Lin",Age="15",Country = "England",Sex="Girl"},
                new Persons(){Name = "Den",Age="26",Country = "China",Sex="Girl"},
                new Persons(){Name = "Sun",Age="24",Country = "China",Sex="Boy"},
            };
            CVS = new CollectionViewSource() { Source = lists };
            //ListView_Filter.ItemsSource = CVS;
            lists.Contains(new Persons());

            Binding binding = new Binding();
            binding.Source = CVS;
            BindingOperations.SetBinding(ListView_Filter, ListView.ItemsSourceProperty, binding);
        }

        void AddPerson()
        {
            lists.Add(new Persons() { Name = "New Name", Country = "New Country", Age = "22", Sex = "Girl" });
        }
    }

    public class Persons
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string Sex { get; set; }
    }
}
