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

namespace MyControlTemplate
{
    /// <summary>
    /// MyGridSplitter5.xaml 的交互逻辑
    /// </summary>
    public partial class MyGridSplitter5 : Window
    {
        List<CheckBox> checkSource=new List<CheckBox>();
        GridSplitterControl1 control1=new GridSplitterControl1();
        GridSplitterControl2 control2=new GridSplitterControl2();
        GridSplitterControl3 control3 = new GridSplitterControl3();
        public MyGridSplitter5()
        {
            InitializeComponent();
            this.Loaded += MyGridSplitter5_Loaded;
            //Binding binding=new Binding();
            //binding.Source = CheckBox1;
            //binding.Path = new PropertyPath();
            //binding.Converter=new BoolToVisibility_Collapsed_Convert();
            //BindingOperations.SetBinding(CheckBox1, Visibility, binding);
        }

        void MyGridSplitter5_Loaded(object sender, RoutedEventArgs e)
        {
            checkSource.Add(this.CheckBox1);
            checkSource.Add(this.CheckBox2);
            checkSource.Add(this.CheckBox3);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CheckBox cb=(e.OriginalSource) as CheckBox;
            foreach (var checkboxItem in checkSource)
            {
                if (checkboxItem.Name == cb.Name && cb.IsChecked.Value)
                {
                    checkboxItem.IsChecked = true;
                }
                else
                {
                    checkboxItem.IsChecked = false;
                }
            }

        }

        private void Button_Add_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
