using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TienAnTienSuDAO : DBConnection<TienAnTienSuDTO>
    {
        public TienAnTienSuDAO() : base() { }

        public override bool delete(int row)
        {
            try
            {
                List<TienAnTienSuDTO> kq = this.getAll();
                TienAnTienSuDTO[] arr = kq.ToArray();
                qlhk.TIENANTIENSUs.DeleteOnSubmit(arr[row].db);
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

        public override List<TienAnTienSuDTO> getAll()
        {
            var kq = from tienantiensu in qlhk.TIENANTIENSUs
                        select new TienAnTienSuDTO
                        {
                            db = tienantiensu,
                        };
            List<TienAnTienSuDTO> x = kq.ToList();
            return x;
        }

        public override bool insert(TienAnTienSuDTO data)
        {
            qlhk.TIENANTIENSUs.InsertOnSubmit(data.db);
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

        public override bool insert_table(TienAnTienSuDTO data)
        {
            qlhk.TIENANTIENSUs.InsertOnSubmit(data.db);
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

        public override bool update(TienAnTienSuDTO tienantiensu)
        {
            // Query the database for the row to be updated.
            var query =
                from ts in qlhk.TIENANTIENSUs
                where tienantiensu.db.MATIENANTIENSU == ts.MATIENANTIENSU
                select ts;

            // Execute the query, and change the column values
            // you want to change.

            foreach (TIENANTIENSU kq in query)
            {
                kq.MATIENANTIENSU = tienantiensu.db.MATIENANTIENSU;
                kq.MADINHDANH = tienantiensu.db.MADINHDANH;
                kq.BANAN = tienantiensu.db.BANAN;
                kq.TOIDANH = tienantiensu.db.TOIDANH;
                kq.HINHPHAT = tienantiensu.db.HINHPHAT;
                kq.NGAYPHAT = tienantiensu.db.NGAYPHAT;
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

        public List<TienAnTienSuDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM tienantiensu" + query;
            var res = qlhk.ExecuteQuery<TIENANTIENSU>(query).ToList();
            List<TienAnTienSuDTO> lst = new List<TienAnTienSuDTO>();
            foreach (TIENANTIENSU i in res)
            {
                TienAnTienSuDTO ts = new TienAnTienSuDTO(i);
                lst.Add(ts);
            }

            return lst;
        }
    }
}
