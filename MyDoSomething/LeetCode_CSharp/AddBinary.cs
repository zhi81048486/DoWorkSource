using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
 * Given two binary strings, return their sum (also a binary string).
 * 
 * For example, a = "11" b = "1" Return "100".
 */
    public class AddBinary
    {
        /*
         * 二进制相加，从低位算起，相加得值，与二相除，除数为1进位，余数则记录，依次算起，最后得到的是反向的二进制字符串
         */
        public string addBinary(string a, string b)
        {
            int aLength = a.Length - 1;
            int bLength = b.Length - 1;
            int aValue = 0;
            int bValue = 0;
            int abValue = 0;
            //因为字符串是不可更改的，如果改变的话只是创建了字符串的一个副本，所以这里new一个StringBuild对象。
            StringBuilder binaryBuilder = new StringBuilder();
            //只要有一个算到底就停止
            while (aLength >= 0 && bLength >= 0)
            {
                //字符串根据位置查找字符
                aValue = a.ElementAt(aLength) == 0 ? 0 : 1;
                bValue = b.ElementAt(aLength) == 0 ? 0 : 1;
                aLength--;
                bLength--;
                int value = aValue + bValue + abValue;
                //这里获取余数，不是进位数
                binaryBuilder.Append((value % 2) == 0 ? 0 : 1);
                //右移一位，即除以2，获取除数，进位数
                abValue = value >> 1;
            }
            //字符串b算完了，但是字符串a没有算完
            while (aLength>=0)
            {
                aValue = a.ElementAt(aLength) == 0 ? 0 : 1;
                int value = aValue + abValue;
                binaryBuilder.Append((value%2) == 0 ? 0 : 1);
                abValue = value >> 1;
                aLength--;
            }
            while (bLength>=0)
            {
                bValue = a.ElementAt(bLength) == 0 ? 0 : 1;
                int value = bValue + abValue;
                binaryBuilder.Append((value%2) == 0 ? 0 : 1);
                abValue = value >> 1;
                bLength--;
            }
            if (abValue == 1)
            {
                binaryBuilder.Append(1);
            }
            string result = binaryBuilder.ToString();
            return result.Reverse().ToString();
        }
    }
}
