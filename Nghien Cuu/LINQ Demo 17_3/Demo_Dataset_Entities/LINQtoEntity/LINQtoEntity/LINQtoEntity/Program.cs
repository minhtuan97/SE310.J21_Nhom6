using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //Source
            learning_sqlEntities context = new learning_sqlEntities();


            //Query
            //var query = from emp in context.employees
            //            select new
            //            {
            //            FirstName = emp.FIRST_NAME,
            //            LastName = emp.LAST_NAME,
            //            };

            ////Execute
            //foreach (var item in query)
            //{
            //    Console.WriteLine("Employee:  {0}  {1}", item.LastName, item.FirstName);
            //}


            ///2. INSERT
            ////Create new Object
            //employee emp = new employee
            //{
            //    FIRST_NAME = "Hung",
            //    LAST_NAME = "Nguyen",
            //    START_DATE = new DateTime(2019, 3, 3)
            //};

            ////Add the new Object to the Employee collection
            //context.employees.Add(emp);

            ////Submit change
            //try
            //{
            //    context.SaveChanges();
            //    Console.WriteLine("Successfully....");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}


            ///3. UPDATE
            //Select row to be updated
            //var query = from emp in context.employees
            //            where emp.TITLE == "Teller"
            //            select emp;


            ////execute query and change the column values you want to change
            //foreach(employee e in query)
            //{
            //    e.TITLE = "None";
            //}


            //try
            //{
            //    context.SaveChanges();
            //    Console.WriteLine("Successfully...");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}



            ///4. DELETE
            // Query the rows to be delete
            //IQueryable<employee> query = from emp in context.employees
            //                             where emp.LAST_NAME == "Nguyen"
            //                             select emp;

            //foreach (employee e in query)
            //{
            //    context.employees.Remove(e);
            //}

            //try
            //{
            //    context.SaveChanges();
            //    Console.WriteLine("Successfully...");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}




            //Pause
            Console.ReadLine();
        }
    }
}
