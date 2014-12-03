using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace MyControlTemplate
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ListSource> List_S;

        public MainWindow()
        {
            InitializeComponent();
            MyListView.ItemsSource = DoSource();
        }

        public CheckBox AllCheckBox { get; set; }

        private IEnumerable<ListSource> DoSource()
        {
            List_S = new List<ListSource>();
            for (int i = 0; i < 1000; i++)
            {
                var s = new ListSource
                {
                    First = "First" + i,
                    Second = "Second" + i,
                    Third = "Third" + i,
                    Forth = "Forth" + i,
                    Firth = "Firth" + i,
                    Sixth = string.Format("Sixth{0}", i)
                };
                List_S.Add(s);
            }
            return List_S;
        }

        private void CheckBox_All_Click(object sender, RoutedEventArgs e)
        {
            var cbox = sender as CheckBox;
            if (cbox.IsChecked.Value)
            {
                MyListView.SelectAll();
                Console.WriteLine("Checked");
            }
            else
            {
                MyListView.UnselectAll();
                Console.WriteLine("UnChecked");
            }
        }

        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("SelectionChanged");
            int SelectedNum = MyListView.SelectedItems.Count;
            int AllNum = MyListView.Items.Count;
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


        private void SortMethod(string SHeader)
        {
            var SortView = (CollectionView) CollectionViewSource.GetDefaultView(MyListView.ItemsSource);
            SortView.SortDescriptions.Clear();
            SortView.SortDescriptions.Add(new SortDescription(SHeader, ListSortDirection.Ascending));
            // SortView.Refresh();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //SortMethod();
        }

        private void MyListView_Click(object sender, RoutedEventArgs e)
        {
            var HeaderInfo = e.OriginalSource as GridViewColumnHeader;
            try
            {
                Console.WriteLine(HeaderInfo.ToString());

                if (HeaderInfo.Role != GridViewColumnHeaderRole.Padding)
                {
//这条语句对第一列就是First的写法不管用。
                    // string strHeader = HeaderInfo.Column.Header.ToString(); 
                    string strHeader = HeaderInfo.Content.ToString();
                    SortMethod(strHeader);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }

    public class ListSource
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Forth { get; set; }
        public string Firth { get; set; }
        public string Sixth { get; set; }
    }
}