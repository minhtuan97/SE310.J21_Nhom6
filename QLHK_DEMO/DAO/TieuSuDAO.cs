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
    public class TieuSuDAO : DBConnection<TIEUSU>
    {
        
        public TieuSuDAO() : base() { }

        public override List<TIEUSU> getAll()
        {
            var kq = from tieusu in qlhk.TIEUSUs
                     select tieusu;
            List<TIEUSU> x = kq.ToList();
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
                qlhk.TIEUSUs.DeleteOnSubmit(detail);
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

        public bool deleteTS(TIEUSU ts)
        {
            if (ts==null||string.IsNullOrEmpty(ts.MATIEUSU))
                return false;
            

             qlhk.TIEUSUs.DeleteOnSubmit(ts);

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
                List<TIEUSU> kq = this.getAll();
                TIEUSU[] arr = kq.ToArray();
                qlhk.TIEUSUs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool insert(TIEUSU data)
        {
            qlhk.TIEUSUs.InsertOnSubmit(data);
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

        public override bool insert_table(TIEUSU data)
        {
            qlhk.TIEUSUs.InsertOnSubmit(data);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //qlhk.SubmitChanges();
                return false;
            }
        }

        public override bool update(TIEUSU tieusu)
        {
            // Query the database for the row to be updated.
            var query =
                from ts in qlhk.TIEUSUs
                where tieusu.MATIEUSU == ts.MATIEUSU
                select ts;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TIEUSU kq in query.ToList())
            {
                kq.MADINHDANH = tieusu.MADINHDANH;
                kq.THOIGIANBATDAU = tieusu.THOIGIANBATDAU;
                kq.THOIGIANKETTHUC = tieusu.THOIGIANKETTHUC;
                kq.CHOO = tieusu.CHOO;
                kq.NGHENGHIEP = tieusu.NGHENGHIEP;
                kq.NOILAMVIEC = tieusu.NOILAMVIEC;
                // Insert any additional changes to column values.
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

        public List<TIEUSU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM tieusu" + query;
            var res = qlhk.ExecuteQuery<TIEUSU>(query).ToList();

            return res;
        }
    }
}
