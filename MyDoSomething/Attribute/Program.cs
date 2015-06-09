using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            //Old();
            New();
        }
        [Obsolete("Don't use Olde method,use New Method",true)]
        static void Old() { }
        //[System.Serializable]
        static void New()
        {
            Mytext t = new Mytext();
            t.FirstName = "Lily";
            t.LastName = "Joe";
        }

        public string Socia { get; set; }

    }
   // [DebuggerDisplay("FirstName={FirstName},LastName={LastName}")]
    public class Mytext
    {
        public string FirstName;
        public string LastName;
    }
}
