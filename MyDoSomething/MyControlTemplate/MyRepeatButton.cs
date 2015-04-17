using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyControlTemplate
{
    public class MyRepeatButton : Control
    {
        public static readonly DependencyProperty DefaultValueProperty = DependencyProperty.Register(
            "DefaultValue", typeof(int), typeof(MyRepeatButton), new PropertyMetadata(default(int)));

        public int DefaultValue
        {
            get { return (int)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        public static readonly DependencyProperty ChangeValueProperty = DependencyProperty.Register(
            "ChangeValue", typeof(int), typeof(MyRepeatButton), new PropertyMetadata(default(int)));

        public int ChangeValue
        {
            get { return (int)GetValue(ChangeValueProperty); }
            set { SetValue(ChangeValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue", typeof(int), typeof(MyRepeatButton), new PropertyMetadata(default(int)));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue", typeof(int), typeof(MyRepeatButton), new PropertyMetadata(default(int)));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        private RepeatButton IncrRButton;
        private RepeatButton DecrRButton;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            IncrRButton = (RepeatButton) GetTemplateChild("IncreaseRepeatButton");
            DecrRButton = (RepeatButton) GetTemplateChild("DecreaseRepeatButton");
            DecrRButton.Click += DecrRButton_Click;
            IncrRButton.Click += IncrRButton_Click;

        }

        void IncrRButton_Click(object sender, RoutedEventArgs e)
        {
               DefaultValue= (DefaultValue += ChangeValue) < MaxValue ? DefaultValue : MaxValue;
            
        }

        void DecrRButton_Click(object sender, RoutedEventArgs e)
        {
            DefaultValue = (DefaultValue -= ChangeValue) > MinValue ? DefaultValue : MinValue;

        }

        public EventHandler IncreaseEvent;
        public EventHandler DecreaseEvent;
    }
}
