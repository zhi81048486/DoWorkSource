using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSomething
{
    class Program
    {
        static string str = "I'm static";
        static readonly List<string> ListStr = new List<string>() { "str1", "str2", "str3" };       
        static void Main(string[] args)
        {
           // changed(ref str);
            change_List(ListStr);
            // str1 = str;
            // str1 = "I'm changed";

        }
        static void changed(ref string s)
        {
            //static string str1;
           string str1 = s;   
            str1 = "I'm changed";
            Console.WriteLine("str1: "+ str1);
            Console.WriteLine("str: "+str);
            Console.ReadKey();
        }        
        static void change_List(List<string> lists)
        {
            List<string> list1 = lists;
            list1.Add("str4");
            Console.WriteLine(list1.Count.ToString());
            Console.WriteLine(ListStr.Count.ToString());
            Console.ReadKey();
        }
    }
}
