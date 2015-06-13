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

namespace WPF_ListView
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
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.LView.ItemsSource = GetSource();
        }

        private List<LViewSource> GetSource()
        {
            List<LViewSource> lists = new List<LViewSource>();
            for (int i = 0; i < 800000; i++)
            {
                lists.Add(new LViewSource()
                {
                    Column1 = "one" + i,
                    Column2 = "two" + i,
                    Column3 = "three" + i,
                    Column4 = "four" + i,
                    Column5 = "five" + i,
                    Column6 = "six" + i,
                    Column7 = "senven" + i,
                    Column8 = "eight" + i

                });
            }
            return lists;
        }


    }

    public class LViewSource
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }

    }
}
