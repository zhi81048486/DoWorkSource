using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFStory
{
    /// <summary>
    /// WaitingStory.xaml 的交互逻辑
    /// </summary>
    public partial class WaitingStory : Window
    {
        public WaitingStory()
        {
            InitializeComponent();
            this.StoryButton.Click += StoryButton_Click;
        }
        int Intcount = 1;
        void StoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (StoryButton.IsChecked == true)
            {               
                Thread tt = new Thread(new ThreadStart(some));
                tt.Start();
            }
        }
        void some()
        {
            Timer t = new Timer(DoMethod, Intcount, 0, 1000);
            t.Change(0, 1000);
        }
        void DoMethod(object o)
        {
            ++Intcount;
            if (Intcount <= 40)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
                {
                    TimeTextBox.Text = Intcount.ToString();
                }));          
            }
        }
    }
}
