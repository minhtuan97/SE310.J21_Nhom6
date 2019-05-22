using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HocSinhSinhVienDAO : DBConnection<HOCSINHSINHVIEN>
    {
        public HocSinhSinhVienDAO() : base() { }

        public override List<HOCSINHSINHVIEN> getAll()
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     select hocsinhsinhvien;
            List<HOCSINHSINHVIEN> x = kq.ToList();
            return x;
        }

        // join 2 bảng
        public List<HOCSINHSINHVIEN> getAllJoinNhanKhau()
        {
            var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                     join nhankhau in qlhk.NHANKHAUs
                     on hocsinhsinhvien.MADINHDANH equals nhankhau.MADINHDANH
                     select hocsinhsinhvien;
            List<HOCSINHSINHVIEN> x = kq.ToList();
            return x;
        }

        public override bool insert_table(HOCSINHSINHVIEN hssv)
        {
            qlhk.HOCSINHSINHVIENs.InsertOnSubmit(hssv);
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
        public bool deleteHSSV(string id)
        {
            var kq =
            from hssv in qlhk.HOCSINHSINHVIENs
            where hssv.MAHSSV == id
            select hssv;

            foreach (var detail in kq)
            {
                qlhk.HOCSINHSINHVIENs.DeleteOnSubmit(detail);
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
                List<HOCSINHSINHVIEN> kq = this.getAll();
                HOCSINHSINHVIEN[] arr = kq.ToArray();
                qlhk.HOCSINHSINHVIENs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(HOCSINHSINHVIEN hssv)
        {
            // Query the database for the row to be updated.
            var query =
                from x in qlhk.HOCSINHSINHVIENs
                where hssv.MAHSSV == x.MAHSSV
                select x;

            // Execute the query, and change the column values
            // you want to change.

            foreach (HOCSINHSINHVIEN kq in query)
            {
                //kq.MAHSSV = hssv.MAHSSV;
                kq.MADINHDANH = hssv.MADINHDANH;
                kq.TRUONG = hssv.TRUONG;
                kq.DIACHITHUONGTRU = hssv.DIACHITHUONGTRU;
                kq.THOIGIANBATDAUTAMTRUTHUONGTRU = hssv.THOIGIANBATDAUTAMTRUTHUONGTRU;
                kq.THOIGIANKETTHUCTAMTRUTHUONGTRU = hssv.THOIGIANKETTHUCTAMTRUTHUONGTRU;
                kq.VIPHAM = hssv.VIPHAM;
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

        public DataTable TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien" + query;
            var res = qlhk.ExecuteQuery<HOCSINHSINHVIEN>(query) as IEnumerable<DataRow>;

            return res.CopyToDataTable();
        }

        // join 2 bảng ???
        public List<HOCSINHSINHVIEN> TimKiemJoinNhanKhau(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM HOCSINHSINHVIEN JOIN NHANKHAU ON HOCSINHSINHVIEN.MADINHDANH=NHANKHAU.MADINHDANH " + query;
            var res = qlhk.ExecuteQuery<HOCSINHSINHVIEN>(query).ToList();
            
            return res;
        }
        public List<HOCSINHSINHVIEN> TimKiemJoinNhanKhauCuTru(string query)
        {
                return null;
                //    var kq = from hocsinhsinhvien in qlhk.HOCSINHSINHVIENs
                //             join nhankhau in qlhk.NHANKHAUs
                //             on hocsinhsinhvien.MADINHDANH equals query
                //             select new HOCSINHSINHVIEN
                //             {
                //                 = hocsinhsinhvien,
                //             };
                //    List<HOCSINHSINHVIEN> x = kq.ToList();
                //    return x;
                //        return null;
                //    try
                //    {
                //        if (conn.State != ConnectionState.Open)
                //        {
                //            conn.Open();
                //        }
                //        sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien, nhankhau " +
                //            "where nhankhau.madinhdanh=hocsinhsinhvien.madinhdanh " + query, conn);
                //        cmdbuilder = new MySqlCommandBuilder(sqlda);
                //        dataset = new DataSet();
                //        sqlda.Fill(dataset);
                //        return dataset;
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.Message);
                //    }
                //    finally
                //    {
                //        conn.Close();
                //    }
                //    return null;
            }

        public override bool insert(HOCSINHSINHVIEN hssv)
        {
            qlhk.HOCSINHSINHVIENs.InsertOnSubmit(hssv);
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
    }

}
