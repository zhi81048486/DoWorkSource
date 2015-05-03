using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMethod
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    #region 异步委托
        //    #region 委托实现的几种形式
        //    OurDelegate del1 = OurMethod;
        //    OurDelegate del2 = new OurDelegate(OurMethod);
        //    OurDelegate del3 = (int i, int j) =>
        //    {
        //        //method code here
        //        return ++i;
        //    };
        //    OurDelegate del4 = delegate(int i, int j)
        //    {
        //        //method code here
        //        return ++i;
        //    };
        //    #endregion

        //    //IAsyncResult iResult = del1.BeginInvoke(20, 5000, null, null);


        //    //#region 使用IsCompleted属性判断是否完成异步
        //    //while (!iResult.IsCompleted)
        //    //{
        //    //    //do someing else in the main thread
        //    //    Console.WriteLine("....");
        //    //    Thread.Sleep(100);
        //    //}
        //    //int ResultInt = del1.EndInvoke(iResult);
        //    //Console.WriteLine("Result {0}", ResultInt); 
        //    //#endregion


        //    //#region 等待句柄来实现异步委托是否完成
        //    //while (true)
        //    //{
        //    //    Console.WriteLine("***");
        //    //    //设置检测时间，如果超时就返回false
        //    //    if (iResult.AsyncWaitHandle.WaitOne(200, false))
        //    //    {
        //    //        Console.WriteLine("method Completed!");
        //    //        break;
        //    //    }
        //    //}
        //    //#endregion

        //    #region 使用回调函数来判断异步是否完成
        //    del1.BeginInvoke(22, 500, MethodCallBack, del1);
        //    for (int i = 0; i < 50; i++)
        //    {
        //        Console.WriteLine(".....{0}", i);
        //        Thread.Sleep(55);
        //    }
        //    #endregion 
        //    #endregion


        //    Console.ReadKey();
        //}
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








        #region Task

        /*
     * 任务包含的类抽象出了线程的功能，在后台使用ThreadPool，任务表示应该完成的某个单元的工作，这个单元的工作可以在单独线程中运行，也可以以同步的方式启动一个任务，这需要等待主调线程。使用任务不仅可以获得一个抽象层，还可以对底层的线程进行很多控制。
     * 默认情况下，任务是异步的。
     */

        private static void Main()
        {
            #region 调用Task

            Console.WriteLine("*******************************************");
            //任务默认是异步调用的。所以这些任务的线程都是不一样的。
            TaskFactory tf = new TaskFactory();
            //调用StartNew立即启动任务
            Task t1 = tf.StartNew(TaskMethod);

            Task t2 = Task.Factory.StartNew(TaskMethod);

            Task t3 = new Task(TaskMethod);
            t3.Start();

            Task t4 = new Task(TaskMethod, TaskCreationOptions.PreferFairness);
            t4.Start();

           ContinuationTask();
            Console.ReadKey();
        }

        #endregion


        static void TaskMethod()
        {
            Console.WriteLine("running in a task");
            Console.WriteLine("Task id:{0}", Task.CurrentId);
        }




        static void TaskFirst()
        {
            Console.WriteLine("doing some task{0}",Task.CurrentId);
            Thread.Sleep(3000);
        }

        static void TaskSecond(Task t)
        {
            Console.WriteLine("task {0} finished",t.Id);
            Console.WriteLine("this task id {0}",Task.CurrentId);
            Console.WriteLine("do some cleanup");
            Thread.Sleep(5000);
        }
        static void TaskError(Task t)
        {
            Console.WriteLine("task {0} had an error!", t.Id);
            Console.WriteLine("my id {0}", Task.CurrentId);
            Console.WriteLine("do some cleanup");
        }

        static void ContinuationTask()
        {
            Console.WriteLine("Continue Task Begin:");
            //任务的连续性，可以在一个任务结束后，立即运行另一个任务
            Task t1 = new Task(TaskFirst);
            Task t2 = t1.ContinueWith(TaskSecond);
            Task t3 = t1.ContinueWith(TaskSecond);
            Task t4 = t2.ContinueWith(TaskSecond);
            Task t5 = t1.ContinueWith(TaskError, TaskContinuationOptions.OnlyOnFaulted);
            t1.Start();


            Thread.Sleep(5000);

        }


        #endregion



    }
    //异步模式
    /*使用异步委托，因为委托有BeginInvoke和EndInvoke方法。所以可以异步调用*/

    public delegate int OurDelegate(int i, int j);

}
