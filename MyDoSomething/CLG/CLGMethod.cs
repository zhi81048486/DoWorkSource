using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                for (int j = i; j > 0 && less(items[j - 1], items[j]); j--)
                {
                    exchange(items, j, j - 1);
                }

            }

        }
        #endregion

        #region 希尔排序
        /*
         希尔排序最关键的就是关键点的选取，就是代码中的h。选取合适的关键点后就是分组，然后在每个分组中使用插入排序。修改关键点，重新分组，重新排序
         * 但是最后关键点必须是1，达到两两排序的目的。
         */
        public void ShellSort(T[] items)
        {
            int h = 1;
            while (h < items.Length)
                h = h * 3 + 1;
            while (h >= 1)
            {
                for (int i = h; i < items.Length; i++)
                {
                    for (int j = i; j >= h && less(items[j - h], items[j]); j -= h)
                    {
                        exchange(items, j, j - h);
                        Debug.WriteLine(h.ToString());
                        Debug.Write("j-h:" + (j - h).ToString() + "   ");
                        Debug.Write("j:" + j.ToString() + "   ");
                        for (int k = 0; k < items.Length; k++)
                        {
                            Debug.Write(items[k] + "   ");
                        }
                        Debug.WriteLine("");
                    }
                }
                h = h / 3;
            }
        }

        #endregion

        #region 冒泡排序
        /*
         * 有多少个数字就要执行多少次数，每一次都是大小交换位置。即每次都是从剩下的数中获取最大或最小的数
         */
        public void BubbleSort(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items.Length - 1; j++)
                {
                    if (less(items[j], items[j + 1]))
                    {
                        exchange(items, j, j + 1);
                    }
                }
            }
        }
        #endregion

        #region 快速排序
        /*
         * 快速排序是升级的冒泡排序。用到了递归。让最左边的数作为第一个中间数(取出来)，从最右开始和这个中间数比较，小于中间数的
         * 放到左边，即赋值给这个中间数。此时从左边开始和中间数对比，大于中间数的放到刚刚的右边比中间数小的数的位置
         * 此时，中间数赋值给这时候的左边大的数的位置。返回此时的left位置，为下一个中间数。递归排序。要保证左边的小标要小于右边的下标。
         */
        public void QuickSort(T[] unsort, int left, int right)
        {
            if (left < right)
            {
                int midPosition = GetSplitNum(unsort, left, right);
                QuickSort(unsort, midPosition + 1, right);
                QuickSort(unsort, left, midPosition - 1);
            }
        }


        public int GetSplitNum(T[] unsort, int left, int right)
        {
            T splitNum = unsort[left];
            while (left < right)
            {
                /**
                 * 从右端开始比较
                 * （1）假如从右端过来的数比分隔数要大，则不用处理
                 * （2）假如从右端过来的数比分隔数要小，则需要挪到分隔线左边
                 * */
                while (left < right && less(unsort[right], splitNum))
                {
                    right--;
                }
                unsort[left] = unsort[right];
                /**
                 * 从从端开始比较
                 * （1）假如从左端过来的数比分隔数要小，则不用处理
                 * （2）假如从左端过来的数比分隔数要大，则需要挪到分隔线右边
                 * */
                while (left < right && less(splitNum, unsort[right]))
                {
                    left++;
                }
                unsort[right] = unsort[left];
            }
            //一趟比较之后，分隔数的位置就可以确认起来
            unsort[left] = splitNum;

            return left;
        }
        #endregion

        public void BuckedSort(int[] items)
        {
            int max = items[0];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] > max)
                    max = items[i];
            }
            int[,] items2 = new int[items.Length, items.Length];
            for (int j = 0; j < items.Length; j++)
            {
                int pos = (items[j] * items.Length) / (max + 1);
                if (items2[pos, 0] == null)
                {
                    items2[pos, 0] = items[j];
                }
                else
                {
                    for (int k = 0; k < items.Length / 2 && items2[pos, k] != null; k++)
                    {
                        items2[pos, k] = items[j];
                    }
                }
            }
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items.Length; j++)
                {

                }
            }


        }

    }
}
