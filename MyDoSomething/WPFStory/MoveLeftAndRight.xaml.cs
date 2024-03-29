﻿using System;
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
    /// MoveLeftAndRight.xaml 的交互逻辑
    /// </summary>
    public partial class MoveLeftAndRight : Window
    {
        public MoveLeftAndRight()
        {
            InitializeComponent();
        }

        private void BeginStory_OnCompleted(object sender, EventArgs e)
        {
            Grid.SetZIndex(MyControl1,3);
        }
        private void EndStory_OnCompleted(object sender, EventArgs e)
        {
            Grid.SetZIndex(MyControl1, 1);
        }
    }
}
