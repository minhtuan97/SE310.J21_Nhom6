using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "welcome     to    tutlane.com";

            var result = from s in str.ToLowerInvariant().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)

                         select s;

            foreach (var item in result)

            {

                Console.WriteLine(item);

            }

            Console.ReadLine();
        }
    }
}

