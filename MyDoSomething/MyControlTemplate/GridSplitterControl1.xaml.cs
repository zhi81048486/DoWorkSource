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
    /// GridSplitterControl1.xaml 的交互逻辑
    /// </summary>
    public partial class GridSplitterControl1 : UserControl
    {
        public Action<string> DockAction;
        public Action<string> RemoveAction;
        public GridSplitterControl1()
        {
            InitializeComponent();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            RemoveAction("Con1");
        }

        private void DockButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (null != DockAction)
                DockAction("Con1");
        }
    }
}