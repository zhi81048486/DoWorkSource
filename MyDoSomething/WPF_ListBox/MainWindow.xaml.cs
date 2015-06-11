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

namespace WPF_ListBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool ReturnResult = default(bool);
        private ListCollectionView listboxView;
        public LBSource SelectedAccount { get;  set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
          this.Button_Cancel.Click += Button_Cancel_Click;
            this.Button_Sure.Click += Button_Sure_Click;
            this.Button_Search.Click += Button_Search_Click;
            this.AccountBox.SelectionChanged += AccountBox_SelectionChanged;
            this.Loaded += SelectAccount_Loaded;

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AccountBox.ItemsSource = GetSource();
            listboxView = (ListCollectionView)CollectionViewSource.GetDefaultView(this.AccountBox.ItemsSource);

        }

        void AccountBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAccount = AccountBox.SelectedItem as LBSource;
        }

        void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            listboxView.Filter = (item) =>
            {
                LBSource IItem = item as LBSource;
                if (IItem.AccountName.Contains(TextBox_Search.Text.Trim()))
                    return true;
                else
                {
                    return false;
                }
            };
        }

        void SelectAccount_Loaded(object sender, RoutedEventArgs e)
        {
            listboxView = (ListCollectionView)CollectionViewSource.GetDefaultView(this.AccountBox.ItemsSource);
        }

        void Button_Sure_Click(object sender, RoutedEventArgs e)
        {
            ReturnResult = true;
            this.Close();
        }

        void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            ReturnResult = false;
            this.Close();
        }
        private List<LBSource> listsource;
        List<LBSource> GetSource()
        {
           listsource = new List<LBSource>();
            for (int i = 0; i < 100; i++)
            {
                listsource.Add(new LBSource() { AccountName = "Name" + i, Country = "China" + i });

            }
            return listsource;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(e.OriginalSource as Button);
            while (!(parent is ListBoxItem))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            if (parent != null)
                SelectedAccount = ((ListBoxItem) parent).Content as LBSource;
        }
    }

    public class LBSource
    {
        public string AccountName { get; set; }
        public string Country { get; set; }
    }
}
