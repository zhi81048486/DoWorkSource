using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 委托实现的几种形式
            OurDelegate del1 = OurMethod;
            OurDelegate del2 = new OurDelegate(OurMethod);
            OurDelegate del3 = (int i, int j) =>
            {
                //method code here
                return ++i;
            };
            OurDelegate del4 = delegate(int i, int j)
            {
                //method code here
                return ++i;
            };
            #endregion

            //IAsyncResult iResult = del1.BeginInvoke(20, 5000, null, null);


            //#region 使用IsCompleted属性判断是否完成异步
            //while (!iResult.IsCompleted)
            //{
            //    //do someing else in the main thread
            //    Console.WriteLine("....");
            //    Thread.Sleep(100);
            //}
            //int ResultInt = del1.EndInvoke(iResult);
            //Console.WriteLine("Result {0}", ResultInt); 
            //#endregion


            //#region 等待句柄来实现异步委托是否完成
            //while (true)
            //{
            //    Console.WriteLine("***");
            //    //设置检测时间，如果超时就返回false
            //    if (iResult.AsyncWaitHandle.WaitOne(200, false))
            //    {
            //        Console.WriteLine("method Completed!");
            //        break;
            //    }
            //}
            //#endregion

            #region 使用回调函数来判断异步是否完成
            del1.BeginInvoke(22, 500, MethodCallBack, del1);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(".....{0}", i);
                Thread.Sleep(55);
            }
            #endregion




            Console.ReadKey();
        }
        static int OurMethod(int i, int j)
        {
            Console.WriteLine("Now to do Method.......");
            Thread.Sleep(j);

            Console.WriteLine("Method Complete!");
            return ++i;
        }

        #region 异步回调
        static void MethodCallBack(IAsyncResult asy)
        {
            if (asy == null)
                throw new ArgumentNullException("asy");
            OurDelegate del = asy.AsyncState as OurDelegate;
            Trace.Assert(del != null, "Invalid object types");
            Console.Write(del.EndInvoke(asy));
        }
        #endregion
    }
    //异步模式
    /*使用异步委托，因为委托有BeginInvoke和EndInvoke方法。所以可以异步调用*/

    public delegate int OurDelegate(int i, int j);

}
