﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace WPF_MultyControl
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += ReportManage_Loaded;
            this.ListView_Accounts.SelectionChanged += ListView_Accounts_SelectionChanged;
            this.Button_Search.Click += Button_Search_Click;
            this.TBox.SearchEvent += new RoutedEventHandler(SearchEvent_Event);

        }

        void Button_Search_Click(object sender, RoutedEventArgs e)
        {

        }
        void SearchEvent_Event(object sender, RoutedEventArgs e)
        {
            string strsearch = TBox.Text.Trim();
            // List<string> res = (from r in list where r.Contains(strsearch) select r).ToList();
            myview.Filter = (p) =>
            {
                sourceValues s = p as sourceValues;
                if (s.Name.Contains(strsearch))
                    return true;
                else
                {
                    return false;
                }
            };
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(TBox);
            //t = new TextCloseAdorner(TBox.Text.Trim(), TBox);
            //layer.Add(t);
            ListView_Accounts.Focus();
        }

        void ListView_Accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sourceValues s = ListView_Accounts.SelectedItem as sourceValues;
            if (null != s)
                Button_SelectAccount.Content = s.Name;
        }

        private ObservableCollection<sourceValues> list;
        private ListCollectionView myview;
        void ReportManage_Loaded(object sender, RoutedEventArgs e)
        {
            list = new ObservableCollection<sourceValues>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(new sourceValues() { Age = i, Name = "Account" + i });
            }
            ListView_Accounts.ItemsSource = list;
            myview = (ListCollectionView)CollectionViewSource.GetDefaultView(this.ListView_Accounts.ItemsSource);

        }
        private void TBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    string strsearch = TBox.Text.Trim();
            //    // List<string> res = (from r in list where r.Contains(strsearch) select r).ToList();
            //    myview.Filter = (p) =>
            //    {
            //        sourceValues s = p as sourceValues;
            //        if (s.Name.Contains(strsearch))
            //            return true;
            //        else
            //        {
            //            return false;
            //        }
            //    };
            //    //AdornerLayer layer = AdornerLayer.GetAdornerLayer(TBox);
            //    //t = new TextCloseAdorner(TBox.Text.Trim(), TBox);
            //    //layer.Add(t);
            //    ListView_Accounts.Focus();
            //}
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            //ListViewItem item = sender as ListViewItem;
            //sourceValues s = item.Content as sourceValues;
            //Button_SelectAccount.Content = s.Name;
        }
    }

    public class sourceValues
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
