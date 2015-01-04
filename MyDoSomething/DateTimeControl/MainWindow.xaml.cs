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
            DateTime currentDate = DateTime.Now;
            DateTime d = new DateTime(currentDate.Year, currentDate.Month, 1);
        }
        private Label[,] _btnMonthMode = new Label[6, 7];

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DateLoading();
        }

        void DateLoading()
        {
         //Label_Date.Content = string.Format("{0:yyyy年MM月dd}", DateTime.Now);

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
                    DayGrid.Children.Add(l1);
                    _btnMonthMode[i, j] = l1;

                }
            }
            InitMonthDay(DateTime.Now);
        }
        void InitMonthDay(DateTime date)
        {
            DateTime currentDate = date;
            DateTime d = new DateTime(currentDate.Year, currentDate.Month+3, 1);
            int days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month+1);
            int fstCol = (int)d.DayOfWeek;
            int k = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == 0 && j < fstCol-1)
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
