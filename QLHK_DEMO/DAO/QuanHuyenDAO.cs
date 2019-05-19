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
    public class QuanHuyenDAO:DBConnection<QUANHUYEN>
    {
        public QuanHuyenDAO() : base() { }

        public override List<QUANHUYEN> getAll()
        {
            QUANHUYEN nk = new QUANHUYEN();
            var kq = from quanhuyendto in qlhk.QUANHUYENs
                     select quanhuyendto;
            List<QUANHUYEN> x = kq.ToList();
            return x;
        }

        public override bool insert(QUANHUYEN quanHuyen)
        {
            qlhk.QUANHUYENs.InsertOnSubmit(quanHuyen);
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
        public override bool insert_table(QUANHUYEN data)
        {
            qlhk.QUANHUYENs.InsertOnSubmit(data);
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

        public bool deleteQH(string id)
        {
            var kq =
            from qh in qlhk.QUANHUYENs
            where qh.maqh == id
            select qh;

            foreach (var detail in kq)
            {
                qlhk.QUANHUYENs.DeleteOnSubmit(detail);
            }

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                // Provide for exceptions.
            }
        }

        public override bool delete(int row)
        {
            try
            {
                List<QUANHUYEN> kq = this.getAll();
                QUANHUYEN[] arr = kq.ToArray();
                qlhk.QUANHUYENs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(QUANHUYEN quanHuyen)
        {
            var query =
               from qhtv in qlhk.QUANHUYENs
               where quanHuyen.maqh == qhtv.maqh
               select qhtv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (QUANHUYEN kq in query)
            {
                kq.maqh = quanHuyen.maqh;
                kq.matp = quanHuyen.matp;
                kq.kieu = quanHuyen.kieu;
                kq.ten = quanHuyen.ten;

            
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

        public List<QUANHUYEN> TimKiem(string query)
        {

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM quanhuyen" + query;
            var res = qlhk.ExecuteQuery<QUANHUYEN>(query).ToList();

            return res;
            
        }
    }
}
