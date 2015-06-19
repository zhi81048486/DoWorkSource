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
    /// WPF_Graph.xaml 的交互逻辑
    /// </summary>
    public partial class WPF_Graph : UserControl
    {
        private int _columns;

        public int Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;
                chart_columns = Columns;
            }
        }

        private int _rows;
        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                chart_rows = Rows;
            }

        }
        private int chart_columns { get; set; }
        private int chart_rows { get; set; }

        public List<string> HValue { get; set; }
        public List<string> VValue { get; set; }

        /// <summary>
        /// 横坐标最大值
        /// </summary>
        public int HValue_MaxValue { get; set; }
        /// <summary>
        /// 横坐标最小值
        /// </summary>
        public int HValue_MinValue { get; set; }
        /// <summary>
        /// 水平间隔值
        /// </summary>
        public int HValue_InterValue { get; set; }

        /// <summary>
        /// 竖坐标最大值
        /// </summary>
        public int VValue_MaxValue { get; set; }
        /// <summary>
        /// 竖坐标最小值
        /// </summary>
        public int VValue_MinValue { get; set; }
        /// <summary>
        /// 竖坐标间隔值
        /// </summary>
        public int VValue_InterValue { get; set; }

        private Label[,] labels;
        public WPF_Graph()
        {
            InitializeComponent();
            if (null == VValue)
                VValue = new List<string>();
            this.Loaded += WPF_Graph_Loaded;
        }

        private double _width;
        private double _height;



        void WPF_Graph_Loaded(object sender, RoutedEventArgs e)
        {
            SetColumnsAndRows();
            GetWidthAndHeight();
            Set_HV_Value();
            LoadData();
            double h = this.ActualHeight / chart_rows;
            double w = this.ActualWidth / chart_columns;
            labels = new Label[chart_rows, chart_columns];

            ChartGrid.Rows = chart_rows;
            ChartGrid.Columns = chart_columns;
            for (int i = 0; i < chart_rows; i++)
            {
                for (int j = 0; j < chart_columns; j++)
                {
                    if (i % 2 == 0)
                    {
                        labels[i, j] = new Label()
                        {
                            Background = new SolidColorBrush(Color.FromRgb(250, 250, 250)),
                            BorderThickness = new Thickness(0.5),
                            BorderBrush = Brushes.Black
                        };
                    }
                    else
                    {
                        labels[i, j] = new Label()
                        {
                            Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                            BorderThickness = new Thickness(0.5),
                            BorderBrush = Brushes.Black
                        };
                    }

                    //if (i == chart_rows - 1 || j == 0)
                    //    labels[i, j] = new Label() { Background = Brushes.White, HorizontalContentAlignment = HorizontalAlignment.Right, VerticalContentAlignment = VerticalAlignment.Top, Padding = new Thickness(0) };
                    ChartGrid.Children.Add(labels[i, j]);

                    //if (i == chart_rows - 1)
                    //{
                    //    labels[i, j].Background = Brushes.Red;
                    //    labels[i,j].Margin=new Thickness(30,0,0,0);
                    //    labels[i, j].Content = HValue[j];
                    //}

                    //if (j == 0)
                    //{
                    //    if (i == chart_rows - 2)
                    //    {
                    //        StackPanel sp = new StackPanel();
                    //        //  sp.Background = Brushes.Red;
                    //        sp.Children.Add(new Label() { Content = VValue[i], Padding = new Thickness(0), VerticalAlignment = VerticalAlignment.Top });
                    //        sp.Children.Add(new Label() { Content = VValue[i + 1], VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(0, 10, 0, 0) });
                    //        labels[i, j].Padding = new Thickness(0);
                    //        // labels[i, j].Background = Brushes.Yellow;
                    //        labels[i, j].Content = sp;
                    //    }
                    //    else if (i == chart_rows - 1)
                    //    {

                    //    }
                    //    else
                    //        labels[i, j].Content = VValue[i];
                    //}

                }
            }



            //ChartGrid.Rows = 5;
            //ChartGrid.Columns = 7;
            //foreach (var item in labels)
            //{
            //    ChartGrid.Children.Add(item);
            //}
            //int count =  ChartGrid.Rows*ChartGrid.Columns;
            //for (int i = 0; i <count; i++)
            //{
            //  if((i/ChartGrid.Columns)%2==0)
            //    ChartGrid.Children.Add(new Label() {Background =  new SolidColorBrush(Color.FromRgb(250,250,250)) ,BorderThickness =new Thickness(0.5),BorderBrush = Brushes.Black,Width = this.ActualWidth/7,Height = this.ActualHeight/5});
            //  else
            //  {
            //      ChartGrid.Children.Add(new Label() { Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)), BorderThickness = new Thickness(0.5), BorderBrush = Brushes.Black, Width = this.ActualWidth / 7, Height = this.ActualHeight / 5 });
            //  }
            //}
            //ChartGrid.Children.Add(new Label() { Background = Brushes.Salmon, BorderThickness = new Thickness(0.5), BorderBrush = Brushes.Black, Width = this.ActualWidth / 7, Height = this.ActualHeight / 5 });
        }
        void GetWidthAndHeight()
        {
            _width = (this.ChartGrid.ActualWidth / Columns);
            _height = (this.ChartGrid.ActualHeight / Rows) - 5;
        }


        void SetColumnsAndRows()
        {
            _rows = VValue_MaxValue / VValue_InterValue;
            for (int i = Rows; i >= 0; i--)
            {
                VValue.Add(Convert.ToString(i * VValue_InterValue));
            }
        }

        void Set_HV_Value()
        {
            for (int i = 0; i <= Rows; i++)
            {
                VPanel.Children.Add(new Label() { Width = _width, Height = _height, Content = VValue[i], HorizontalContentAlignment = HorizontalAlignment.Right,Background = Brushes.Red});
            }
            for (int i = 0; i < Columns+1; i++)
            {
                HPanel.Children.Add(new Label() { Width = _width, Height = _height, Content = HValue[i], HorizontalContentAlignment = HorizontalAlignment.Right,Background = Brushes.Yellow});
            }
        }

        void LoadData()
        {
            Ellipse e = new Ellipse() { Width = 10, Height = 10, Fill = Brushes.RoyalBlue };
            Canvas.SetLeft(e, 100); Canvas.SetTop(e, 100);
            MyCanvas.Children.Add(e);
        }
    }
}
