﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WPFWebBrower
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Button_Go.Click += goNavigateButton_Click;
        }

        private void goNavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri;
            if (TextBox_Url.Text.StartsWith("http://") || TextBox_Url.Text.StartsWith("https://"))
            {
                uri = new Uri(this.TextBox_Url.Text, UriKind.RelativeOrAbsolute);
            }


            else
            {
                uri = new Uri("http://" + this.TextBox_Url.Text, UriKind.RelativeOrAbsolute);

            }
            if (uri != null)

                this.MyBrowser.Source = uri;
            try
            {
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = 5000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            }
            catch (Exception esx)
            {
                MessageBox.Show(esx.ToString());
            }
          
        }
    }
}
