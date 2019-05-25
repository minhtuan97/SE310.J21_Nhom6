//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauThuongTruDAO:DBConnection<NHANKHAUTHUONGTRU>
    {
        public NhanKhauThuongTruDAO() : base() { }

        public override List<NHANKHAUTHUONGTRU> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTHUONGTRUs
                        select nktt;

            return kq.ToList();

        }

        public List<NHANKHAUTHUONGTRU> getAllJoinNhanKhau()
        {

            var kq = from nktt in qlhk.NHANKHAUTHUONGTRUs
                     join nk in qlhk.NHANKHAUs on nktt.MADINHDANH equals nk.MADINHDANH
                     select nktt;

            return kq.ToList();
        }
        public override bool insert_table(NHANKHAUTHUONGTRU data)
        {

            if (!String.IsNullOrEmpty(data.NHANKHAU.MADINHDANH))
                qlhk.NHANKHAUs.InsertOnSubmit(data.NHANKHAU);
            if (!String.IsNullOrEmpty(data.MADINHDANH))
                qlhk.NHANKHAUTHUONGTRUs.InsertOnSubmit(data);

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                qlhk.SubmitChanges();
                return false;
            }
        }
        public override bool insert(NHANKHAUTHUONGTRU data)
        {
            quanlyhokhauDataContext db = new quanlyhokhauDataContext();

            try
            {
                db.NHANKHAUTHUONGTRUs.InsertOnSubmit(data);
                data.MADINHDANH = data.NHANKHAU.MADINHDANH;
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;

                return false;
            }
        }
        public bool XoaNKTT(string maNhanKhauthuongtru)
        {
            qlhk = new quanlyhokhauDataContext();

            var kq = qlhk.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == maNhanKhauthuongtru).SingleOrDefault();
            try
            {
                qlhk.NHANKHAUTHUONGTRUs.DeleteOnSubmit(kq);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool deleteNKTT(string id)
        {
            qlhk = new quanlyhokhauDataContext();

            var kq =
            from nktt in qlhk.NHANKHAUTHUONGTRUs
            where nktt.MANHANKHAUTHUONGTRU == id
            select nktt;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUTHUONGTRUs.DeleteOnSubmit(detail);
            }

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                return false;
                // Provide for exceptions.
            }
        }

        public override bool delete(int row)
        {
            qlhk = new quanlyhokhauDataContext();

            NHANKHAUTHUONGTRU[] nktt = this.getAll().ToArray();
            try
            {
                qlhk.NHANKHAUTHUONGTRUs.DeleteOnSubmit(nktt[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public bool updateTTThuongTru(string manktt, string sshk)
        {
            quanlyhokhauDataContext db = new quanlyhokhauDataContext();

            NHANKHAUTHUONGTRU nk = db.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == manktt).FirstOrDefault();

            //nk.SOHOKHAU = shk;
            //nk.SOSOHOKHAU = shk.SOSOHOKHAU;
            SOHOKHAU shk = db.SOHOKHAUs.Single(q => q.SOSOHOKHAU == sshk);
            nk.DIACHITHUONGTRU = shk.DIACHI;

            shk.NHANKHAUTHUONGTRUs.Add(nk);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public override bool update(NHANKHAUTHUONGTRU nktt)
        {
            quanlyhokhauDataContext db = new quanlyhokhauDataContext();

            // Query the database for the row to be updated.
            var query = db.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == nktt.MANHANKHAUTHUONGTRU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (NHANKHAUTHUONGTRU kq in query)
            {
                //if (kq.MANHANKHAUTHUONGTRU == nktt.MANHANKHAUTHUONGTRU)
                //{
                if (kq.NHANKHAU.MADINHDANH != nktt.NHANKHAU.MADINHDANH)
                {
                    kq.NHANKHAU = db.NHANKHAUs.SingleOrDefault(q => q.MADINHDANH == nktt.MADINHDANH);
                    kq.MADINHDANH = nktt.NHANKHAU.MADINHDANH;
                }

                kq.DIACHITHUONGTRU = nktt.DIACHITHUONGTRU;
                kq.QUANHEVOICHUHO = nktt.QUANHEVOICHUHO;
                if (kq.SOSOHOKHAU != nktt.SOSOHOKHAU)
                {
                    kq.SOHOKHAU = db.SOHOKHAUs.SingleOrDefault(q => q.SOSOHOKHAU == nktt.SOSOHOKHAU);
                    kq.SOSOHOKHAU = nktt.SOSOHOKHAU;
                }

                //    break;
                //}

                // Insert any additional changes to column values.
            }
            // Submit the changes to the database.
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                // Provide for exceptions.
                return false;
            }

        }
        //public bool doiChuHo(List<NHANKHAUTHUONGTRU> danhSach, string maDinhDanhChuHo)
        //{
        //    bool contain = false;
        //    foreach(NHANKHAUTHUONGTRU item in danhSach)
        //    {
        //        if (item.MaDinhDanh == maDinhDanhChuHo)
        //        {
        //            contain = true;
        //            break;
        //        }
        //        //else
        //        //{
        //        //    item.LaChuHo = false;
        //        //}
        //    }
        //    if (!contain) return false;

        //    foreach(NHANKHAUTHUONGTRU item in danhSach)
        //    {
        //        item.maChuHo = maDinhDanhChuHo;

        //        try
        //        {
        //            update(item,-1);
        //        } catch (Exception ex){
        //            return false;
        //        }

        //    }

        //    return true;

        //}
        public List<NHANKHAUTHUONGTRU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM NHANKHAUTHUONGTRU" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTHUONGTRU>(query).ToList();

            return res;
        }

        public List<NHANKHAUTHUONGTRU> TimKiemJoinNhanKhau(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " AND " + query;
            query = "SELECT * FROM nhankhauthuongtru, nhankhau where nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTHUONGTRU>(query).ToList();

            return res;
        }
    }
    
}
