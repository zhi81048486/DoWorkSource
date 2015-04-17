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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyControlTemplate
{
    /// <summary>
    /// MyRepeatButtonControl.xaml 的交互逻辑
    /// </summary>
    public partial class MyRepeatButtonControl : UserControl
    {
        public MyRepeatButtonControl()
        {
            InitializeComponent();
            this.IncreaceButton.Click += IncreaceButton_Click;
            this.DecreaceButon.Click += DecreaceButon_Click;
        }

        void DecreaceButon_Click(object sender, RoutedEventArgs e)
        {
            int v = Convert.ToInt32(RButtonDefaultValue);
            
            v -= RButtonChangeValue;
            RButtonDefaultValue = v.ToString();
        }

        void IncreaceButton_Click(object sender, RoutedEventArgs e)
        {

            int v = Convert.ToInt32(RButtonDefaultValue);
            v +=RButtonChangeValue;
            RButtonDefaultValue = v.ToString();
        }

        public static readonly DependencyProperty RButtonDefaultValueProperty = DependencyProperty.Register(
            "RButtonDefaultValue", typeof(string), typeof(MyRepeatButtonControl), new PropertyMetadata(default(string)));

        public string RButtonDefaultValue
        {
            get { return (string)GetValue(RButtonDefaultValueProperty); }
            set { SetValue(RButtonDefaultValueProperty, value); }
        }

        public static readonly DependencyProperty RButtonChangeValueProperty = DependencyProperty.Register(
            "RButtonChangeValue", typeof(int), typeof(MyRepeatButtonControl), new PropertyMetadata(default(int)));

        public int RButtonChangeValue
        {
            get { return (int)GetValue(RButtonChangeValueProperty); }
            set { SetValue(RButtonChangeValueProperty, value); }
        }

    }
}
