using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdvancedProgrammingCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainDel(args);
            //MaindDel2(args);
            MainDel3(args);


            Console.ReadKey();
        }
        //委托的异步线程都是线程池中的
        public delegate int TakesAWhileDelegate(int data, int ms);

        static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("TakesAWhile Start!");
            Thread.Sleep(ms);
            Console.WriteLine("TakesAWhile Completed!");
            return ++data;
        }
        
        
        #region 委托异步调用
        /*这几个方法都是委托的异步实现，即在主线程中判断委托是否执行完，若完成则继续主线程下面的方法*/
        
        static void MainDel(string[] args)
        {
            TakesAWhileDelegate dl = TakesAWhile;
            //BeginInvoke调用委托方法，并且可以传递委托的两个参数，且返回一个IAsyncResult类型的变量，带有有效信息
            IAsyncResult ar = dl.BeginInvoke(1, 3000, null, null);
            while (!ar.IsCompleted)
            {
                //doing something else in the main thread
                Console.Write(".");
                Thread.Sleep(50);
            }
            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);
        }
        #endregion

        #region 等待句柄来实现异步操作

        /// <summary>
        /// 使用等待句柄来实现异步操作
        /// 同过AsyncWaitHandle可以访问到等待句柄
        /// </summary>
        /// <param name="args"></param>
        static void MaindDel2(string[] args)
        {
            TakesAWhileDelegate dl = TakesAWhile;
            IAsyncResult ar = dl.BeginInvoke(1, 3000, null, null);
            while (true)
            {
                Console.Write(".");
                //WaitOne等待委托线程完成任务。设置等待时间50ms，如果50ms内没有接收到委托线程完成的结果超时返回false，继续while循环，若接到，则break结束循环。
                if (ar.AsyncWaitHandle.WaitOne(50))
                {
                    Console.WriteLine("Can get the result now");
                    break;
                }
            }
            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);
        } 
        #endregion

        #region 使用异步回调函数来实现异步操作
      
        /// <summary>
        /// 使用回调方法，必须注意这个方法从委托线程中调用，而不是从主线程中调用
        /// BeginInvoke的第三个参数就是异步回调函数，这个函数的类型就是如下写的一样
        /// 最后一个参数，可以是任意对象，从回调方法中访问它
        /// </summary>
        /// <param name="args"></param>
        static void MainDel3(string[] args)
        {
            TakesAWhileDelegate dl = TakesAWhile;
            dl.BeginInvoke(1, 3000, TakesAWhileCompleted, dl);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
        }

        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentException("ar");
            TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
            Trace.Assert(dl != null, "Invalid object type");
            int result = dl.EndInvoke(ar);
            Console.WriteLine("result:{0}", result);
        } 

        /*
         *使用lambda来简化代码
         *这里使用的参数ar，就是回调函数规定的参数，省去了声明。
         */
        static void MainDel3_lambda(string[] args)
        {
            TakesAWhileDelegate dl = TakesAWhile;
            dl.BeginInvoke(1, 3000,
                ar =>
                {
                    int result = dl.EndInvoke(ar);
                    Console.WriteLine("result:{0}",result);
                },
                null);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
        }
        #endregion

    }


    public class AsyncMethod
    {

    }
}
