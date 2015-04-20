using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode_CSharp;

namespace CLG
{
    class  MYClass
    {
        public string name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MYClass m1=new MYClass(){ name="first"};
            MYClass m2 = m1;
         
            m2.name = "third";
            m2 = new MYClass();
            
            ListNode<int> LA = new ListNode<int>(0);
            ListNode<int> LA0 = new ListNode<int>(1);
            ListNode<int> LA1 = new ListNode<int>(3);
            ListNode<int> LA2 = new ListNode<int>(5);
            LA.Next = LA0;
            LA0.Next = LA1;
            LA1.Next = LA2;
            ListNode<int> LB = new ListNode<int>(0);
            ListNode<int> LB0 = new ListNode<int>(2);
            ListNode<int> LB1 = new ListNode<int>(4);
            ListNode<int> LB2 = new ListNode<int>(6);
            LB.Next = LB0;
            LB0.Next = LB1;
            LB1.Next = LB2;
            AddTwoNum a = new AddTwoNum();
            a.addTwoNumbers(LA, LB);
            // DoSort();
            //int[] ss = new int[] {0,0,0,0,92,0,-3002,0,0,0,-10,-19,0,65,0,0,293,0,1,1,1,9,9,9,10,11,1001,2001,-404,201,203,201,999,345,1,1,1,1,1,1,1,-2,1,1,1,1,1,1,1,1,-2,1,1,1,1,1,1,1,1,1,1,-1200,1,1,1,1,1,2,1202,2,2,-4,2,2,2,2,4,5,6,1,1,-11,1,1,1,1,1,1,1,1,101,1,1,1,1,1,-1,1,-6};
            //threeSum(ss);

            //int[] nums = new int[] { -2, -3, -4, -5, -100, 99, 1, 4, 4, 4, 5, 1, 0, -1, 2, 3, 4, 5 };
            //int target = 77;
            //Console.WriteLine(threeSumClosest(nums, target));
            //List<List<int>> result= fourSum3(new int[] { 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 0, 0, -2, 2, -5, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99, 1, 2, 5, 6, 7, 3, 5, 8, -33, -5, -72, 12, -34, 100, 99 }, 11);

            //     foreach (var varitems in result)
            //     {
            //         foreach (var item in varitems)
            //         {
            //             Console.Write(item+",");
            //         }
            //         Console.WriteLine();
            //     }
            Console.ReadKey();
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

        static public List<List<int>> threeSum(int[] numbers)
        {
            // write your code here
            List<List<int>> collections = new List<List<int>>();
            List<int> collection = new List<int>();
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if ((numbers[i] + numbers[j] + numbers[k]) == 0)
                        {
                            int[] result = new int[3];
                            result[0] = numbers[i];
                            result[1] = numbers[j];
                            result[2] = numbers[k];
                            for (int n = 0; n <= 1; n++)
                            {
                                for (int m = 0; m < 2; m++)
                                {
                                    int temp;
                                    if (result[m] > result[m + 1])
                                    {
                                        temp = result[m + 1];
                                        result[m + 1] = result[m];
                                        result[m] = temp;
                                    }
                                }
                            }
                            if (collections.Count > 0)
                            {
                                //查找是否有重复值
                                for (int l = 0; l < collections.Count; l++)
                                {
                                    if (collections[l][0] == result[0] && collections[l][1] == result[1])
                                        break;
                                    if (l == collections.Count - 1)
                                    {
                                        collection = new List<int>();
                                        collection.Add(result[0]);
                                        collection.Add(result[1]);
                                        collection.Add(result[2]);
                                        collections.Add(collection);
                                    }
                                }
                            }


                            if (collections.Count == 0)
                            {
                                collection = new List<int>();
                                collection.Add(result[0]);
                                collection.Add(result[1]);
                                collection.Add(result[2]);
                                collections.Add(collection);
                            }

                        }
                    }
                }
            }
            return collections;
        }


        static public int threeSumClosest(int[] numbers, int target)
        {
            // write your code here
            List<int> sumResults = new List<int>();
            bool IsOk = true;
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        IsOk = true;
                        int v = numbers[i] + numbers[j] + numbers[k];
                        if (sumResults.Count == 0)
                            sumResults.Add(v);
                        else
                        {
                            for (int m = 0; m < sumResults.Count; m++)
                            {
                                if (v == sumResults[m])
                                {
                                    IsOk = false;
                                    break;
                                }
                            }
                            if (IsOk)
                            {
                                sumResults.Add(v);

                            }
                        }
                    }
                }

            }
            for (int i = 0; i < sumResults.Count; i++)
            {
                for (int j = i + 1; j < sumResults.Count; j++)
                {
                    int temp;
                    if (sumResults[i] > sumResults[j])
                    {
                        temp = sumResults[i];
                        sumResults[i] = sumResults[j];
                        sumResults[j] = temp;
                    }
                }
            }
            //loca为目标的位置，再与左右比大小，输出
            int loca = 0;
            for (int i = 0; i < sumResults.Count; i++)
            {
                if (target > sumResults[i])
                {
                    // sumResults.set(i - 1, target);
                    loca = i;

                }
            }
            if (loca == sumResults.Count - 1)
                return sumResults[loca];
            if (loca == 0)
                return sumResults[0];
            if (System.Math.Abs(sumResults[loca] - target) < System.Math.Abs(sumResults[loca + 1] - target))
            {
                return sumResults[loca];
            }
            else
            {
                return sumResults[loca + 1];
            }
        }
        /// <summary>
        /// 第一版，一个个的遍历
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public List<List<int>> fourSum(int[] numbers, int target)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<List<int>> collections = new List<List<int>>();
            List<int> collection = new List<int>();
            for (int i = 0; i < numbers.Length - 3; i++)
            {
                for (int j = i + 1; j < numbers.Length - 2; j++)
                {
                    for (int k = j + 1; k < numbers.Length - 1; k++)
                    {
                        for (int w = k + 1; w < numbers.Length; w++)
                        {
                            if ((numbers[i] + numbers[j] + numbers[k]) + numbers[w] == target)
                            {
                                int[] result = new int[4];
                                result[0] = numbers[i];
                                result[1] = numbers[j];
                                result[2] = numbers[k];
                                result[3] = numbers[w];
                                //单个集合中按大小排序
                                for (int n = 0; n <= 2; n++)
                                {
                                    for (int m = 0; m < 3; m++)
                                    {
                                        int temp;
                                        if (result[m] > result[m + 1])
                                        {
                                            temp = result[m + 1];
                                            result[m + 1] = result[m];
                                            result[m] = temp;
                                        }
                                    }
                                }
                                if (collections.Count > 0)
                                {
                                    //查找是否有重复值
                                    for (int l = 0; l < collections.Count; l++)
                                    {
                                        if (collections[l][0] == result[0] && collections[l][1] == result[1] && collections[l][2] == result[2])
                                            break;
                                        if (l == collections.Count - 1)
                                        {
                                            collection = new List<int>();
                                            collection.Add(result[0]);
                                            collection.Add(result[1]);
                                            collection.Add(result[2]);
                                            collection.Add(result[3]);
                                            collections.Add(collection);
                                        }
                                    }
                                }


                                if (collections.Count == 0)
                                {
                                    collection = new List<int>();
                                    collection.Add(result[0]);
                                    collection.Add(result[1]);
                                    collection.Add(result[2]);
                                    collection.Add(result[3]);
                                    collections.Add(collection);
                                }

                            }
                        }
                    }
                }
            }
            stopwatch.Stop();

            Stopwatch w2 = new Stopwatch();
            w2.Start();
            //按第一个数排序
            for (int i = 0; i < collections.Count; i++)
            {
                for (int j = 0; j < collections.Count - 1; j++)
                {
                    if (collections[j][0] > collections[j + 1][0])
                    {
                        List<int> temp = new List<int>();
                        temp = collections[j];
                        collections[j] = collections[j + 1];
                        collections[j + 1] = temp;
                    }
                }
            }
            //第一个数相等，按第二个数排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0])
                    {
                        if (collections[i][1] > collections[i + 1][1])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            //前两个数相等，按第三个排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0] && collections[i][1] == collections[i + 1][1])
                    {
                        if (collections[i][2] > collections[i + 1][2])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            w2.Stop();
            return collections;
        }

        /// <summary>
        /// 第二版，实现想法：输入的数组里包含有相同的数，相同的数其实就是一个数，把数字归类，相同的数归在一起，这样只对不同的数添加。
        /// 漏洞：如果是四个相同的数只记录了一个，且如果数据量大，且基本不重复还是有问题。
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public List<List<int>> fourSum2(int[] numbers, int target)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<List<int>> collections = new List<List<int>>();
            List<int> collection = new List<int>();
            List<int> newNumbers = new List<int>();
            newNumbers.Add(numbers[0]);
            //去除掉输入数组里的重复的数据
            for (int i = 1; i < numbers.Length; i++)
            {

                for (int j = 0; j < newNumbers.Count; j++)
                {
                    if (newNumbers[j] == numbers[i])
                        break;
                    if (j == newNumbers.Count - 1)
                    {
                        newNumbers.Add(numbers[i]);
                    }
                }
            }
            for (int i = 0; i < newNumbers.Count - 3; i++)
            {
                for (int j = i + 1; j < newNumbers.Count - 2; j++)
                {
                    for (int k = j + 1; k < newNumbers.Count - 1; k++)
                    {
                        for (int w = k + 1; w < newNumbers.Count; w++)
                        {
                            if ((numbers[i] + numbers[j] + numbers[k]) + numbers[w] == target)
                            {
                                int[] result = new int[4];
                                result[0] = numbers[i];
                                result[1] = numbers[j];
                                result[2] = numbers[k];
                                result[3] = numbers[w];
                                //单个集合中按大小排序
                                for (int n = 0; n <= 2; n++)
                                {
                                    for (int m = 0; m < 3; m++)
                                    {
                                        int temp;
                                        if (result[m] > result[m + 1])
                                        {
                                            temp = result[m + 1];
                                            result[m + 1] = result[m];
                                            result[m] = temp;
                                        }
                                    }
                                }
                                if (collections.Count > 0)
                                {
                                    //查找是否有重复值
                                    for (int l = 0; l < collections.Count; l++)
                                    {
                                        if (collections[l][0] == result[0] && collections[l][1] == result[1] && collections[l][2] == result[2])
                                            break;
                                        if (l == collections.Count - 1)
                                        {
                                            collection = new List<int>();
                                            collection.Add(result[0]);
                                            collection.Add(result[1]);
                                            collection.Add(result[2]);
                                            collection.Add(result[3]);
                                            collections.Add(collection);
                                        }
                                    }
                                }


                                if (collections.Count == 0)
                                {
                                    collection = new List<int>();
                                    collection.Add(result[0]);
                                    collection.Add(result[1]);
                                    collection.Add(result[2]);
                                    collection.Add(result[3]);
                                    collections.Add(collection);
                                }

                            }
                        }
                    }
                }
            }
            stopwatch.Stop();

            Stopwatch w2 = new Stopwatch();
            w2.Start();
            //按第一个数排序
            for (int i = 0; i < collections.Count; i++)
            {
                for (int j = 0; j < collections.Count - 1; j++)
                {
                    if (collections[j][0] > collections[j + 1][0])
                    {
                        List<int> temp = new List<int>();
                        temp = collections[j];
                        collections[j] = collections[j + 1];
                        collections[j + 1] = temp;
                    }
                }
            }
            //第一个数相等，按第二个数排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0])
                    {
                        if (collections[i][1] > collections[i + 1][1])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            //前两个数相等，按第三个排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0] && collections[i][1] == collections[i + 1][1])
                    {
                        if (collections[i][2] > collections[i + 1][2])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            w2.Stop();
            return collections;
        }

        /// <summary>
        /// 第三版，不再计算重复值，选择三个数和，target对比，使用二分法查找，不再一个个的遍历试数，估计会快很多。
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static public List<List<int>> fourSum3(int[] numbers, int target)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            List<List<int>> collections = new List<List<int>>();
            List<int> collection = new List<int>();
            int[] result = new int[4];
            //冒泡排序，由小到大
            for (int i = 0; i < numbers.Length - 1; i++)
            {

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    int temp;
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            // List<int> targetInts = numbers.ToList();
            for (int i = 0; i < numbers.Length - 3; i++)
            {
                for (int j = i + 1; j < numbers.Length - 2; j++)
                {
                    for (int k = j + 1; k < numbers.Length - 1; k++)
                    {
                        List<int> targetInts = numbers.ToList();

                        targetInts.RemoveAt(i);
                        targetInts.RemoveAt(j - 1);
                        targetInts.RemoveAt(k - 2);

                        if (numbers[i] == 0 && numbers[j] == 0)
                        { }
                        int FindNum = target - (numbers[i] + numbers[j] + numbers[k]);


                        int? FindInt = OneHalfMethod(targetInts, FindNum);
                        if (FindInt == null) continue;

                        result[0] = numbers[i];
                        result[1] = numbers[j];
                        result[2] = numbers[k];
                        result[3] = (int)FindInt;
                        //单个集合中按大小排序
                        for (int n = 0; n <= 2; n++)
                        {
                            for (int m = 0; m < 3; m++)
                            {
                                int temp;
                                if (result[m] > result[m + 1])
                                {
                                    temp = result[m + 1];
                                    result[m + 1] = result[m];
                                    result[m] = temp;
                                }
                            }
                        }
                        if (collections.Count > 0)
                        {
                            //查找是否有重复值
                            for (int l = 0; l < collections.Count; l++)
                            {
                                if (collections[l][0] == result[0] && collections[l][1] == result[1] &&
                                    collections[l][2] == result[2])
                                {

                                    break;
                                }
                                if (l == collections.Count - 1)
                                {
                                    collection = new List<int>();
                                    collection.Add(result[0]);
                                    collection.Add(result[1]);
                                    collection.Add(result[2]);
                                    collection.Add(result[3]);
                                    collections.Add(collection);
                                }
                            }
                        }


                        if (collections.Count == 0)
                        {
                            collection = new List<int>();
                            collection.Add(result[0]);
                            collection.Add(result[1]);
                            collection.Add(result[2]);
                            collection.Add(result[3]);
                            collections.Add(collection);
                        }



                    }
                }
            }
            stopwatch.Stop();

            Stopwatch w2 = new Stopwatch();
            w2.Start();
            //按第一个数排序
            for (int i = 0; i < collections.Count; i++)
            {
                for (int j = 0; j < collections.Count - 1; j++)
                {
                    if (collections[j][0] > collections[j + 1][0])
                    {
                        List<int> temp = new List<int>();
                        temp = collections[j];
                        collections[j] = collections[j + 1];
                        collections[j + 1] = temp;
                    }
                }
            }
            //第一个数相等，按第二个数排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0])
                    {
                        if (collections[i][1] > collections[i + 1][1])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            //前两个数相等，按第三个排序
            for (int j = 0; j < collections.Count; j++)
            {
                for (int i = 0; i < collections.Count - 1; i++)
                {
                    if (collections[i][0] == collections[i + 1][0] && collections[i][1] == collections[i + 1][1])
                    {
                        if (collections[i][2] > collections[i + 1][2])
                        {
                            List<int> temp = new List<int>();
                            temp = collections[i];
                            collections[i] = collections[i + 1];
                            collections[i + 1] = temp;
                        }
                    }
                }
            }
            w2.Stop();
            return collections;
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int? OneHalfMethod(List<int> nums, int target)
        {
            int low = 0;
            int high = nums.Count - 1;
            int mid;
            while (low < high)
            {
                mid = (low + high) / 2;
                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return nums[mid];
                }
            }
            return null;

        }

    }

}
