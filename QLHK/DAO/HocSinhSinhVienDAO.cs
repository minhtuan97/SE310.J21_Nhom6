using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HocSinhSinhVienDAO : DBConnection<HocSinhSinhVienDTO>
    {
        public HocSinhSinhVienDAO() : base() { }

        public override List<HocSinhSinhVienDTO> getAll()
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     select new HOCSINHSINHVIEN
                     {
                         dbhssv = hocsinhsinhvien,
                     };
            List<HocSinhSinhVienDTO> x = kq.ToList();
            return x;
        }

        // join 2 bảng
        public DataSet getAllJoinNhanKhau()
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     join nhankhau in qlhk.NHANKHAUs
                     on hocsinhsinhvien.MADINHDANH equals nhankhau.MADINHDANH
                     select new HOCSINHSINHVIEN
                     {
                         dbhssv = hocsinhsinhvien,
                     };
            List<HocSinhSinhVienDTO> x = kq.ToList();
            return x;
        }

        public override bool insert_table(HocSinhSinhVienDTO hssv)
        {
            qlhk.HOCSINHSINHVIENs.InsertOnSubmit(hssv.dbhssv);
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

        public bool XoaHHSV(string mssv)
        {
            try
            {
                HOCSINHSINHVIEN dept = qlhk.HOCSINHSINHVIENs.Single(x => x.MAHSSV == mssv);
                qlhk.HOCSINHSINHVIENs.DeleteOnSubmit(dept);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool delete(int row)
        {
            try
            {
                List<HocSinhSinhVienDTO> kq = this.getAll();
                HocSinhSinhVienDTO[] arr = kq.ToArray();
                qlhk.HOCSINHSINHVIENs.DeleteOnSubmit(arr[row].dbhssv);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(HocSinhSinhVienDTO hssv)
        {
            // Query the database for the row to be updated.
            var query =
                from x in qlhk.HOCSINHSINHVIENs
                where hssv.dbhssv.MAHSSV == x.MAHSSV
                select x;

            // Execute the query, and change the column values
            // you want to change.

            foreach (HOCSINHSINHVIEN kq in query)
            {
                kq.MAHSSV = hssv.dbhssv.MAHSSV;
                kq.MADINHDANH = hssv.dbhssv.MADINHDANH;
                kq.TRUONG = hssv.dbhssv.TRUONG;
                kq.THOIGIANBATDAUTAMTRUTHUONGTRU = hssv.dbhssv.THOIGIANBATDAUTAMTRUTHUONGTRU;
                kq.THOIGIANKETTHUCTAMTRUTHUONGTRU = hssv.dbhssv.THOIGIANKETTHUCTAMTRUTHUONGTRU;
                kq.VIPHAM = hssv.dbhssv.VIPHAM;
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

        public List<HocSinhSinhVienDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien" + query;
            var res = qlhk.ExecuteQuery<HOCSINHSINHVIEN>(query).ToList();
            List<HocSinhSinhVienDTO> lst = new List<HocSinhSinhVienDTO>();
            foreach (HOCSINHSINHVIEN i in res)
            {
                HocSinhSinhVienDTO ts = new HocSinhSinhVienDTO(i);
                lst.Add(ts);
            }

            return lst;
        }

        // join 2 bảng ???
        public DataSet TimKiemJoinNhanKhau(string query)
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     join nhankhau in qlhk.NHANKHAUs
                     on hocsinhsinhvien.MADINHDANH equals nhankhau.MADINHDANH
                     select new HOCSINHSINHVIEN
                     {
                         dbhssv = hocsinhsinhvien,
                     };
            List<HocSinhSinhVienDTO> x = kq.ToList();
            return x;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien, nhankhau " +
                    "where nhankhau.madinhdanh=hocsinhsinhvien.madinhdanh " + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset);
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        // join 2 bảng ???
        public List<HocSinhSinhVienDTO> TimKiemJoinNhanKhauCuTru(string query)
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     join nhankhau in qlhk.NHANKHAUs
                     on hocsinhsinhvien.MADINHDANH equals nhankhau.MADINHDANH
                     select new HOCSINHSINHVIEN
                     {
                         dbhssv = hocsinhsinhvien,
                     };
            List<HocSinhSinhVienDTO> x = kq.ToList();
            return x;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien, nhankhau " +
                    "where nhankhau.madinhdanh=hocsinhsinhvien.madinhdanh " + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset);
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public override bool insert(HocSinhSinhVienDTO hssv)
        {
            qlhk.HOCSINHSINHVIENs.InsertOnSubmit(hssv.dbhssv);
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
    }

}
