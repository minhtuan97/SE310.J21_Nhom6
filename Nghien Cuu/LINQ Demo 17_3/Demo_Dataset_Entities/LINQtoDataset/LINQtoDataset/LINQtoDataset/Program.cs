using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LINQtoDataset
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-I7ONUUU\SQLEXPRESS;Initial Catalog=learingsql;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);

            string sqlSelect ="SELECT * FROM EMPLOYEE;";

            // Create the data adapter to retrieve data from the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectionString);


            // Create table mappings
            da.TableMappings.Add("Table", "EMPLOYEE");

            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable employee = ds.Tables["EMPLOYEE"];


            /////1. Tạo truy vấn - Query Syntax
            //var query = from d in employee.AsEnumerable()
            //            select new
            //            {
            //                Employee = d.Field<string>("FIRST_NAME")
            //            };


            /////2. Tao truy vấn - Method Syntax
            //var query = employee.AsEnumerable().Select(p => p.Field<string>("FIRST_NAME"));




            //3. Kết hợp truy vấn
            //Tìm những nhân viên vào làm năm 2001
            var firstquery = from empf in employee.AsEnumerable()
                             where empf.Field<DateTime>("START_DATE").Year == 2001
                             select empf;
            //Tìm tên của những nhân viên vào làm năm 2001, có họ là Smith
            var query = firstquery.Where(p => p.Field<string>("LAST_NAME") == "Smith")
                             .Select(p=>p.Field<String>("FIRST_NAME"));



            //Thực thi truy vấn
            foreach (var q in query)
            {
                Console.WriteLine("Employee: "+q);
            }






            Console.ReadLine();

        }
    }
}
