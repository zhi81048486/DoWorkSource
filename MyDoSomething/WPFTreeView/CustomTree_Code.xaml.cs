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

namespace WPFTreeView
{
    /// <summary>
    /// CustomTree_Code.xaml 的交互逻辑
    /// </summary>
    public partial class CustomTree_Code : UserControl
    {
        public CustomTree_Code()
        {
            InitializeComponent();
            LoadTree();
        }
        //这其实分两步，第一步是创建一个TreeViewItem.
        //第二步是吧创建好的TreeViewItem拼接起来

        private void LoadTree()
        {
            TreeViewItem AsianItem = markTreeViewItem("亚洲", Colors.RoyalBlue);
            TreeViewItem EuropeItem = markTreeViewItem("欧洲", Colors.Pink);
            AsianItem.Items.Add(markTreeViewItem("中国", "china.png"));
            AsianItem.Items.Add(markTreeViewItem("日本", "japan.png"));
            EuropeItem.Items.Add(markTreeViewItem("英国", "uk.png"));
            EuropeItem.Items.Add(markTreeViewItem("丹麦", "denmark.png"));

            this.MainTreeView.Items.Add(AsianItem);
            this.MainTreeView.Items.Add(EuropeItem);


        }

        private TreeViewItem markTreeViewItem(string header, string imagePath)
        {
            TreeViewItem treeItem = new TreeViewItem();
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            Image image = new Image() { Source = new BitmapImage(new Uri("pack://application:,,/Resources/" + imagePath)) };
            TextBlock tBlock = new TextBlock() { Text = header };
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(tBlock);
            treeItem.Header = stackPanel;
            return treeItem;
        }

        private TreeViewItem markTreeViewItem(string header, Color color)
        {
            TreeViewItem treeItem = new TreeViewItem();
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            Border border = new Border() { Background = new SolidColorBrush(color), Width = 8, Height = 12, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1) };
            TextBlock tBlock = new TextBlock() { Text = header };
            stackPanel.Children.Add(border);
            stackPanel.Children.Add(tBlock);
            treeItem.Header = stackPanel;
            return treeItem;
        }
    }
}
