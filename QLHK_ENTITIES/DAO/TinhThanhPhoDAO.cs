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
            var kq = from tptv in qlhk.TINHTHANHPHOes
                     select new TinhThanhPhoDTO
                     {
                         db = tptv
                     };
            List<TinhThanhPhoDTO> x = kq.ToList();
            return x;
        }
        public override bool insert_table(TinhThanhPhoDTO data)
        {
            qlhk.TINHTHANHPHOes.Add(data.db);
            try
            {
                //qlhk.TINHTHANHPHOes();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SaveChanges();
                return false;
            }
        }
        public override bool insert(TinhThanhPhoDTO tinhThanh)
        {
            qlhk.TINHTHANHPHOes.Add(tinhThanh.db);
            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SaveChanges();
                return false;
            }
        }
        public bool deleteTTP(string id)
        {
            var kq =
           from ttp in qlhk.TINHTHANHPHOes
           where ttp.matp == id
           select ttp;

            foreach (var detail in kq)
            {
                qlhk.TINHTHANHPHOes.Remove(detail);
            }

            try
            {
                qlhk.SaveChanges();
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
                List<TinhThanhPhoDTO> kq = this.getAll();
                TinhThanhPhoDTO[] arr = kq.ToArray();
                qlhk.TINHTHANHPHOes.Remove(arr[row].db);
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
               from tptv in qlhk.TINHTHANHPHOes
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
                qlhk.SaveChanges();
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
            var res = qlhk.Database.SqlQuery<TINHTHANHPHO>(query).ToList();
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
