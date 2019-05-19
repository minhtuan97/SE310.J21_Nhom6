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
    public class TinhThanhPhoDAO:DBConnection<TINHTHANHPHO>
    {
        public TinhThanhPhoDAO() : base() { }

        public override List<TINHTHANHPHO> getAll()
        {
            TINHTHANHPHO nk = new TINHTHANHPHO();
            var kq = from tptv in qlhk.TINHTHANHPHOs
                     select tptv;
            List<TINHTHANHPHO> x = kq.ToList();
            return x;
        }
        public override bool insert_table(TINHTHANHPHO data)
        {
            qlhk.TINHTHANHPHOs.InsertOnSubmit(data);
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
        public override bool insert(TINHTHANHPHO tinhThanh)
        {
            qlhk.TINHTHANHPHOs.InsertOnSubmit(tinhThanh);
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
        public bool deleteTTP(string id)
        {
            var kq =
           from ttp in qlhk.TINHTHANHPHOs
           where ttp.matp == id
           select ttp;

            foreach (var detail in kq)
            {
                qlhk.TINHTHANHPHOs.DeleteOnSubmit(detail);
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
                List<TINHTHANHPHO> kq = this.getAll();
                TINHTHANHPHO[] arr = kq.ToArray();
                qlhk.TINHTHANHPHOs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(TINHTHANHPHO tinhThanh)
        {
            var query =
               from tptv in qlhk.TINHTHANHPHOs
               where tinhThanh.matp == tptv.matp
               select tptv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TINHTHANHPHO kq in query)
            {
                kq.matp = tinhThanh.matp;
                kq.kieu = tinhThanh.kieu;
                kq.ten = tinhThanh.ten;
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
        public List<TINHTHANHPHO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM tinhthanhpho" + query;
            var res = qlhk.ExecuteQuery<TINHTHANHPHO>(query).ToList();

            return res;
        }

    }
}
