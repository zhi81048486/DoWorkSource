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
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionOperation();
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



        #region 集合删除异常
        void CollectionOperation()
        {
            List<string> lists = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                lists.Add("string" + i);
            }
            try
            {
                //foreach (string str in lists)
                //{
                //    if (str.Contains("0"))
                //        lists.Remove(str);
                //}
                for (int i = 0; i < lists.Count; i++)
                {
                    if (lists[i].Contains("0"))
                        lists.Remove(lists[i]);
                    
                }
               Tbox.Text= lists.Count.ToString();
            }
            catch (Exception ex)
            {
                Tbox.Text = ex.ToString();
            }
        }
        
        #endregion
    }
}
