using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "First";
            if (str == "First")
                Console.WriteLine("First");
            else if (str == "Second")
                Console.WriteLine("Second");
            else if (str == "Third")
                Console.WriteLine("Third");
            Console.ReadKey();
        }
    }
}
