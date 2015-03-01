using System;
using System.Collections.Generic;
using System.Collections;
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
            // DoSort();
            //int[] ss = new int[] {0,0,0,0,92,0,-3002,0,0,0,-10,-19,0,65,0,0,293,0,1,1,1,9,9,9,10,11,1001,2001,-404,201,203,201,999,345,1,1,1,1,1,1,1,-2,1,1,1,1,1,1,1,1,-2,1,1,1,1,1,1,1,1,1,1,-1200,1,1,1,1,1,2,1202,2,2,-4,2,2,2,2,4,5,6,1,1,-11,1,1,1,1,1,1,1,1,101,1,1,1,1,1,-1,1,-6};
            //threeSum(ss);

            //int[] nums = new int[] { -2, -3, -4, -5, -100, 99, 1, 4, 4, 4, 5, 1, 0, -1, 2, 3, 4, 5 };
            //int target = 77;
            //Console.WriteLine(threeSumClosest(nums, target));
            
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
                for (int j = i+1; j < numbers.Length-1; j++)
                {
                    for (int k =j+1; k < numbers.Length ; k++)
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
            if (System.Math.Abs(sumResults[loca] - target) < System.Math.Abs(sumResults[loca + 1]-target))
            {
                return sumResults[loca];
            }
            else
            {
                return sumResults[loca+1];
            }
        }

    }

}
