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
            //CreatFolder();     
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\QH360Pro\DelFolder";

            DeleFolder(path);

            Console.ReadKey();
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
            //string fileName = System.IO.Path.GetRandomFileName();
            string fileName = "Setting.xml";

            pathString = System.IO.Path.Combine(pathString, fileName);
            Console.WriteLine("Path to my file: {0}\n", pathString);
            if (!System.IO.File.Exists(pathString))
            {
                //创建文件
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

        static void DeleFolder(string strPath)
        {
            try
            {
                //判断文件夹路径是否存在
              //if(Directory.Exists(strPath))
                Directory.Delete(strPath, true);
                if(!Directory.Exists(strPath))
                    Console.Write("delete success!");
                //DirectoryInfo di = new DirectoryInfo(strPath);
                //di.Delete(true);
                
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
        }
    }
}
