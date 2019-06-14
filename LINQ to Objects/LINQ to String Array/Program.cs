using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_String_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Suresh", "Rohini", "Praveen", "Sateesh" };

            IEnumerable<string> result = from a in arr

                                         where a.ToLowerInvariant().StartsWith("s")

                                         select a;

            foreach (string item in result)

            {

                Console.WriteLine(item);

            }

            Console.ReadLine();
        }
    }
}
