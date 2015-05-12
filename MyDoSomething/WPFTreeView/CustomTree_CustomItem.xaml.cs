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
using WPFTreeView.Library;

namespace WPFTreeView
{
    /// <summary>
    /// CustomTree_CustomItem.xaml 的交互逻辑
    /// </summary>
    public partial class CustomTree_CustomItem : UserControl
    {
        public CustomTree_CustomItem()
        {
            InitializeComponent();
            LoadTree();
        }

        private void LoadTree()
        {
            TreeViewItem asianItem=new TreeViewItem(){Header = "亚洲"};
            TreeViewItem europeItem = new TreeViewItem() { Header = "欧洲" };
            asianItem.Items.Add(new ImageTreeViewItem("中国", "china.png"));
            asianItem.Items.Add(new ImageTreeViewItem("日本", "japan.png"));
            europeItem.Items.Add(new ImageTreeViewItem("英国", "uk.png"));
            europeItem.Items.Add(new ImageTreeViewItem("丹麦", "denmark.png"));
            this.MainTreeView.Items.Add(asianItem);
            this.MainTreeView.Items.Add(europeItem);

        }
    }
}
