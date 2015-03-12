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
    /// MyGridSplitter4.xaml 的交互逻辑
    /// </summary>
    public partial class MyGridSplitter4 : Window
    {
        List<CheckBox> cboxs = new List<CheckBox>();

        public MyGridSplitter4()
        {
            InitializeComponent();
            this.Loaded += MyGridSplitter4_Loaded;
        }

        void MyGridSplitter4_Loaded(object sender, RoutedEventArgs e)
        {
            cboxs.Add(this.CheckBox1);
            cboxs.Add(this.CheckBox2);
            cboxs.Add(this.CheckBox3);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.OriginalSource as CheckBox;
            foreach (var item in cboxs)
            {
                if (item.Name == cb.Name && cb.IsChecked.Value)
                    item.IsChecked = true;
                else
                    item.IsChecked = false;
            }
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {

            Label l2 = new Label();
            l2.Content = "label2";

            this.RightPanel.Children.Insert(0,l2);
        }
    }
}
