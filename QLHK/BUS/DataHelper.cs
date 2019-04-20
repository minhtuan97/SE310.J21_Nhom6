using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class DataHelper
    {
        public static DataTable ListToDatatable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable ListToDataTableWithChange<T>(List<T> items)
        {
            DataTable table = ListToDatatable<T>(items);

            //if (table.Rows.Count > 0)
            //{

            //    DataRow fRow = table.Rows[0];
            //    for (int i = 0; i < table.Columns.Count; i++)
            //    {
            //        if (fRow[i].ToString().Contains("DTO."))
            //        {
            //            table.Columns.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //}

            for (int i = 0; i < table.Columns.Count; i++)
            {
                Type t = table.Columns[i].DataType;
                if ( t==typeof(CANBO) || t == typeof(HOCSINHSINHVIEN) || t == typeof(NHANKHAU) || t == typeof(NHANKHAUTAMTRU) || t == typeof(NHANKHAUTAMVANG) 
                    || t == typeof(NHANKHAUTHUONGTRU) || t == typeof(QUANHUYEN) || t == typeof(SOHOKHAU) || t == typeof(SOTAMTRU) 
                    || t == typeof(TIENANTIENSU) || t == typeof(TIEUSU) || t == typeof(TINHTHANHPHO) || t == typeof(XAPHUONGTHITRAN))
                {
                    table.Columns.RemoveAt(i);
                    i--;
                }
            }
            table.Columns.Add(new DataColumn("Change"));
            

            return table;
        }

        public static DataTable mergeTwoTables(DataTable table1, DataTable table2, string joinColumn)
        {
            DataTable tb = table1.Copy();
            if (!string.IsNullOrEmpty(joinColumn))
            {
                tb.PrimaryKey = new DataColumn[] { tb.Columns[joinColumn] };
                table2.PrimaryKey = new DataColumn[] { table2.Columns[joinColumn] };
            }
            tb.Merge(table2);

            return tb;
                
        }
    }
}
