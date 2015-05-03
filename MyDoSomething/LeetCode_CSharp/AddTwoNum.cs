using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_CSharp
{
    /**
 * You are given two linked lists representing two non-negative numbers. 
 * 
 * The digits are stored in reverse order and each of their nodes contain a single digit.
 * 
 * Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
 * 
 * Output: 7 -> 0 -> 8
 */
    public class ListNode<T>
    {
        public T Val;
        public ListNode<T> Next;

        public ListNode(T x)
        {
            Val = x;
            Next = null;
        }
    }
    public class AddTwoNum
    {
        /*这样多位数相加，但是拆分成一个一个位数上的数相加，需要获取两个值：相加后，进位值，当前位数上的值。获取方法就是除以进制数*/

        public ListNode<int> addTwoNumbers(ListNode<int> LNodeA, ListNode<int> LNodeB)
        {
            if (LNodeA == null) return LNodeB;
            if (LNodeB == null) return LNodeA;
            ListNode<int> Sample=new ListNode<int>(0);
            ListNode<int> ResultNode = Sample;
            //余数
            int Residue = 0;
            //进位数
            int Carry = 0;
            while (LNodeA != null && LNodeB != null)
            {
                int sum = LNodeA.Val + LNodeB.Val + Carry;
                Residue = sum % 10;
                Carry = sum / 10;
                LNodeA = LNodeA.Next;
                LNodeB = LNodeB.Next;
                ResultNode.Next = new ListNode<int>(Residue);
                ResultNode = ResultNode.Next;
            }

            while (LNodeA != null)
            {
                int sum = LNodeA.Val + Carry;
                Residue = sum % 10;
                Carry = sum / 10;
                LNodeA = LNodeA.Next;
                //也可以递归的调用addTwoNumbers（LNodeaA,New ListNode<int> LNodec(Residue)）
                ResultNode.Next = new ListNode<int>(Residue);
                ResultNode = ResultNode.Next;
            }
            while (LNodeB != null)
            {
                int sum = LNodeB.Val + Carry;
                Residue = sum % 10;
                Carry = sum / 10;
                LNodeB = LNodeB.Next;
                ResultNode.Next = new ListNode<int>(Residue);
                ResultNode = ResultNode.Next;
            }
            //最后要判断进位数是否大于0，
            if (Carry != 0)
            {
                ResultNode.Next=new ListNode<int>(Carry);
            }
            return Sample.Next;

        }
        /*这样一列数中一个一个的相加，要把数一个一个的读出来，然后相加，再放到一个列表里，所以就是有三个问题怎么一个个的读？怎么加（运算）？怎么把运算后的数存起来？*/

    }
}
