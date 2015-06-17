using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{/**
 * Given a set of candidate numbers (C) and a target number (T), find all unique
 * combinations in C where the candidate numbers sums to T.
 * 
 * The same repeated number may be chosen from C unlimited number of times.
 * 
 * Note:
 * 
 * All numbers (including target) will be positive integers.
 * 
 * Elements in a combination (a1, a2, ... , ak) must be in non-descending order.
 * (ie, a1 <= a2 <= ... <= ak).
 * 
 * The solution set must not contain duplicate combinations. For example, given
 * candidate set 2,3,6,7 and target 7, A solution set is: [7] [2, 2, 3]
 */
    public class CombinationSum
    {
        public List<List<int>> combinationSum(int[] candidates,int target)
        {
            List<List<int>>ret=new List<List<int>>();
            List<int> solution=new List<int>();
            Array.Sort(candidates);
            combinationSum(candidates, 0, 0, target, ret, solution);
            return ret;
        }

        private void combinationSum(int[] candidates, int start, int sum, int target, List<List<int>> ret,
            List<int> solution)
        {
            if (sum == target)
            {
                ret.Add(new List<int>(solution));
                return;
            }
            if (sum > target) return;
            for (int i = start; i < candidates.Length; i++)
            {
                solution.Add(candidates[i]);
                combinationSum(candidates, start, sum + candidates[i], target, ret, solution);
                solution.RemoveAt(solution.Count - 1);
            }
        }
    }
}
