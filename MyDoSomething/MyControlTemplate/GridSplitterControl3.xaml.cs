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

namespace MyControlTemplate
{
    /// <summary>
    /// GridSplitterControl3.xaml 的交互逻辑
    /// </summary>
    public partial class GridSplitterControl3 : UserControl
    {
        public Action<string> DockAction;
        public Action<string> RemoveAction;
        public GridSplitterControl3()
        {
            InitializeComponent();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            RemoveAction("Con3");
        }

        private void DockButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (null != DockAction)
                DockAction("Con3");
        }
    }
}
