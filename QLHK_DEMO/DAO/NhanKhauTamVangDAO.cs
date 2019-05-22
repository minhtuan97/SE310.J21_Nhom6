using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauTamVangDAO : DBConnection<NHANKHAUTAMVANG>
    {
        public NhanKhauTamVangDAO() : base() { }


        public bool deleteNKTV(string id)
        {
            var kq =
            from nktv in qlhk.NHANKHAUTAMVANGs
            where nktv.MANHANKHAUTAMVANG == id
            select nktv;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUTAMVANGs.DeleteOnSubmit(detail);
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
                List<NHANKHAUTAMVANG> kq = this.getAll();
                NHANKHAUTAMVANG[] arr = kq.ToArray();
                qlhk.NHANKHAUTAMVANGs.DeleteOnSubmit(arr[row]);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override List<NHANKHAUTAMVANG> getAll()
        {
            var kq = from nktv in qlhk.NHANKHAUTAMVANGs
                     select nktv;
            List<NHANKHAUTAMVANG> lst_NK = kq.ToList();
            return lst_NK; 
        }

        public override bool insert(NHANKHAUTAMVANG data)
        {
            //qlhk.NHANKHAUTAMVANGs.InsertOnSubmit(data.db);
            //try
            //{
            //    qlhk.SubmitChanges();
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    //qlhk.SubmitChanges();
            //    return false;
            //}



            qlhk.NHANKHAUTAMVANGs.InsertOnSubmit(data);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }






















        }



        public override bool insert_table(NHANKHAUTAMVANG data)
        {
            qlhk.NHANKHAUTAMVANGs.InsertOnSubmit(data);
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

        public override bool update(NHANKHAUTAMVANG data)
        {
            //Query


            var query = qlhk.NHANKHAUTAMVANGs.Where(r => r.MANHANKHAUTAMVANG == data.MANHANKHAUTAMVANG).ToList();
            //var listmanktv = query.Select(r => r.MANHANKHAUTAMVANG).ToList();
            //Execute
            foreach (NHANKHAUTAMVANG NKTV in query)
            {
                NKTV.NGAYBATDAUTAMVANG = data.NGAYBATDAUTAMVANG;
                NKTV.NGAYKETTHUCTAMVANG = data.NGAYKETTHUCTAMVANG;
                NKTV.LYDO = data.LYDO;
                NKTV.NOIDEN = data.NOIDEN;
            }


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


        public List<NHANKHAUTAMVANG> TimKiemJoinNhanKhau(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            query = "SELECT * FROM nhankhautamvang" + query + " ORDER BY ngayketthuctamvang DESC";
            var res = qlhk.ExecuteQuery<NHANKHAUTAMVANG>(query).ToList();
            try
            {
                
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public List<NHANKHAUTAMVANG> TimKiemNhanKhau(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM nhankhautamvang" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTAMVANG>(query).ToList();

            return res;
        }


        public int TimKiemThuongtru(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM nhankhauthuongtru" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTHUONGTRU>(query).ToList();

            if (res.Count() > 0)
                return 0;
            if (res.Count() == 0)
                return 1;
            return -1;
        }




    }
}
