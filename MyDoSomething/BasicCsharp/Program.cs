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
        //static void Main(string[] args)
        //{
        //    //string str = "First";
        //    //if (str == "First")
        //    //    Console.WriteLine("First");
        //    //else if (str == "Second")
        //    //    Console.WriteLine("Second");
        //    //else if (str == "Third")
        //    //    Console.WriteLine("Third");
        //    //Console.ReadKey();

        //    //MyEqual();

        //    //Console.ReadKey();

        //    //string str = "";
        //    //while (str != "No")
        //    //{
        //    //    FileWatch();
        //    //    str = Console.ReadLine();
        //    //}


        //    int i = 30;
        //    MethodParameters mp = new MethodParameters();
        //    mp.Method1(i);
        //    Console.WriteLine("Out Value:" + i);

        //    string str = "mystring";
        //    mp.Method2(str);
        //    Console.WriteLine("Out　Value:" + str);
        //    Console.WriteLine();
        //    List<string> lists = new List<string>();
        //    lists.Add("1");
        //    lists.Add("2");
        //    mp.Method3(lists);
        //    Console.WriteLine("Out Value" + lists.Count.ToString());

        //    Product item = new Product("Fasteners", 54321);
        //    System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",item.ItemName, item.ItemID);

        //    // Send item to ChangeByReference as a ref argument.
        //    mp.ChangeByReference(item);
        //    System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",item.ItemName, item.ItemID);
        //    Console.WriteLine();
        //    mp.ChangeByReference(ref item);
        //    System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",item.ItemName, item.ItemID);

        //   mp.dosom("dsfs");
        //    Console.ReadKey();
        //}

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
            { Console.WriteLine(true); }
            if (i == j)
                Console.WriteLine(true);
            int i1 = new int();
            i1 = 2;
            if (i.Equals(i1))
                Console.WriteLine(true);
            string str1 = "dd";
            string str2 = "dd";
            string str3 = new string(new char[] { 'd', 'd' });
            str3 = "dd";
            if (str1.Equals(str2))
                Console.WriteLine(true);
            if (str1.Equals(str3))
                Console.WriteLine(true);

        }
    }

    public class MethodParameters : abclass
    {       
        public void Method1(int i)
        {
            i = 10;
            Console.WriteLine("method value:" + i);
        }

        public void Method2(string str)
        {
            str += str + "okl";
            Console.WriteLine("Method value:" + str);
        }
        public void Method3(List<string> list)
        {
            list.Add("xiaoming");
            list.Add("xiaohua");
            Console.WriteLine("Method Value:" + list.Count.ToString());
        }
        public void ChangeByReference(Product itemRef)
        {
            //如果不new的话这时我修改参数的值，实际的值也会改变，如果我new了的话，等于重新分配了一块内存。不会改变实际的值，但是如果使用ref修饰符的话，new不new都会修改实际的值
            itemRef = new Product("Stapler", 99999);
            itemRef.ItemID = 12345;
        }
        public void ChangeByReference(ref Product itemRef)
        {
            //如果不new的话这时我修改参数的值，实际的值也会改变，如果我new了的话，等于重新分配了一块内存。不会改变实际的值，但是如果使用ref修饰符的话，new不new都会修改实际的值
            itemRef = new Product("Ref Stapler", 99999);
            itemRef.ItemID = 12345;
        }
        /// <summary>
        /// 实现抽象类的抽象方法
        /// </summary>
        public override void absmethod()
        {
            throw new NotImplementedException();
        }
    }


    public class Product
    {
        public Product(string name, int newID)
        {
            ItemName = name;
            ItemID = newID;
        }

        public string ItemName { get; set; }
        public int ItemID { get; set; }
    }

    public abstract class abclass
    {
        public void dosom(string str)
        {
            Console.WriteLine(str);
        }

        public abstract void absmethod();

    }
}
