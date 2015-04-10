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

namespace AnimatedFlag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ctr = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            ShowImage();
            da.BeginAnimation(Image.WidthProperty, da);
        }

        private void ShowImage()
        {
            string filename = "Images/Flag" + ctr + ".jpg";
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filename, UriKind.Relative);
            image.EndInit();
            flagImage.Source = image;
            ctr++;
            if (ctr > 6)
            {
                ctr = 1;
            }
        }
    }
}