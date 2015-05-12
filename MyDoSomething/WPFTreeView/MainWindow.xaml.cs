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

namespace WPFTreeView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        void ShowControl(Control _control, string Control_Title)
        {
            _control.HorizontalAlignment = HorizontalAlignment.Stretch;
            _control.VerticalAlignment = VerticalAlignment.Stretch;
            _control.Height = Double.NaN;
            _control.Height = Double.NaN;
            Grid_Control.Children.Clear();
            Grid_Control.Children.Add(_control);
            TitleLabel.Content = Control_Title;

        }

        void TreeTypeButton_Click(Object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            switch (btn.Name)
            {
                case "Button_X_Simple":
                    ShowControl(new SimpleTree_Xaml(), "简单树使用xaml");
                    break;
                case "Button_C_Simple":
                    ShowControl(new SimpleTree_Code(), "简单树使用code");
                    break;
                case "Button_X_Custom":
                    ShowControl(new CustomTree_Xaml(), "定制树使用xaml");
                    break;
                case "Button_C_Custom":
                    ShowControl(new CustomTree_Code(), "定制树使用code");
                    break;
                case "Button_Class_Custom":
                    ShowControl(new CustomTree_CustomItem(), "定制树使用定制类");
                    break;
                case "Button_X_Template":
                    ShowControl(new TreeHeaderTemplate(), "HeaderTemplate模板使用xaml");
                    break;
                case "Button_C_Template":
                    ShowControl(new TreeHeaderTemplate_Code(), "HeaderTemplate模板使用code");
                    break;
                default:
                    break;
            }

        }

    }
}
