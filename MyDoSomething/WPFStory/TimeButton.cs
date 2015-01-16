using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPFStory
{
    public class TimeDownButton : Button
    {
        static TimeDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeDownButton), new FrameworkPropertyMetadata(typeof(TimeDownButton)));

        }
        private long period = 1040;
        private Timer DownTimer;
        private int down;
        private object defaultContent;
        public static readonly DependencyProperty DownTimeProperty = DependencyProperty.Register("DownTime", typeof(int), typeof(TimeDownButton), new PropertyMetadata(120));
        public int DownTime
        {
            get { return (int)GetValue(DownTimeProperty); }
            set { SetValue(DownTimeProperty, value); }
        }
        public static readonly DependencyProperty DownTextProperty = DependencyProperty.Register("DownText", typeof(string), typeof(TimeDownButton), new PropertyMetadata("秒后可重发"));
        public string DownText
        {
            get { return (string)GetValue(DownTextProperty); }
            set { SetValue(DownTextProperty, value); }
        }
        //public static readonly DependencyProperty CanDownProperty = DependencyProperty.Register("CanDown", typeof(bool), typeof(TimeDownButton), new PropertyMetadata(false));
        //public bool CanDown
        //{
        //    get { return (bool)GetValue(CanDownProperty); }
        //    set { SetValue(CanDownProperty, value); }
        //}

        public bool NeedStop = false;
        protected override void OnClick()
        {
            if (null == DownTimer)
            {
                DownTimer = new Timer(TimerCallback, down, -1, period);
            }
            defaultContent = this.Content;
            base.OnClick();

            //defaultContent = this.Content;
            //down = DownTime;
            //if (null == DownTimer)
            //{
            //    DownTimer = new Timer(TimerCallback, down, -1, period);
            //}
            //DownTimer.Change(0, period);

        }
        private void TimerCallback(object state)
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                if (NeedStop)
                {
                    return;
                }
                if (down > 0)
                {

                    this.IsEnabled = false;
                    this.Content = down + DownText;
                    down--;


                }
                else
                {
                    this.IsEnabled = true;
                    this.Content = defaultContent;
                    DownTimer.Change(-1, period);

                }
            }));

        }

        public void Start()
        {
            NeedStop = true;
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.IsEnabled = false;
                down = DownTime;

                NeedStop = false;
                DownTimer.Change(0, period);
            }));



        }
        public void Stop()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.IsEnabled = true;
                this.Content = defaultContent;
                NeedStop = true;
                DownTimer.Change(-1, period);
            }));
        }
        public void Suspend()
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.IsEnabled = false;
                this.Content = "发送中...";
                NeedStop = true;
                DownTimer.Change(-1, period);
            }));
        }
    }

}
