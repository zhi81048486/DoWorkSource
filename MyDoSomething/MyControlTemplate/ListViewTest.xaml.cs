using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private ObservableCollection<GameData> _GameCollection = new ObservableCollection<GameData>();

        private GridViewColumnHeader _CurSortCol = null;
        private SortAdorner _CurAdorner = null;

        public ListViewTest()
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

            InitializeComponent();
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
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = sender as GridViewColumnHeader;
            String field = column.Tag as String;

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
