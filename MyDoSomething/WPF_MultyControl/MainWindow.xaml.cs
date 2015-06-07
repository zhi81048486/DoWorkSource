using System;
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

        private TextCloseAdorner t;
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

    public class TextCloseAdorner : Adorner
    {
        public string Str_Tips { get; set; }
        private UIElement adorElement { get; set; }

        public TextCloseAdorner(string str, UIElement adornerElement)
            : base(adornerElement)
        {
            Rect r=new Rect();
            
            Str_Tips = str;
            adorElement = adornerElement;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            adorElement.Focus();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
           

            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);

            // Draw a circle at each corner.
            drawingContext.DrawRectangle(Brushes.Gray,renderPen,new Rect(0,0,80,25));

             drawingContext.DrawText(new FormattedText(Str_Tips, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,new Typeface("Verdana"), 12, System.Windows.Media.Brushes.Red), new System.Windows.Point(10, 10));
             drawingContext.DrawGeometry(Brushes.LightGray, new Pen(Brushes.Red, 1.0), GetDefaultGlyph());

        }
        private Geometry GetDefaultGlyph()
        {
           
            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
            pathSegmentCollection.Add(new LineSegment(new Point(5 ,5), false));
            pathSegmentCollection.Add(new LineSegment(new Point(20, 20), false));
            pathSegmentCollection.Add(new LineSegment(new Point(20, 20), false));
            pathSegmentCollection.Add(new LineSegment(new Point(5, 20), false));

            PathFigure pathFigure = new PathFigure(
                new Point(10, 10),
                pathSegmentCollection,
                true);

            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            PathGeometry pathGeometry = new PathGeometry(pathFigureCollection);
            return pathGeometry;
        }

    }




}
