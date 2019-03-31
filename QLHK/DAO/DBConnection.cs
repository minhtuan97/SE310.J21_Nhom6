
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
        public quanlyhokhauDataContext qlhk;
        
        public DBConnection()
        {
            qlhk = new quanlyhokhauDataContext();
        }
        public abstract List<T> getAll();
        public abstract bool insert(T data);//can bo thao tac
        public abstract bool insert_table(T data);//admin thao tac
        public abstract bool delete(int row);//admin thao tac
        public abstract bool update(T data);
    }
}
