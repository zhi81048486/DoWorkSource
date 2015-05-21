using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
     * Say you have an array for which the ith element is the price of a given stock
     * on day i.
     * 
     * Design an algorithm to find the maximum profit. You may complete at most two
     * transactions.
     * 
     * Note: You may not engage in multiple transactions at the same time (ie, you
     * must sell the stock before you buy again).
     */
    /*
     * 可以有两次操作。所以就是第一次操作之后，再剩下的数据中再进行一次同第一次一样的操作。不同的就是两次操作的起始值很有可能是不同的。
     * 所以第一次操作时找到最小值，就看什么时候卖出能获得最大收益，第二次操作找到最大值，就看什么时候买进能获得最大收益。
     */

    public class BestTimeToBuyAndSellStock3
    {
        public int maxProfit(int[] prices)
        {
            int length = prices.Length;
            if (length == 0) return 0;
            int profit = 0;
            int lowest = prices[0];
            int[] left = new int[length];
            int[] right = new int[length];
            for (int i = 1; i < length; i++)
            {
                if (prices[i] < lowest)
                {
                    lowest = prices[i];
                }
                else if (prices[i] - lowest > profit)
                {
                    profit = prices[i] - lowest;
                }
                //跟据最小值从第一天往后开始计算最大利润
                left[i] = profit;
            }
            profit = 0;
            int topest = prices[length - 1];
            for (int j = length - 2; j >= 0; j--)
            {
                if (prices[j] > topest)
                {
                    topest = prices[j];
                }
                else if (topest - prices[j] > profit)
                {
                    profit = topest - prices[j];
                }
                //根据最大值由最后一天到第一天计算最大利润
                right[length - 1 - j] = profit;
            }
            profit = 0;
            for (int k = 0; k < length; k++)
            {//这里计算的就是第o到k天的利润和第k+1到最后一天的利润
                int p = left[k] + right[length - 1 - k];
                if (p > profit)
                {
                    profit = p;
                }
            }
            return profit;
        }
    }
}
