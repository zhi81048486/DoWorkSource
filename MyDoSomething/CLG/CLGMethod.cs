using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLG
{
    public class CLGMethod<T> where T : IComparable
    {
        public bool less(T t1, T t2)
        {
            return (t1.CompareTo(t2) > 0);
        }
        public bool greater(T t1, T t2)
        {
            return (t1.CompareTo(t2) < 0);
        }
        public void exchange(T[] items, int i1, int i2)
        {
            T temp = items[i2];
            items[i2] = items[i1];
            items[i1] = temp;
        }

        #region 选择排序
        /*
         *从第一个数开始和其余的数一一比较，获得较小的数后，和之后的数再一一对比
         * 知道获得最小的数，并和第一个数交换位置。
         * 即第一次选择最小的数，放到第一个位置，以此类推。
         */
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="items"></param>
        public void SelectSort(T[] items)
        {
            //int[] Sorts = new int[] { 1, 3, 5, 6, 2, 15, 7, 10, 4 };
            for (int i = 0; i < items.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (less(items[min], items[j]))
                        min = j;
                }
                exchange(items, min, i);
            }
        } 
        #endregion

        #region  插入排序
        /*
         插入排序，从不是第一个元素开始，从它的左侧，两两相比，排序，然后从开始元素的右侧元素重复。直到最右侧。
         * 
         */
        public void InsertSort(T[] items)
        {
            for (int i = 4; i < items.Length; i++)
            {
                for (int j = i; j > 0 && less(items[j-1], items[j]); j--)
                {
                    exchange(items, j, j - 1);
                }

            }

        } 
        #endregion

    }
}
