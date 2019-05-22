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
    public class XaPhuongThiTranDAO:DBConnection<XAPHUONGTHITRAN>
    {
        public XaPhuongThiTranDAO() : base() { }

        public override List<XAPHUONGTHITRAN> getAll()
        {
            XAPHUONGTHITRAN nk = new XAPHUONGTHITRAN();
            var kq = from xptttv in qlhk.XAPHUONGTHITRANs
                     select xptttv;
            List<XAPHUONGTHITRAN> x = kq.ToList();
            return x;
        }

        public override bool insert(XAPHUONGTHITRAN xaphuong)
        {
            qlhk.XAPHUONGTHITRANs.InsertOnSubmit(xaphuong);
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
        public override bool insert_table(XAPHUONGTHITRAN data)
        {
            qlhk.XAPHUONGTHITRANs.InsertOnSubmit(data);
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
        public bool deleteXPTT(string id)
        {
            var kq =
            from xptt in qlhk.XAPHUONGTHITRANs
            where xptt.maxp == id
            select xptt;

            foreach (var detail in kq)
            {
                qlhk.XAPHUONGTHITRANs.DeleteOnSubmit(detail);
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
                List<XAPHUONGTHITRAN> kq = this.getAll();
                XAPHUONGTHITRAN[] arr = kq.ToArray();
                qlhk.XAPHUONGTHITRANs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(XAPHUONGTHITRAN xaphuong)
        {
            var query =
                from xptttv in qlhk.XAPHUONGTHITRANs
                where xaphuong.maxp == xptttv.maxp
                select xptttv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (XAPHUONGTHITRAN kq in query)
            {
                kq.maxp = xaphuong.maxp;
                kq.maqh = xaphuong.maqh;
                kq.kieu = xaphuong.kieu;
                kq.ten = xaphuong.ten;
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

        public List<XAPHUONGTHITRAN> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM xaphuongthitran" + query;
            var res = qlhk.ExecuteQuery<XAPHUONGTHITRAN>(query).ToList();

            return res;
        }
    }
}
