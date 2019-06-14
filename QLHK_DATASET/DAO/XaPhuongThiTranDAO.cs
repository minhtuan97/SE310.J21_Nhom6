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
    public class XaPhuongThiTranDAO:DBConnection<XaPhuongThiTranDTO>
    {
        public XaPhuongThiTranDAO() : base() { }

        public override List<XaPhuongThiTranDTO> getAll()
        {
            XaPhuongThiTranDTO nk = new XaPhuongThiTranDTO();
            var kq = from xptttv in qlhk.XAPHUONGTHITRANs
                     select new XaPhuongThiTranDTO
                     {
                         db = xptttv
                     };
            List<XaPhuongThiTranDTO> x = kq.ToList();
            return x;
        }

        public override bool insert(XaPhuongThiTranDTO xaphuong)
        {
            qlhk.XAPHUONGTHITRANs.InsertOnSubmit(xaphuong.db);
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
        public override bool insert_table(XaPhuongThiTranDTO data)
        {
            qlhk.XAPHUONGTHITRANs.InsertOnSubmit(data.db);
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
                List<XaPhuongThiTranDTO> kq = this.getAll();
                XaPhuongThiTranDTO[] arr = kq.ToArray();
                qlhk.XAPHUONGTHITRANs.DeleteOnSubmit(arr[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(XaPhuongThiTranDTO xaphuong)
        {
            var query =
                from xptttv in qlhk.XAPHUONGTHITRANs
                where xaphuong.db.maxp == xptttv.maxp
                select xptttv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (XAPHUONGTHITRAN kq in query)
            {
                kq.maxp = xaphuong.db.maxp;
                kq.maqh = xaphuong.db.maqh;
                kq.kieu = xaphuong.db.kieu;
                kq.ten = xaphuong.db.ten;
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

        public List<XaPhuongThiTranDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM xaphuongthitran" + query;
            var res = qlhk.ExecuteQuery<XAPHUONGTHITRAN>(query).ToList();
            List<XaPhuongThiTranDTO> lst = new List<XaPhuongThiTranDTO>();
            foreach (XAPHUONGTHITRAN i in res)
            {
                XaPhuongThiTranDTO ts = new XaPhuongThiTranDTO(i);
                lst.Add(ts);
            }

            return lst;
        }
    }
}
