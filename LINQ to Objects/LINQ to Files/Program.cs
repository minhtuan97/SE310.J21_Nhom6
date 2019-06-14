using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo filedir = new DirectoryInfo(@"C:\Users\SiVai\Documents\GitHub\SE310.J21_Nhom6\Nghien Cuu");

            var files = from file in filedir.GetFiles()

                        select new { FileName = file.Name, FileSize = (file.Length / 1024) + " KB" };

            Console.WriteLine("FileName" + "\t | " + "FileSize");

            Console.WriteLine("--------------------------");

            foreach (var item in files)

            {

                Console.WriteLine(item.FileName + "\t | " + item.FileSize);

            }

            Console.ReadLine();
        }
    }
}
