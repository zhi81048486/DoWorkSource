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
     * 可以有两次操作。把利润分成了两个区间， 首先是在0-k之间找到最大值，然后在k+1-n之间找最大值。最后得到两者和的最大值即为结果。
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
            //因为可以确定是从第一天开始的，所以可以确定第一天的值来获取最大值。依次对比最小值，和最大插值。
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
            //因为肯定是要对比到最后一天才可以知道结果，所以就从最后一天开始算起
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
