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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStory
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.UserCon.BeginEvent += UserCon_MyEvent;
            this.UserCon.BackEvent += UserCon_BackEvent;
        }

        void UserCon_BackEvent(object sender, EventArgs e)
        {
            DoBackStory();
        }

        void UserCon_MyEvent(object sender, EventArgs e)
        {
            DoBeginStory();
        }

      
        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            
            Console.WriteLine("Complete");
        }
        //double Window_Height;
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    Window_Height = e.NewSize.Height;
        //    //double Back_Height_Bottom = this.StackPanel_Bottom.ActualHeight;
        //    //double Back_Height_Up = this.StackPanel_Up.ActualHeight;


        //}
       // double Bheigt, Uheight;
        void DoBeginStory()
        {
            DoubleAnimation Begin_Up_Height_Story = new DoubleAnimation();
            Begin_Up_Height_Story.From = this.StackPanel_Up.ActualHeight;
            Begin_Up_Height_Story.To = 100;
            Begin_Up_Height_Story.FillBehavior = FillBehavior.HoldEnd;
            Begin_Up_Height_Story.Duration = TimeSpan.FromSeconds(1);
            this.StackPanel_Up.BeginAnimation(StackPanel.HeightProperty, Begin_Up_Height_Story);

            //DoubleAnimation Begin_Bottom_Height_Story = new DoubleAnimation();
            //Begin_Bottom_Height_Story.From =Uheight = this.StackPanel_Bottom.ActualHeight;
            //Begin_Bottom_Height_Story.To =300;
            //Begin_Bottom_Height_Story.FillBehavior = FillBehavior.HoldEnd;
            //Begin_Bottom_Height_Story.Duration = TimeSpan.FromSeconds(1);
            //this.StackPanel_Bottom.BeginAnimation(StackPanel.HeightProperty, Begin_Bottom_Height_Story);

        }

        void DoBackStory()
        {
            //DoubleAnimation Back_Bottom_Height_Story = new DoubleAnimation();
            //Back_Bottom_Height_Story.From = this.StackPanel_Bottom.ActualHeight;
            //Back_Bottom_Height_Story.To = 200;
            //Back_Bottom_Height_Story.FillBehavior = FillBehavior.HoldEnd;
            //Back_Bottom_Height_Story.Duration = TimeSpan.FromSeconds(1);
            //this.StackPanel_Bottom.BeginAnimation(StackPanel.HeightProperty, Back_Bottom_Height_Story);

            DoubleAnimation Back_Up_Height_Story = new DoubleAnimation();
            Back_Up_Height_Story.From = this.StackPanel_Up.ActualHeight;
            Back_Up_Height_Story.To = 150;
            Back_Up_Height_Story.Duration = TimeSpan.FromSeconds(1);
            this.StackPanel_Up.BeginAnimation(StackPanel.HeightProperty, Back_Up_Height_Story);
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
        //    //NewWindow Nw = new NewWindow();
        //    //Nw.ShowDialog();
        //   // DoBeginStory();

        }


        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
        //    //DoBackStory();
        }
    }
}

