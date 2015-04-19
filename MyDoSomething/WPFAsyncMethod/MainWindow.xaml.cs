using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAsyncMethod
{

    public delegate void DownLoadDel(string url);
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private DemoSource demoSource;
        public MainWindow()
        {
            InitializeComponent();
            ButtonDown.Click += ButtonDown_Click;
            demoSource = new DemoSource();
            this.DataContext = demoSource;
        }

        private Action<string> actionDemo;
        void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            actionDemo = str => demoSource.StrInfo = str;

            ButtonDown.Content = "Downloading";
            DownLoadDel downMethod = DoDownLoad;
            TextBoxInfo.Text = "Current Thread:" + Thread.CurrentThread.ManagedThreadId;
            downMethod.BeginInvoke(TextBoxURL.Text, CallBack, downMethod);

        }

        /*异步调用委托是利用了已经有的线程，并没有创建新的线程。所以主线程里的控件，在另一个线程里是没法调用的。*/
        /// <summary>
        /// 委托方法
        /// </summary>
        /// <param name="url"></param>
        private void DoDownLoad(string url)
        {
            string str = "";
            //检查线程是否在UI线程上。
            if (this.Dispatcher.CheckAccess())
            {
                TextBoxInfo.Text = "hello 1";
            }
            else
            {           
                //在关联的线程上，同步执行一个委托。
                this.Dispatcher.Invoke(actionDemo, "hello");
            }
            Thread.Sleep(2000);
        }

        private void CallBack(IAsyncResult asy)
        {
            if (asy == null)
                throw new ArgumentNullException("asy");
            DownLoadDel del = asy.AsyncState as DownLoadDel;
            Trace.Assert(del != null, "Invalid object types");
            del.EndInvoke(asy);
        }

    }

    public class DemoSource : INotifyPropertyChanged
    {
        //protected void SetProperty<T>(ref T prop, T value, [CallerMemberName] string callerName = "")
        //{
        //    if (!EqualityComparer<T>.Default.Equals(prop, value))
        //    {
        //        prop = value;
        //        OnPropertyChanged(callerName);
        //    }
        //}

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _strInfo;
        public string StrInfo
        {
            get { return _strInfo; }
            set { _strInfo = value; OnPropertyChanged("StrInfo"); }
        }
    }
}
