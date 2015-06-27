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

namespace WPF_Chart
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
            dd d1 = new dd() {startDate = DateTime.Now.Date.ToString()};
            string t = d1.startDate.ToString();
        }


        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            chartview.Columns = 6;
            chartview.Rows = 5;

           chartview.HValue=new List<string>(){"周一","周二","周三","周四","周五","周六","周日"};
          //  chartview.VValue=new List<string>(){"50","40","30","20","10","0"};
            chartview.VValue_MaxValue = 50;
            chartview.VValue_InterValue = 10;
        }
    }

    public class dd
    {
        private string _startDate;
        public string startDate
        {
            get { return _startDate; }
            set { _startDate = value; chagne();}
        }

        void chagne()
        {
           _startDate= String.Format("{0:yyyy-MM-dd}", _startDate); 
        }

        private string _endDate;

        public string endDate
        {
            get { return String.Format("{0:yyyy-MM-dd}", _endDate); }
            set { _endDate = value; }
        }
    }
}
