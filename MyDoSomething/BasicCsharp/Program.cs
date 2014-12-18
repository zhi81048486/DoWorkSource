using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BasicCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = "First";
            //if (str == "First")
            //    Console.WriteLine("First");
            //else if (str == "Second")
            //    Console.WriteLine("Second");
            //else if (str == "Third")
            //    Console.WriteLine("Third");
            //Console.ReadKey();

            MyEqual();

            Console.ReadKey();

            //string str = "";
            //while (str != "No")
            //{
            //    FileWatch();
            //    str = Console.ReadLine();
            //}
        }

        #region 文件监视
        static void FileWatch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            int index = System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf("\\");
            string _path = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, index);
            watcher.Path = _path;
            watcher.Filter = "";
            watcher.EnableRaisingEvents = true;
            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            Console.WriteLine("FileSystemWatcher ready and listening to changes in :\n\n" + _path);
        }
        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.OldName + " is now: " + e.Name);
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " has changed");

        }

        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " file has been deleted");

        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " file has been created.");

        }
        #endregion

        static void MyEqual()
        {
            int i = 2;
            int j = 2;
            if (i.Equals(j))
            { Console.WriteLine(true);}
            if(i==j)
            Console.WriteLine(true);
            int i1 = new int();
            i1 = 2;
            if (i.Equals(i1))
                Console.WriteLine(true);
            string str1 = "dd";
            string str2 = "dd";
            string str3 = new string(new char[]{'d','d'});
            str3 = "dd";
            if (str1.Equals(str2))
                Console.WriteLine(true);
            if (str1.Equals(str3))
                Console.WriteLine(true);
                 
        }
    }
}
