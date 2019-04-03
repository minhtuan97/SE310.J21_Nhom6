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
    public class TinhThanhPhoDAO:DBConnection<TinhThanhPhoDTO>
    {
        public TinhThanhPhoDAO() : base() { }

        public override List<TinhThanhPhoDTO> getAll()
        {
            TinhThanhPhoDTO nk = new TinhThanhPhoDTO();
            var kq = from tptv in qlhk.TINHTHANHPHOs
                     select new TinhThanhPhoDTO
                     {
                         db = tptv
                     };
            List<TinhThanhPhoDTO> x = kq.ToList();
            return x;
        }
        public override bool insert_table(TinhThanhPhoDTO data)
        {
            qlhk.TINHTHANHPHOs.InsertOnSubmit(data.db);
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
        public override bool insert(TinhThanhPhoDTO tinhThanh)
        {
            qlhk.TINHTHANHPHOs.InsertOnSubmit(tinhThanh.db);
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
                List<TinhThanhPhoDTO> kq = this.getAll();
                TinhThanhPhoDTO[] arr = kq.ToArray();
                qlhk.TINHTHANHPHOs.DeleteOnSubmit(arr[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(TinhThanhPhoDTO tinhThanh)
        {
            var query =
               from tptv in qlhk.TINHTHANHPHOs
               where tinhThanh.db.matp == tptv.matp
               select tptv;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TINHTHANHPHO kq in query)
            {
                kq.matp = tinhThanh.db.matp;
                kq.kieu = tinhThanh.db.kieu;
                kq.ten = tinhThanh.db.ten;
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
        public List<TinhThanhPhoDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM tinhthanhpho" + query;
            var res = qlhk.ExecuteQuery<TINHTHANHPHO>(query).ToList();
            List<TinhThanhPhoDTO> lst = new List<TinhThanhPhoDTO>();
            foreach (TINHTHANHPHO i in res)
            {
                TinhThanhPhoDTO ts = new TinhThanhPhoDTO(i);
                lst.Add(ts);
            }

            return lst;
        }

    }
}
