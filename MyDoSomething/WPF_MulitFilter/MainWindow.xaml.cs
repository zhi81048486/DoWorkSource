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

        private CollectionView CVS;
        private ObservableCollection<Persons> lists;
        private List<Persons> DonePersons = new List<Persons>();
        private List<SearchCondition> searchs;
        void DoSource()
        {
            lists = new ObservableCollection<Persons>()
            {
                new Persons(){Name = "Llly",Age="23",Country = "USA",Sex="Girl"},
                new Persons(){Name = "Tom",Age="23",Country = "USA",Sex="Girl"},
                new Persons(){Name = "Josn",Age="13",Country = "Mexico",Sex="Girl"},
                new Persons(){Name = "James",Age="63",Country = "Canada",Sex="Boy"},
                new Persons(){Name = "Joe",Age="23",Country = "Canada",Sex="Boy"},
                new Persons(){Name = "Han",Age="18",Country = "Japan",Sex="Boy"},
                new Persons(){Name = "Lin",Age="15",Country = "England",Sex="Girl"},
                new Persons(){Name = "Den",Age="26",Country = "China",Sex="Girl"},
                new Persons(){Name = "Sun",Age="24",Country = "China",Sex="Boy"},
            };
            CVS = (CollectionView)CollectionViewSource.GetDefaultView(lists);
            //ListView_Filter.ItemsSource = CVS;
            
            Binding binding = new Binding();
            binding.Source = CVS;
            BindingOperations.SetBinding(ListView_Filter, ListView.ItemsSourceProperty, binding);

            ComboBox_Name.ItemsSource = from r in lists select r.Name;
            ComboBox_Age.ItemsSource = from r in lists select r.Age;
            ComboBox_Country.ItemsSource = from r in lists select r.Country;
            ComboBox_Sex.ItemsSource = from r in lists select r.Sex;
            ComboBox_Age.SelectionChanged += ComboBox_Age_SelectionChanged;
            ComboBox_Name.SelectionChanged += ComboBox_Name_SelectionChanged;
            ComboBox_Country.SelectionChanged += ComboBox_Country_SelectionChanged;
            isLoad = true;
            searchs=new List<SearchCondition>();
        }

        private bool isLoad = false;
        void ComboBox_Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Persons> Coun;
            var _country = ComboBox_Country.SelectedItem;
            if (!isLoad)
            { Coun = from i in DonePersons where i.Country == _country select i; }
            else
            {
                Coun = from i in lists where i.Country == _country select i;
                var id=from i in lists where !(i.Country.Contains(_country.ToString())) select i;
            }
            CVS.Filter += (p) =>
            {
                foreach (var c in Coun)
                {
                    if (((Persons)p).Country.Equals(c.Country))
                        return true;
                    else
                    {
                        return false;
                    }
                }
                return false;
            };
            DonePersons = Coun.ToList();
            isLoad = false;
        }

        void ComboBox_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var r = ComboBox_Name.SelectedItem;

        }

        void ComboBox_Age_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Persons> items;
            var _age = ComboBox_Age.SelectedItem;
            if (!isLoad)
            {
                items = from i in DonePersons where i.Age == _age select i;
            }
            else
            {
                items= from i in lists where i.Age == _age select i;
                
            }
            CVS.Filter += (p) =>
            {
                foreach (var i in items)
                {
                    if (((Persons)p).Age.Equals(i.Age))
                        return true;
                    else
                    {
                        return false;
                    }
                }
                return false;

            };
            DonePersons = items.ToList();
            isLoad = false;
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

    public class SearchCondition
    {
        public string ConditionType { get; set; }
        public string SearchValue { get; set; }
        public string SearchType { get; set; }
    }
}
