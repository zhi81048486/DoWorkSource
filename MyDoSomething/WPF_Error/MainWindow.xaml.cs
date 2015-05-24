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

namespace WPF_Error
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 字段初始值设定无法引用非静态的字段，方法，属性
        //#region Code
        ///*C#规定在类内部只能定义属性或者变量，并初始化，不能直接变量引用变量。在初始化类实例之前就调用了字段.c# 中字段的初始化先于构造函数。*/
        //private int a = 1;
        //private int tem = a;

        //private delegate void someDel();

        //private someDel _someDel = method;

        //public void method()
        //{

        //}

        //public void Here()
        //{
        //    int a = 1;
        //    int temp = a;

        //    someDel _someDel = method;
        //} 
        //#endregion
        #endregion
    }
}
