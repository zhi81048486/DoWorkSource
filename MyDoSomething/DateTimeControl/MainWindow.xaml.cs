using System;
using System.Collections.Generic;
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

namespace DateTimeControl
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
            Button_MonthAdd.Click += Button_MonthAdd_Click;
            Button_MonthReduce.Click += Button_MonthReduce_Click;
            Combo_Monthes.SelectionChanged += Combo_Monthes_SelectionChanged;
            Combo_Years.SelectionChanged += Combo_Years_SelectionChanged;
        }
        bool fist = true;
        void Combo_Years_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fist)
            {
                fist = false;
                return;
            }
            DateTime dd = new DateTime((int)this.Combo_Years.SelectedValue, (int)this.Combo_Monthes.SelectedValue, 1);
            InitMonthDay(dd);
        }

        void Combo_Monthes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fist)
            {
                fist = false;
                return;
            }
            DateTime dd = new DateTime((int)this.Combo_Years.SelectedValue, (int)this.Combo_Monthes.SelectedValue, 1);
            InitMonthDay(dd);
        }

        void Button_MonthReduce_Click(object sender, RoutedEventArgs e)
        {
            if (currentDate.Month == 1)
            {
                Button_MonthReduce.IsEnabled = false;
                return;
            }
            DateTime dd = new DateTime(currentDate.Year, currentDate.Month - 1, 1);
            InitMonthDay(dd);
            if (currentDate.Month != 12)
                Button_MonthAdd.IsEnabled = true;
        }

        void Button_MonthAdd_Click(object sender, RoutedEventArgs e)
        {
            if (currentDate.Month == 12)
            {
                Button_MonthAdd.IsEnabled = false;
                return;
            }
            DateTime dd = new DateTime(currentDate.Year, currentDate.Month + 1, 1);

            InitMonthDay(dd);
            if (currentDate.Month != 1)
                Button_MonthReduce.IsEnabled = true;
        }
        private Label[,] _btnMonthMode = new Label[6, 7];

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DateLoading();

            List<int> years = new List<int>();
           
            for (int i = 0; i < 10; i++)
            {
                years.Add(2010+i);
            }
            Combo_Years.SelectedIndex = 5;
            Combo_Years.ItemsSource = years;
            List<int> monthes = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                monthes.Add(i+1);
            }
            Combo_Monthes.SelectedIndex = DateTime.Now.Month - 1;
            Combo_Monthes.ItemsSource = monthes;

        }

        void DateLoading()
        {
            currentDate = DateTime.Now;
            Label_Date.Content = string.Format("{0:yyyy年MM月dd日}", currentDate);
            for (int i = 1; i <= 7; i++)
            {
                Label lbl = new Label();
                lbl.Width = 60;
                lbl.Height = 30;
                lbl.Content = ChinNum(i);
                this.WeekGrid.Children.Add(lbl);
            }
            //行
            for (int i = 0; i < 6; i++)
            {//列
                for (int j = 0; j < 7; j++)
                {
                    Label l1 = new Label();
                    l1.Style = (Style)FindResource("DateLabel");
                    l1.MouseLeftButtonDown += l1_MouseLeftButtonDown;
                    DayGrid.Children.Add(l1);
                    _btnMonthMode[i, j] = l1;
                }
            }
            InitMonthDay(DateTime.Now);
        }

        void l1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          //  Console.WriteLine(((e.Source) as Label).Content);
            currentDate = new DateTime(currentDate.Year, currentDate.Month, (int)((e.Source) as Label).Content);
            Label_Date.Content = string.Format("{0:yyyy年MM月dd日}", currentDate);

        }

        DateTime currentDate;
        void InitMonthDay(DateTime date)
        {
            currentDate = date;
            Label_Date.Content = string.Format("{0:yyyy年MM月dd日}", currentDate);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _btnMonthMode[i,j].Content = "";
                }
            }
            DateTime d = new DateTime(date.Year, date.Month, 1);
            int days = DateTime.DaysInMonth(date.Year, date.Month);
            int fstCol = 0;
            //设置周几就是第几天(因为默认周日是第一天，所以改成周一是第一天)
            switch (d.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    fstCol = 4;
                    break;
                case DayOfWeek.Monday:
                    fstCol = 0;
                    break;
                case DayOfWeek.Saturday:
                    fstCol = 5;
                    break;
                case DayOfWeek.Sunday:
                    fstCol = 6;
                    break;
                case DayOfWeek.Thursday:
                    fstCol = 3;
                    break;
                case DayOfWeek.Tuesday:
                    fstCol = 1;
                    break;
                case DayOfWeek.Wednesday:
                    fstCol = 2;
                    break;
                default:
                    break;
            }
            //k为一个月的天数的计数
            int k = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    //从每个月第一天的星期几开始往后计数
                    if (i == 0 && j < fstCol)
                        continue;
                    else
                    {
                        _btnMonthMode[i, j].Content = k;
                        k++;
                        if (k > days)
                            return;
                    }

                }
            }
        }


        string ChinNum(int i)
        {
            switch (i)
            {
                case 1:
                    return "一";
                case 2:
                    return "二";

                case 3:
                    return "三";

                case 4:
                    return "四";

                case 5:
                    return "五";

                case 6:
                    return "六";

                case 7:
                    return "日";

                default:
                    return "";

            }
        }
    }
}
