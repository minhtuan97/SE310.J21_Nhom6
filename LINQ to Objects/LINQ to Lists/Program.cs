using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> objEmp = new List<Employee>()
            {
                new Employee { EmpId=1,Name = "Suresh Dasari", Location="Chennai" },

                new Employee { EmpId=2,Name = "Rohini Alavala", Location="Chennai" },

                new Employee { EmpId=3,Name = "Praveen Alavala", Location="Guntur" },

                new Employee { EmpId=4,Name = "Sateesh Alavala", Location ="Vizag"},
            };

            var result = from e in objEmp

                         where e.Location.Equals("Chennai")

                         select new
                         {
                             Name = e.Name,
                             Location = e.Location
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + "\t | " + item.Location);
            }

            Console.ReadLine();

        }
    }

    class Employee
    {
        public int EmpId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
