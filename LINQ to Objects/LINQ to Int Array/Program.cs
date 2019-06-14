using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Int_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numarr = { 1, 6, 9, 10, 50, 60, 100, 200, 300 };

            IEnumerable<int> result = from a in numarr

                                      where a > 10 && a < 200

                                      select a;

            foreach (int item in result)

            {

                Console.WriteLine(item);

            }

            Console.ReadLine();
        }
    }
}
