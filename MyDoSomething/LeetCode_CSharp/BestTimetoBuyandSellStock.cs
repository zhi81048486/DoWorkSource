using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{/**
 * Say you have an array for which the ith element is the price of a given stock
 * on day i.
 * 
 * If you were only permitted to complete at most one transaction (ie, buy one
 * and sell one share of the stock), design an algorithm to find the maximum
 * profit.
 */
    public class BestTimetoBuyandSellStock
    {
        /*
         * 获取最大利润，一定时最便宜的时候买进，最贵的时候卖出。从第一个开始往后一个一个相减，获取最大值，然后重复第二个数。最后再对比每个数的最大值，得到最大的利润。
         * 但是如果后面的数，比前面的数大的话，就没必要再去一一相减，因此只相减比前面的数小的数。
         */
        public int maxProfit(int[] prices)
        {
            int lowest;
            int maxProfit = 0;
            if (prices.Length > 0)
            {
                lowest = prices[0];
                for (int i = 0; i < prices.Length; i++)
                {
                    //如果后面的值比前面的值小，那么就替换最小值
                    if (lowest > prices[i])
                    {
                        lowest = prices[i];
                    }
                    //不管最小值是否被替换，都应该和当前的值相减，因为第0个值就有可能为最小的。获取了最小值就应该获取最大值，或者获取最大值，就应该获取最小值。
                    maxProfit = Math.Max(maxProfit, prices[i] - lowest);
                }
            }
            return maxProfit;
        }
    }
}
