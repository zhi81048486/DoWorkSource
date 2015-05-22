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
        public int candy(int[] ratings)
        {
            int[] candy = new int[ratings.Length];
            candy[0] = 1;
            for (int i = 1; i < ratings.Length; i++)
            {
                //第i个人的等级比第前一个人的等级高，那么第i个人糖果至少要比他前面的一个人多一个糖果，否则就是最少的糖果个数1。这里只是两两相互比较。
                candy[i] = ratings[i] > ratings[i - 1] ? candy[i - 1] + 1 : 1;
            }
            int totalCandy = candy[ratings.Length - 1];
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                //如果第i个人的等级比他后面的人的等级要高，但是糖果个数却是后面等级低的人多于前面等级高的人。这时等级高的人就要比后面的人多一个糖果。否则就是之前的糖果个数。
                candy[i] = (ratings[i] > ratings[i + 1] && candy[i + 1] + 1 > candy[i]) ? candy[i + 1] + 1 : candy[i];
                totalCandy += candy[i];
            }
            return totalCandy;
        }
        
    }
}
