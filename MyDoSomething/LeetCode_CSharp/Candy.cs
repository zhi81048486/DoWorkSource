using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
     * There are N children standing in a line. Each child is assigned a rating
     * value. You are giving candies to these children subjected to the following
     * requirements:
     * 
     * Each child must have at least one candy. Children with a higher rating get
     * more candies than their neighbors.
     * 
     * What is the minimum candies you must give?
     * 
     */

    public class Candy
    {
        //相邻两个小孩等级高的糖果至少要比等级低的多一个。简单来说就是两两对比看谁等级高。等级高的话，就比等级低的多一个。否则就是一个。但是有个起始值的问题。假设第一个小孩是等级最低的和假设第一个小孩是等级最高的是两种不同的情况。所以就先假设第一个小孩是等级最低的。默认糖果个数为1.然后再倒叙，两两对比检查等级高的是否糖果数也多，若正确就不改变，若不正确就比等级低的多一个。
        public int candy(int[] ratings)
        {
            int[] candy = new int[ratings.Length];
            candy[0] = 1;
            for (int i = 1; i < ratings.Length; i++)
            {
                //假设第一个小孩等级交底，相邻两项对比，如果等级高就比相邻的多一个，否则就是一个。
                candy[i] = ratings[i] > ratings[i - 1] ? candy[i - 1] + 1 : 1;
            }
            int totalCandy = candy[ratings.Length - 1];
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                //倒叙检查，排除第一个小孩等级最高的情况。
                candy[i] = (ratings[i] > ratings[i + 1] && candy[i + 1] + 1 > candy[i]) ? candy[i + 1] + 1 : candy[i];
                totalCandy += candy[i];
            }
            return totalCandy;
        }
        
    }
}
