using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicCsharp
{
    delegate void AsyncFoo(int i);
    class DelegateAsync
    {
        ///<summary>
        /// 输出当前线程的信息
        ///</summary>
        ///<param name="name">方法名称</param>

        static void PrintCurrThreadInfo(string name)
        {
            Console.WriteLine("Thread Id of " + name + " is: " + Thread.CurrentThread.ManagedThreadId + ", current thread is "
            + (Thread.CurrentThread.IsThreadPoolThread ? "" : "not ")
            + "thread pool thread.");
        }

        ///<summary>
        /// 测试方法，Sleep一定时间
        ///</summary>
        ///<param name="i">Sleep的时间</param>
        static void Foo(int i)
        {
            PrintCurrThreadInfo("Foo()");
            Thread.Sleep(i);
        }

        ///<summary>
        /// 投递一个异步调用
        ///</summary>
        static void PostAsync()
        {
            //AsyncFoo caller = new AsyncFoo(Foo);
            AsyncFoo caller = Foo;
            caller.BeginInvoke(1000, new AsyncCallback(FooCallBack), caller);
        }

        static void Main(string[] args)
        {
            PrintCurrThreadInfo("Main()");
            for (int i = 0; i < 10; i++)
            {
                PostAsync();
            }
            Console.ReadLine();

            Timer t = new Timer(TimerCallback, null, 0, 2000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        static void FooCallBack(IAsyncResult ar)
        {
            PrintCurrThreadInfo("FooCallBack()");
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            caller.EndInvoke(ar);
        }
    }
}
