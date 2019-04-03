using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
//using MySql.Data.MySqlClient;

namespace DAO
{
    public class QuanHuyenDAO:DBConnection<QuanHuyenDTO>
    {
        public QuanHuyenDAO() : base() { }

        public override List<QuanHuyenDTO> getAll()
        {
            QuanHuyenDTO nk = new QuanHuyenDTO();
            var kq = from quanhuyendto in qlhk.QUANHUYENs
                     select new QuanHuyenDTO
                     {
                         db = quanhuyendto
                     };
            List<QuanHuyenDTO> x = kq.ToList();
            return x;
        }

        public override bool insert(QuanHuyenDTO quanHuyen)
        {
            qlhk.QUANHUYENs.InsertOnSubmit(quanHuyen.db);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SubmitChanges();
                return false;
            }
        }
        public override bool insert_table(QuanHuyenDTO data)
        {
            qlhk.QUANHUYENs.InsertOnSubmit(data.db);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SubmitChanges();
                return false;
            }
        }

        public override bool delete(int row)
        {
            try
            {
                List<QuanHuyenDTO> kq = this.getAll();
                QuanHuyenDTO[] arr = kq.ToArray();
                qlhk.QUANHUYENs.DeleteOnSubmit(arr[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(QuanHuyenDTO quanHuyen)
        {
            var query =
               from qhtv in qlhk.QUANHUYENs
               where quanHuyen.db.maqh == qhtv.maqh
               select qhtv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (QUANHUYEN kq in query)
            {
                kq.maqh = quanHuyen.db.maqh;
                kq.matp = quanHuyen.db.matp;
                kq.kieu = quanHuyen.db.kieu;
                kq.ten = quanHuyen.db.ten;

            
            }

            // Submit the changes to the database.
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return false;
            }
        }

        public List<QuanHuyenDTO> TimKiem(string query)
        {

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM quanhuyen" + query;
            var res = qlhk.ExecuteQuery<QUANHUYEN>(query).ToList();
            List<QuanHuyenDTO> lst = new List<QuanHuyenDTO>();
            foreach (QUANHUYEN i in res)
            {
                QuanHuyenDTO ts = new QuanHuyenDTO(i);
                lst.Add(ts);
            }

            return lst;
            
        }
    }
}
