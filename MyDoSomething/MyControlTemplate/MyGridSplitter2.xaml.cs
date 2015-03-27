using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyControlTemplate
{
    /// <summary>
    /// MyGridSplitter2.xaml 的交互逻辑
    /// </summary>
    public partial class MyGridSplitter2 : Window
    {
        public MyGridSplitter2()
        {
            InitializeComponent();
        }

        //private void SwitchCheckBox_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (!SwitchCheckBox.IsChecked.Value)
        //    {
        //        BaseSet.Visibility = Visibility.Visible;
        //        AdvancedPanel.Visibility = Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        AdvancedPanel.Visibility = Visibility.Visible;
        //        BaseSet.Visibility = Visibility.Collapsed;
        //    }
        //}

        private void BottomPanelCheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            if (BottomPanelCheckBox.IsChecked.Value)
            {
                this.Panel.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Panel.Visibility = Visibility.Visible;
            }
        }
    }


}
