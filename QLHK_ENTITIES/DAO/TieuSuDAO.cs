using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TieuSuDAO : DBConnection<TieuSuDTO>
    {
        
        public TieuSuDAO() : base() { }

        public override List<TieuSuDTO> getAll()
        {
            var kq = from tieusu in qlhk.TIEUSUs
                     select new TieuSuDTO
                     {
                         db = tieusu,
                     };
            List<TieuSuDTO> x = kq.ToList();
            return x;
        }

        public bool deleteTS(String id)
        {
            var kq =
            from ts in qlhk.TIEUSUs
            where ts.MATIEUSU == id
            select ts;

            foreach (var detail in kq)
            {
                qlhk.TIEUSUs.Remove(detail);
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

        public bool deleteTS(TIEUSU ts)
        {
            if (ts==null||string.IsNullOrEmpty(ts.MATIEUSU))
                return false;
            

             qlhk.TIEUSUs.Remove(ts);

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
                List<TieuSuDTO> kq = this.getAll();
                TieuSuDTO[] arr = kq.ToArray();
                qlhk.TIEUSUs.Remove(arr[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool insert(TieuSuDTO data)
        {
            qlhk.TIEUSUs.Remove(data.db);
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

        public override bool insert_table(TieuSuDTO data)
        {
            qlhk.TIEUSUs.Add(data.db);
            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //qlhk.SubmitChanges();
                return false;
            }
        }

        public override bool update(TieuSuDTO tieusu)
        {
            // Query the database for the row to be updated.
            var query =
                from ts in qlhk.TIEUSUs
                where tieusu.db.MATIEUSU == ts.MATIEUSU
                select ts;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TIEUSU kq in query.ToList())
            {
                kq.MADINHDANH = tieusu.db.MADINHDANH;
                kq.THOIGIANBATDAU = tieusu.db.THOIGIANBATDAU;
                kq.THOIGIANKETTHUC = tieusu.db.THOIGIANKETTHUC;
                kq.CHOO = tieusu.db.CHOO;
                kq.NGHENGHIEP = tieusu.db.NGHENGHIEP;
                kq.NOILAMVIEC = tieusu.db.NOILAMVIEC;
                // Insert any additional changes to column values.
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

        public List<TieuSuDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM tieusu" + query;
            var res = qlhk.Database.SqlQuery<TIEUSU>(query).ToList();
            List<TieuSuDTO> lst = new List<TieuSuDTO>();
            foreach (TIEUSU i in res)
            {
                TieuSuDTO ts = new TieuSuDTO(i);
                lst.Add(ts);
            }

            return lst;
        }
    }
}
