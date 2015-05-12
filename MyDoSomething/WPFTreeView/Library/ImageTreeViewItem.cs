using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPFTreeView.Library
{
    public class ImageTreeViewItem : TreeViewItem
    {
        public string Image_Path { get; set; }
        public string StrHeader { get; set; }

        public ImageTreeViewItem(string header, string imagePath)
        {
            StrHeader = header;
            Image_Path = imagePath;
            CreateTreeViewItem();
        }

        private void CreateTreeViewItem()
        {
            StackPanel stackPanel=new StackPanel(){Orientation = Orientation.Horizontal};
            Image image=new Image(){Source = new BitmapImage(new Uri("pack://application:,,/Resources/" +Image_Path))};
            TextBlock tBlock=new TextBlock(){Text = StrHeader};
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(tBlock);
            this.Header = stackPanel;
        }
    }
}
