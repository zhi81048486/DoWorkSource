using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
 * Given an array of strings, return all groups of strings that are anagrams.
 * 
 * Note: All inputs will be in lower-case.
 */
    /*没有头绪！
     字符串是乱序的，但是把字符串排序后，那么字符串就会有相同的。找出相同的字符串即可。
     * 1、字符串按照字符顺序排序。
     * 2、找到相同的字符串
     * 3、输出跟排序后的字符串相同位置的原来的字符串。
     */
    public class Anagrams
    {
        //数组是值类型。
        public List<String> anagrams(String[] strs)
        {
            List<string> SortStrs = new List<string>();
            List<string> ResultStrs = new List<string>();
            //字符串排序
            foreach (string str in strs)
            {
                char[] c = str.ToCharArray();
                Array.Sort(c);
                SortStrs.Add(new string(c));
            }
            //在字符串列表里查找相同的值
            /*
             * 从列表里的第一项开始往后找，然后第二项往后找，但是重新开始查找时如果是相同的项，就跳过。即每次查找只找不同的项
             * 举例：第一项和第二项，第三项一样，那么第二次查找时就从第四项开始。相同的项都标记一下，标识已经查找过了，不用再次查找
             * 
             */
            //标识符，记录字符串是否为重复的字符串
            bool[] strary = new bool[strs.Length];
            //标识符，每次查找的第一项开始后先标识为重复字符串，但是如果没有找到的话，还得标识为不重复字符串。
            int tmp = 0;
            for (int i = 0; i < SortStrs.Count; i++)
            {
                if (!strary[i])
                {
                    strary[i] = true;
                    tmp = 1;
                    for (int j = i + 1; j < SortStrs.Count; j++)
                    {
                        if (!strary[j] && SortStrs[i].Equals(SortStrs[j]))
                        {
                            strary[j] = true;
                            tmp++;
                        }
                    }
                    if (tmp == 1)
                        strary[i] = false;
                }

            }
            for (int i = 0; i < strary.Length; i++)
            {
                //根据位置的标识来判断是否为乱序字符串。
                //整个算法中，并没有改变参数字符串数组
                if (strary[i])
                    ResultStrs.Add(strs[i]);
            }
            return ResultStrs;
        }
    }
}
