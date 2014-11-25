using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyDragDrop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MySource> ms = new ObservableCollection<MySource>();
        public MainWindow()
        {
            InitializeComponent();
            MySource m1 = new MySource() { Finished = "First", Duration = "www", Name = "Xiao", Description = "sdsss" };
            ms.Add(m1);
            MySource m2 = new MySource() { Finished = "Second", Duration = "www", Name = "Li", Description = "such" };
            ms.Add(m2);
            MySource m3 = new MySource() { Finished = "Third", Duration = "www", Name = "Ming", Description = "little" };
            ms.Add(m3);
            MySource m4 = new MySource() { Finished = "Fourth", Duration = "www", Name = "Da", Description = "yeah" };
            ms.Add(m4);
            MySource m5 = new MySource() { Finished = "Fifth", Duration = "www", Name = "Hua", Description = "what" };
            ms.Add(m5);

            this.listView.ItemsSource = ms;

        }
        private object GetDataFromListView(ListView source, Point point)
        {
            List<Rect> ListViewRect = new List<Rect>();

            for (int i = 0; i < source.Items.Count; i++)
            {
                Rect bounds = new Rect();
                bounds.Location = new Point(0, 40 * i);
                bounds.Size = new Size(400, 40);
                ListViewRect.Add(bounds);
            }

            for (int i = 0; i < ListViewRect.Count; i++)
            {
                if (ListViewRect[i].Contains(point))
                {
                    return i;
                }

            }
            return null;
        }
        int oldIndex = -1;
        int newIndex = -1;
        DragAdorner dragAdorner;

        AdornerLayer adornerLayer;
        private void listView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListView parent = (ListView)sender;

            object data = GetDataFromListView(parent, e.GetPosition(parent));

            if (data != null)
            {
                oldIndex = int.Parse(data.ToString());
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private void listView_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                ListViewItem item = GetListViewItem(oldIndex);
                if (adornerLayer == null)
                    adornerLayer = InitializeAdornerLayer(item);
                ListView parent = (ListView)sender;
                double x = e.GetPosition(parent).X;
                double y = e.GetPosition(parent).Y;
                if (null != dragAdorner)
                    dragAdorner.SetOffsets(x, y);
            }
            catch
            {
                Console.WriteLine("Bad_DragOver");
            }
        }
        AdornerLayer InitializeAdornerLayer(ListViewItem itemToDrag)
        {
            VisualBrush brush = new VisualBrush(itemToDrag);
            // Create an element which displays the source item while it is dragged.
            this.dragAdorner = new DragAdorner(this.listView, itemToDrag.RenderSize, brush);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this.listView);
            layer.Add(dragAdorner);
            return layer;
        }

        private void ListView_Links_Drop(object sender, DragEventArgs e)
        {
            ListView parent = (ListView)sender;
            object data = GetDataFromListView(parent, e.GetPosition(parent));
            if (data != null)
            {
                newIndex = int.Parse(data.ToString());
                if (oldIndex >= 0 && newIndex >= 0)
                {
                    ms.Move(oldIndex, newIndex);
                }
                Console.WriteLine("Drop");
                if (adornerLayer != null)
                    adornerLayer.Remove(dragAdorner);
                adornerLayer = null;
            }
        }



        ListViewItem GetListViewItem(int index)
        {
            return this.listView.ItemContainerGenerator.ContainerFromIndex(index) as ListViewItem;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            try
            {
               
                Console.WriteLine("Grid_Drop");
            }
            catch
            {
                Console.WriteLine("Bad_Drop");
            }
        }

        private void listView_MouseMove(object sender, MouseEventArgs e)
        {
            if (adornerLayer != null)
                adornerLayer.Remove(dragAdorner);
            adornerLayer = null;
            Console.WriteLine("Mouse_Move");
        }
    }


    public class MySource
    {
        public string Finished { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DragAdorner : Adorner
    {
        #region Data
        private Rectangle child = null;
        private double offsetLeft = 0;
        private double offsetTop = 0;
        #endregion // Data

        #region Constructor

        /// <summary>
        /// Initializes a new instance of DragVisualAdorner.
        /// </summary>
        /// <param name="adornedElement">The element being adorned.</param>
        /// <param name="size">The size of the adorner.</param>
        /// <param name="brush">A brush to with which to paint the adorner.</param>
        public DragAdorner(UIElement adornedElement, Size size, Brush brush)
            : base(adornedElement)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = brush;
            rect.Width = size.Width;
            rect.Height = size.Height;
            rect.IsHitTestVisible = false;
            this.child = rect;
        }

        #endregion // Constructor

        #region Public Interface

        #region GetDesiredTransform

        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(this.offsetLeft, this.offsetTop));
            return result;
        }

        #endregion // GetDesiredTransform

        #region OffsetLeft

        /// <summary>
        /// Gets/sets the horizontal offset of the adorner.
        /// </summary>
        public double OffsetLeft
        {
            get { return this.offsetLeft; }
            set
            {
                this.offsetLeft = value;
                UpdateLocation();
            }
        }

        #endregion // OffsetLeft

        #region SetOffsets

        /// <summary>
        /// Updates the location of the adorner in one atomic operation.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void SetOffsets(double left, double top)
        {
            this.offsetLeft = left;
            this.offsetTop = top;
            this.UpdateLocation();
        }

        #endregion // SetOffsets

        #region OffsetTop

        /// <summary>
        /// Gets/sets the vertical offset of the adorner.
        /// </summary>
        public double OffsetTop
        {
            get { return this.offsetTop; }
            set
            {
                this.offsetTop = value;
                UpdateLocation();
            }
        }

        #endregion // OffsetTop

        #endregion // Public Interface

        #region Protected Overrides

        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            this.child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        /// <summary>
        /// Override.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            return this.child;
        }

        /// <summary>
        /// Override.  Always returns 1.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        #endregion // Protected Overrides

        #region Private Helpers

        private void UpdateLocation()
        {
            AdornerLayer adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
                adornerLayer.Update(this.AdornedElement);
        }

        #endregion // Private Helpers
    }
}
