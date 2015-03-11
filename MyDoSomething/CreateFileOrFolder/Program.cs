using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CreateFileOrFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreatFile();
            CreatFolder();
        }

        static void CreatFile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SettingColumn.xml");
            if (!File.Exists(path))
            {
                System.IO.File.Create(path);
            }
        }

        static void CreatFolder()
        {
            string folderName = @"E:\";
            string pathString = System.IO.Path.Combine(folderName, "SubFolder");
           
            //创建目录
            System.IO.Directory.CreateDirectory(pathString); 
            string fileName = System.IO.Path.GetRandomFileName();
            pathString = System.IO.Path.Combine(pathString, fileName);
            Console.WriteLine("Path to my file: {0}\n", pathString);
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            // Read and display the data from your file.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

    }
}
