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
 * Design an algorithm to find the maximum profit. You may complete as many
 * transactions as you like (ie, buy one and sell one share of the stock
 * multiple times). However, you may not engage in multiple transactions at the
 * same time (ie, you must sell the stock before you buy again).
 */

    /*
     * 解答：其实转化一下就很好理解，画一个竖状图，横坐标为i，竖坐标为股价，获取最大利益，就是利益叠加，图中的利益值就是相邻的两个
     * 图的差值，只要差值为正，就可以获取利益，最后将这些利益相加，即为最大利益。
     */
    public class BestTimeToBuyAndSellStock2
    {
        public int maxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int d = prices[i] - prices[i - 1];
                if (d > 0)
                {
                    profit += d;
                }
            }
            return profit;
        }

    }
}
