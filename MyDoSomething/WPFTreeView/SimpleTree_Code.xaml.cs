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
using System.Windows.Shapes;

namespace WPFTreeView
{
    /// <summary>
    /// SimpleTree_Code.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleTree_Code : UserControl
    {
        public SimpleTree_Code()
        {
            InitializeComponent();
            SimpleCreateTree();
        }

        #region 树简单的创建

        void SimpleCreateTree()
        {
            TreeViewItem PTreeAsian = new TreeViewItem() { Header = "亚洲" };
            PTreeAsian.Items.Add(new TreeViewItem() { Header = "中国" });
            PTreeAsian.Items.Add(new TreeViewItem() { Header = "韩国" });
            PTreeAsian.Items.Add(new TreeViewItem() { Header = "新加坡" });
            TreeViewItem PTreeEurope = new TreeViewItem() { Header = "欧洲" };
            PTreeEurope.Items.Add(new TreeViewItem() { Header = "英国" });
            PTreeEurope.Items.Add(new TreeViewItem() { Header = "德国" });
            PTreeEurope.Items.Add(new TreeViewItem() { Header = "俄罗斯" });

            MainTreeView.Items.Add(PTreeAsian);
            MainTreeView.Items.Add(PTreeEurope);

        }
        #endregion
    }
}
