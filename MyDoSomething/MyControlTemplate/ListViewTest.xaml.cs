using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MyControlTemplate
{
    /// <summary>
    /// ListViewTest.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewTest
    {

        private readonly ObservableCollection<GameData> _GameCollection = new ObservableCollection<GameData>();
        private readonly string _str = "ddsseeff";
        private const string _conStr = "ddsseeff";
        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;
        public ObservableCollection<GameData> Mysource=new ObservableCollection<GameData>();
        public ListViewTest()
        {
           // this.Loaded += ListViewTest_Loaded;
           
           
            InitializeComponent();
        }

        void ListViewTest_Loaded(object sender, RoutedEventArgs e)
        {
            _GameCollection.Add(new GameData
            {
                GameName = "World Of Warcraft",
                Creator = "Blizzard",
                Publisher = "Blizzard"
            });
            _GameCollection.Add(new GameData
            {
                GameName = "Halo",
                Creator = "Bungie",
                Publisher = "Microsoft"
            });
            _GameCollection.Add(new GameData
            {
                GameName = "Gears Of War",
                Creator = "Epic",
                Publisher = "Microsoft"
            });
        }

        public ObservableCollection<GameData> GameCollection
        { get { return _GameCollection; } }

        private void AddRowClick(object sender, RoutedEventArgs e)
        {
            _GameCollection.Add(new GameData
            {
                GameName = "A New Game",
                Creator = "A New Creator",
                Publisher = "A New Publisher"
            });
           string sss= _str.Remove(1,2);
            string cons = _conStr.Remove(1, 2);
           // MessageBox.Show(_str);
           // MessageBox.Show(_conStr);
            MessageBox.Show(_GameCollection.Count.ToString(CultureInfo.InvariantCulture));
            // _GameCollection = Mysource;
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            // ReSharper disable SuggestUseVarKeywordEvident
            String field = column.Tag as String;
            // ReSharper restore SuggestUseVarKeywordEvident

            if (_CurSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(_CurSortCol).Remove(_CurAdorner);
                gameListView.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_CurSortCol == column && _CurAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _CurSortCol = column;
            _CurAdorner = new SortAdorner(_CurSortCol, newDir);
            AdornerLayer.GetAdornerLayer(_CurSortCol).Add(_CurAdorner);
            gameListView.Items.SortDescriptions.Add(
                new SortDescription(field, newDir));
        }
    }


    public class SortAdorner : Adorner
    {
        private readonly static Geometry _AscGeometry =
            Geometry.Parse("M 0,0 L 10,0 L 5,5 Z");
        private readonly static Geometry _DescGeometry =
            Geometry.Parse("M 0,5 L 10,5 L 5,0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        {
            Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            drawingContext.PushTransform(
                new TranslateTransform(
                  AdornedElement.RenderSize.Width - 15,
                  (AdornedElement.RenderSize.Height - 5) / 2));

            drawingContext.DrawGeometry(Brushes.Black, null,
                Direction == ListSortDirection.Ascending ? _AscGeometry : _DescGeometry);

            drawingContext.Pop();
        }





    }

    public class GameData
    {
        public string GameName { get; set; }
        public string Creator { get; set; }
        public string Publisher { get; set; }
    }



}
