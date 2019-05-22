
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public abstract class DBConnection<T>
    {
        public static quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();
        
        public DBConnection()
        {
        }
        public static DataSet getData(string query)
        {
            throw new NotImplementedException();

            //MySqlDataAdapter mDataAdapter = new MySqlDataAdapter(query, connection);
            //DataSet Ds = new DataSet();

            //try
            //{
            //    openConnection();

            //    mDataAdapter.Fill(Ds);
            //    return Ds;
            //}
            //catch (Exception e)
            //{
            //    errorString += e.Message + "\n\n";
            //    return null;
            //}
            //finally
            //{
            //    closeConnection();
            //}
        }
        public static List<String> getTableName() //EnvironmentVariableTarget
        {
            quanlyhokhauDataContext ql = new quanlyhokhauDataContext();
            var listTables = (from tables in ql.Mapping.GetTables() select tables.TableName).ToList();
            return listTables;
        }


        public abstract List<T> getAll();
        public abstract bool insert(T data);//can bo thao tac
        public abstract bool insert_table(T data);//admin thao tac
        public abstract bool delete(int row);//admin thao tac
        public abstract bool update(T data);
    }
}
