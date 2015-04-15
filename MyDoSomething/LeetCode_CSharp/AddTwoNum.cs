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
   public class AddTwoNum
    {
       /*这样多位数相加，但是拆分成一个一个位数上的数相加，需要获取两个值：相加后，进位值，当前位数上的值。获取方法就是除以进制数*/

       public LinkedListNode<int> addTwoNumbers(LinkedListNode<int> NodeA,LinkedListNode<int> NodeB  )
       {
           if (NodeA == null) return NodeB;
           if(NodeB==null) return NodeA;
           LinkedListNode<int> ResultNode=new LinkedListNode<int>(0);
           int yushu = 0;
           int jinshu = 0;
           while (NodeA!=null&& NodeB!=null)
           {
              
               int sum = NodeA.Value + NodeB.Value + jinshu;
               yushu = sum%10;
               jinshu = sum/10;

           }
           return ResultNode;
           

       }

    }
}
