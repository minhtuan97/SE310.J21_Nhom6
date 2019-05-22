using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql;
using DTO;
//using MySql.Data.MySqlClient;

namespace DAO
{
    public class CanBoDAO : DBConnection<CANBO>
    {
        public CanBoDAO() : base() { }
        public override List<CANBO> getAll()
        {
            var kq = from canbo in qlhk.CANBOs
                     select canbo;

            return kq.ToList();
        }

        public override bool insert(CANBO data)
        {
            //qlhk.NHANKHAUs.InsertOnSubmit(data.db);
            //qlhk.NHANKHAUTHUONGTRUs.InsertOnSubmit(data.db);
            qlhk.CANBOs.InsertOnSubmit(data);
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
        public bool deleteCB(string id)
        {
            var kq =
            from cb in qlhk.CANBOs
            where cb.MACANBO == id
            select cb;

            foreach (var detail in kq)
            {
                qlhk.CANBOs.DeleteOnSubmit(detail);
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
            try
            {
                List<CANBO> kq = this.getAll();
                CANBO[] arr = kq.ToArray();
                qlhk.CANBOs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(CANBO cb)
        {

            // Query the database for the row to be updated.
            var query = qlhk.CANBOs.Where(q => q.MACANBO == cb.MACANBO);

            // Execute the query, and change the column values
            // you want to change.
            foreach (CANBO kq in query)
            {
                kq.MANHANKHAUTHUONGTRU = cb.MANHANKHAUTHUONGTRU;
                kq.TENTAIKHOAN = cb.TENTAIKHOAN;
                kq.MATKHAU = cb.MATKHAU;
                kq.LOAICANBO = cb.LOAICANBO;
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
                error = e;
                // Provide for exceptions.
                return false;
            }
        }
        public override bool insert_table(CANBO data)
        {

            qlhk.CANBOs.InsertOnSubmit(data);
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
        public List<CANBO> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM CANBO" + query;
            var res = qlhk.ExecuteQuery<CANBO>(query).ToList();

            return res;
        }
        public List<CANBO> TimKiemJoinNhanKhau(string query)
        {
            qlhk = new quanlyhokhauDataContext();
            if (!String.IsNullOrEmpty(query)) query = " AND " + query;
            query = "SELECT * FROM canbo, nhankhauthuongtru, nhankhau " +
                    "WHERE canbo.manhankhauthuongtru = nhankhauthuongtru.manhankhauthuongtru AND nhankhau.madinhdanh=nhankhauthuongtru.manhankhau" + query;
            var res = qlhk.ExecuteQuery<CANBO>(query).ToList();

            return res;

           
        }

        public string GetMaNhanKhauThuongTruFromCanBo(string tendangnhap)
        {
            return qlhk.CANBOs.Where(q => q.TENTAIKHOAN == tendangnhap).Select(r => r.MACANBO).FirstOrDefault();
        }


        public string GetMaDinhDanhFromMaNhanKhauThuongTru(string manhankhauthuongtru)
        {
            return qlhk.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == manhankhauthuongtru).Select(r => r.MADINHDANH).FirstOrDefault();
            //try
            //{
            //    DataTable dt = new DataTable();
            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Open();
            //    }
            //    string sqltemp = "SELECT madinhdanh FROM nhankhauthuongtru where manhankhauthuongtru='" + manhankhauthuongtru + "'";
            //    MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
            //    adapter.SelectCommand.CommandType = CommandType.Text;
            //    adapter.Fill(dt);
            //    string ID = "";
            //    ID = dt.Rows[0][0].ToString();
            //    return ID;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //return "";
        }


        //Lấy thông tin cán bộ từ bảng nhân khẩu
        public List<NHANKHAUTHUONGTRU> getThongTinNhanKhau(string manhankhauthuongtru)
        {
            var kq = from nktt in qlhk.NHANKHAUTHUONGTRUs
                     join nk in qlhk.NHANKHAUs on nktt.MADINHDANH equals nk.MADINHDANH
                     where nktt.MANHANKHAUTHUONGTRU == manhankhauthuongtru
                     select nktt;

            return kq.ToList();
        }


        //Cập nhật mật khẩu cán bộ
        public bool CapNhatMatKhau(string tentaikhoan , string matkhau)
        {
            var kq = qlhk.CANBOs.Where(q => q.TENTAIKHOAN == tentaikhoan).FirstOrDefault();

            kq.MATKHAU = matkhau;
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                // Provide for exceptions.
                return false;
            }

        }


    }
}
