using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_CustomControls
{
    public class WPF_SearchTextBox : TextBox
    {
        public static readonly DependencyProperty IsSeachValueVisibleProperty = DependencyProperty.Register(
            "IsSeachValueVisible", typeof(bool), typeof(WPF_SearchTextBox), new PropertyMetadata(default(bool)));

        public bool IsSeachValueVisible
        {
            get { return (bool)GetValue(IsSeachValueVisibleProperty); }
            set { SetValue(IsSeachValueVisibleProperty, value); }
        }

        private ControlTemplate ct;
        public RoutedEventHandler SearchEvent;

        public static readonly DependencyProperty SearchValueProperty = DependencyProperty.Register(
            "SearchValue", typeof(string), typeof(WPF_SearchTextBox), new PropertyMetadata(default(string)));

        public string SearchValue
        {
            get { return (string)GetValue(SearchValueProperty); }
            set { SetValue(SearchValueProperty, value); }
        }

        public WPF_SearchTextBox()
        {
            KeyDown += WPF_SearchTextBox_KeyDown;

            this.Loaded += WPF_SearchTextBox_Loaded;
           
        }

        public override void OnApplyTemplate()
        {
            var vartp = this.Template;
            var con = vartp.FindName("Button_Close", this);
            Button bt = con as Button;
            bt.Click += close_Click;
            //Binding binding = new Binding("SearchValueProperty");
            //binding.Source = this.Text.Trim();
            //binding.Mode = BindingMode.TwoWay;
            ////BindingOperations.SetBinding(this, SearchValueProperty, binding);
            //this.SetBinding(SearchValueProperty, binding);

            base.OnApplyTemplate();
        }

        void WPF_SearchTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void close_Click(object sender, RoutedEventArgs e)
        {
           // this.SearchValue = "";
            this.Text = "";
            IsSeachValueVisible = false;
            WPF_SearchTextBox_KeyDown(null, new KeyEventArgs(Keyboard.PrimaryDevice,
        Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter));
        }

        void WPF_SearchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VisualChanged();
                SearchEvent(this, null);
            }
        }

        void VisualChanged()
        {
            //IsSeachValueVisible = String.IsNullOrEmpty(SearchValue) ? false : true;
            IsSeachValueVisible = String.IsNullOrEmpty(this.Text.Trim()) ? false : true;


        }
    }
}
