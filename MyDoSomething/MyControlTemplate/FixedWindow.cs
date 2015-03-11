using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyControlTemplate
{
    public class FixedWindow : System.Windows.Window
    {
        public FixedWindow()
        {
            this.Style = (Style)this.FindResource("MyMessageWindowStyle");
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
        }
    }
}
