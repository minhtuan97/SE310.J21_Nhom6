using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauDAO:DBConnection<NhanKhau>
    {
        public NhanKhauDAO() : base() { }
        public override List<NhanKhau> getAll()
        {
            NhanKhau nk = new NhanKhau();
            var kq = from nkdto in qlhk.NHANKHAUs
                     select new NhanKhau
                     {
                         db=nkdto
                     };
            List<NhanKhau> x = kq.ToList();
            return x;
        }
        public override bool insert_table(NhanKhau data)
        {
            qlhk.NHANKHAUs.InsertOnSubmit(data.db);
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
        public override bool insert(NhanKhau nk)
        {
            qlhk.NHANKHAUs.InsertOnSubmit(nk.db);
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
                List<NhanKhau> kq = this.getAll();
                NhanKhau[] arr = kq.ToArray();
                qlhk.NHANKHAUs.DeleteOnSubmit(arr[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public bool delete(string madinhdanh)
        {
            // Query the database for the rows to be deleted.
            var deleteOrderDetails =
                from details in qlhk.NHANKHAUs
                where details.MADINHDANH == madinhdanh
                select details;

            foreach (var detail in deleteOrderDetails)
            {
                qlhk.NHANKHAUs.DeleteOnSubmit(detail);
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
        public override bool update(NhanKhau nk)
        {
            // Query the database for the row to be updated.
            var query =
                from nhankhau in qlhk.NHANKHAUs
                where nk.db.MADINHDANH == nhankhau.MADINHDANH
                select nhankhau;

            // Execute the query, and change the column values
            // you want to change.

            foreach (NHANKHAU kq in query)
            {
                kq.MADINHDANH = nk.db.MADINHDANH;
                kq.HOTEN = nk.db.HOTEN;
                kq.TENKHAC = nk.db.TENKHAC;
                kq.NGAYSINH = nk.db.NGAYSINH;
                kq.GIOITINH = nk.db.GIOITINH;
                kq.NOISINH = nk.db.NOISINH;
                kq.NGUYENQUAN = nk.db.NGUYENQUAN;
                kq.DANTOC = nk.db.DANTOC;
                kq.TONGIAO = nk.db.TONGIAO;
                kq.QUOCTICH = nk.db.QUOCTICH;
                kq.HOCHIEU = nk.db.HOCHIEU;
                kq.NOITHUONGTRU = nk.db.NOITHUONGTRU;
                kq.DIACHIHIENNAY = nk.db.DIACHIHIENNAY;
                kq.SDT = nk.db.SDT;
                kq.TRINHDOHOCVAN = nk.db.TRINHDOHOCVAN;
                kq.TRINHDOCHUYENMON = nk.db.TRINHDOCHUYENMON;
                kq.BIETTIENGDANTOC = nk.db.BIETTIENGDANTOC;
                kq.TRINHDONGOAINGU = nk.db.TRINHDONGOAINGU;
                kq.NGHENGHIEP = nk.db.NGHENGHIEP;
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
        public  List<NhanKhau> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM nhankhau" + query;
            var res = qlhk.ExecuteQuery<NHANKHAU>(query).ToList();
            List<NhanKhau> lst = new List<NhanKhau>();
            foreach (NHANKHAU i in res)
            {
                NhanKhau ts = new NhanKhau(i);
                lst.Add(ts);
            }

            return lst;
        }

        public List<NhanKhau> TimKiemTheoCuTru(string madinhdanh)
        {
            return null;
        }
    }
}
