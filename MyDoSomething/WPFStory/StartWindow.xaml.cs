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
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Wait_Click(object sender, RoutedEventArgs e)
        {
            WaitingStory ws = new WaitingStory();
            ws.ShowDialog();
        }

        private void ProgressBar_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarStory pbs = new ProgressBarStory();
            pbs.ShowDialog();
        }

        private void Rotate_Click(object sender, RoutedEventArgs e)
        {
            NewStory ns = new NewStory();
            ns.ShowDialog();
        }
    }
}
