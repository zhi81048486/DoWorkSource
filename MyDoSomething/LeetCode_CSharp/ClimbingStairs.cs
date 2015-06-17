using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
 * You are climbing a stair case. It takes n steps to reach to the top.
 * 
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can
 * you climb to the top?
 */
    public class ClimbingStairs
    {

        //使用动态规划来解决，n个台阶的问题，可以分解为n-1个台阶和n-2个台阶的方法数的和。
        //n个阶梯方法f[n]=f[n-1]+f[n-2]中方法，可以倒着理解，第n个阶梯的最后一步可以是一次一步，也可以是一次两步，如果是一次一步的话就要上到n-1个阶梯，如果是一次两步的话要上到n-2个阶梯
        public int climbStairs(int n)
        {
            //因为考虑到0个台阶的问题，所以arr的个数为n+1
            int[] arr = new int[n + 1];
            arr[0] = arr[1] = 1;
            for (int i = 2; i < arr.Count(); i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n];
        }
    }
}
