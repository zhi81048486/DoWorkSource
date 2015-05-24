using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPF_Async
{
    public delegate void AsyncDel();
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void AsyncDel2();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AsyncDel _asyncDel = TakeLongWhile;
            AsyncDel2 _asyncDel2 = TakeLongWhile;
        }
        #region 委托异步
        //委托的异步调用使用了线程池中的线程

        //这里必须是静态的方法，因为csharp规定只能在类的内部定义变量或者属性，并初始化。不能变量直接引用变量。
        //like:int a=10; int temp=a;
      //AsyncDel  _asyncDel= TakeLongWhile ;

        #endregion


        public void TakeLongWhile()
        {
            ShowTextBox("方法开始调用：");
            Thread.Sleep(5000);
            ShowTextBox("方法调用结束。");

        }

        public void ShowTextBox(string str)
        {
            TextBox_Info.Text = DateTime.Now.ToShortTimeString() + str + "\n";
        }


    }

}
