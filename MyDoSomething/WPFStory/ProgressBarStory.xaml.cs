using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFStory
{
    /// <summary>
    /// ProgressBarStory.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBarStory : Window
    {
        public ProgressBarStory()
        {
            InitializeComponent();
        }
        double d = (double)100;
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            d += 100;
        }
    }
}
