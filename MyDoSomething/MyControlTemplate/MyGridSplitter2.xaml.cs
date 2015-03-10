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
            this.Loaded += MyGridSplitter2_Loaded;
        }
        List<CheckBox> cboxs = new List<CheckBox>();
        void MyGridSplitter2_Loaded(object sender, RoutedEventArgs e)
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
    }

}
