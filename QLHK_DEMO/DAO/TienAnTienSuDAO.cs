using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TienAnTienSuDAO : DBConnection<TIENANTIENSU>
    {
        public TienAnTienSuDAO() : base() { }

        public override bool delete(int row)
        {
            try
            {
                List<TIENANTIENSU> kq = this.getAll();
                TIENANTIENSU[] arr = kq.ToArray();
                qlhk.TIENANTIENSUs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool deleteTATS(string id)
        {
            var kq =
            from ts in qlhk.TIENANTIENSUs
            where ts.MATIENANTIENSU == id
            select ts;

            foreach (var detail in kq)
            {
                qlhk.TIENANTIENSUs.DeleteOnSubmit(detail);
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

        public bool deleteTATS(TIENANTIENSU ta)
        {
            if (ta == null || string.IsNullOrEmpty(ta.MATIENANTIENSU))
                return false;

            qlhk.TIENANTIENSUs.DeleteOnSubmit(ta);

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

        public override List<TIENANTIENSU> getAll()
        {
            var kq = from tienantiensu in qlhk.TIENANTIENSUs
                        select tienantiensu;
            List<TIENANTIENSU> x = kq.ToList();
            return x;
        }

        public List<TIENANTIENSU> getTATS()
        {
            var kq = from tienantiensu in qlhk.TIENANTIENSUs
                     select tienantiensu;

            return kq.ToList();
        }

        public override bool insert(TIENANTIENSU data)
        {
            qlhk.TIENANTIENSUs.InsertOnSubmit(data);
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

        public override bool insert_table(TIENANTIENSU data)
        {
            qlhk.TIENANTIENSUs.InsertOnSubmit(data);
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

        public override bool update(TIENANTIENSU tienantiensu)
        {
            // Query the database for the row to be updated.
            var query =
                from ts in qlhk.TIENANTIENSUs
                where tienantiensu.MATIENANTIENSU == ts.MATIENANTIENSU
                select ts;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TIENANTIENSU kq in query)
            {
                kq.MATIENANTIENSU = tienantiensu.MATIENANTIENSU;
                kq.MADINHDANH = tienantiensu.MADINHDANH;
                kq.BANAN = tienantiensu.BANAN;
                kq.TOIDANH = tienantiensu.TOIDANH;
                kq.HINHPHAT = tienantiensu.HINHPHAT;
                kq.NGAYPHAT = tienantiensu.NGAYPHAT;
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

        public List<TIENANTIENSU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM tienantiensu" + query;
            var res = qlhk.ExecuteQuery<TIENANTIENSU>(query).ToList();

            return res;
        }
    }
}
