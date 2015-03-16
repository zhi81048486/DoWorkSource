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

namespace MyControlTemplate
{
    /// <summary>
    /// MyGridSplitter4.xaml 的交互逻辑
    /// </summary>
    public partial class MyGridSplitter4 : Window
    {
        List<CheckBox> cboxs = new List<CheckBox>();

        public MyGridSplitter4()
        {
            InitializeComponent();
            this.Loaded += MyGridSplitter4_Loaded;
        }

        void MyGridSplitter4_Loaded(object sender, RoutedEventArgs e)
        {
            cboxs.Add(this.CheckBox1);
            cboxs.Add(this.CheckBox2);
            cboxs.Add(this.CheckBox3);
            Control1.DockAction = Dock;
            Control1.RemoveAction = RemoveDock;
            Control2.DockAction = Dock;
            Control2.RemoveAction = RemoveDock;
            Control3.DockAction = Dock;
            Control3.RemoveAction = RemoveDock;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.OriginalSource as CheckBox;
            foreach (var item in cboxs)
            {
                if (item.Name == cb.Name && cb.IsChecked.Value)
                {
                    
                    item.IsChecked = true;
                    //if (cb.Name=="CheckBox1")
                    //{
                    //    control1 = new GridSplitterControl1();
                    //    control1.HorizontalAlignment = HorizontalAlignment.Right;
                    //    this.SideBarPanel.Children.Insert(0, control1);

                    //}

                }
                else
                    item.IsChecked = false;
            }
        }

        public void RemoveDock(string name)
        {
            
            UIElement ui = null;
            switch (name)
            {
                case "Con1":
                    ui = this.Control1;
                    if(!cboxs.Contains(CheckBox1))
                    this.cboxs.Add(CheckBox1);
                    this.CheckBox1.Visibility = Visibility.Visible;
                    break;
                case "Con2":
                    ui = this.Control2;
                    if (!cboxs.Contains(CheckBox2))
                    this.cboxs.Add(CheckBox2);
                    this.CheckBox2.Visibility = Visibility.Visible;
                    break;
                case "Con3":
                    ui = this.Control3;
                    if (!cboxs.Contains(CheckBox3))
                    this.cboxs.Add(CheckBox3);
                    this.CheckBox3.Visibility = Visibility.Visible;
                    break;

            }
            if (ui != null)
            {
                if (!SideBarPanel.Children.Contains(ui))
                {
                    DockingPanel.Children.Remove(ui);
                    SideBarPanel.Children.Add(ui);
                }
            }
        }

        public void Dock(string PanelName)
        {
            if (PanelName == "Con1")
            {
                this.SideBarPanel.Children.Remove(Control1);
                DockingPanel.Children.Clear();
                this.DockingPanel.Children.Add(Control1);
                this.cboxs.Remove(CheckBox1);
                Control1.Visibility = Visibility.Visible;
                this.CheckBox1.Visibility = Visibility.Collapsed;
            }
            if (PanelName == "Con2")
            {
                this.SideBarPanel.Children.Remove(Control2);
                DockingPanel.Children.Clear();
                this.DockingPanel.Children.Add(Control2);
                this.cboxs.Remove(CheckBox2);
                Control2.Visibility = Visibility.Visible;
                this.CheckBox2.Visibility = Visibility.Collapsed;
            } if (PanelName == "Con3")
            {
                this.SideBarPanel.Children.Remove(Control3);
                DockingPanel.Children.Clear();
                this.DockingPanel.Children.Add(Control3);
                this.cboxs.Remove(CheckBox3);
                Control3.Visibility = Visibility.Visible;
                this.CheckBox3.Visibility = Visibility.Collapsed;
            }
        }
    }
}
