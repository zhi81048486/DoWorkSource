using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLG
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSort();

        }
        static void DoSort()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] Sorts = new int[] { 1, 3, 5, 6, 2, 15, 7, 10, 4 };
            CLGMethod<int> m1 = new CLGMethod<int>();

            //char[] Sorts = new char[] { 'a','p','c','e','m','b','w','k'};          
            // CLGMethod<char> m1 = new CLGMethod<char>();
            m1.SelectSort(Sorts);
            //m1.InsertSort(Sorts);
            for (int i = 0; i < Sorts.Length; i++)
            {
                Console.WriteLine(Sorts[i]);
            }
            sw.Stop();
            Console.WriteLine("消耗时间：" + sw.ElapsedMilliseconds.ToString() + "毫秒");
            Console.ReadKey();
        }

    }

}
