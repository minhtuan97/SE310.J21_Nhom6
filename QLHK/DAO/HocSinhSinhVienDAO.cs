using MySql.Data.MySqlClient;
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

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
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

        public DataSet getAllJoinNhanKhau()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM hocsinhsinhvien, nhankhau " +
                    "where nhankhau.madinhdanh=hocsinhsinhvien.madinhdanh", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
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

        public override bool insert_table(HocSinhSinhVienDTO hssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["hocsinhsinhvien"].NewRow();
                dr["mahssv"] = hssv.MaHSSV;
                dr["madinhdanh"] = hssv.MaDinhDanh;
                dr["truong"] = hssv.Truong;
                dr["diachithuongtru"] = hssv.DiaChiThuongTru;
                dr["thoigianbatdautamtruthuongtru"] = hssv.TGBDTTTT;
                dr["thoigianketthuctamtruthuongtru"] = hssv.TGKTTTTT;
                dr["vipham"] = hssv.ViPham;
                dataset.Tables["hocsinhsinhvien"].Rows.Add(dr);
                dataset.Tables["hocsinhsinhvien"].Rows.RemoveAt(dataset.Tables["hocsinhsinhvien"].Rows.Count - 1);
                sqlda.Update(dataset, "hocsinhsinhvien");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;

        }
        public bool XoaHHSV(string mssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from hocsinhsinhvien where mahssv=@mahssv";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahssv", mssv);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["hocsinhsinhvien"].Rows[row].Delete();
                sqlda.Update(dataset, "hocsinhsinhvien");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(HocSinhSinhVienDTO hssv, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update hocsinhsinhvien set madinhdanh=@madinhdanh, truong=@truong, diachithuongtru=@diachithuongtru, " +
                    "thoigianbatdautamtruthuongtru=@thoigianbatdautamtruthuongtru, thoigianketthuctamtruthuongtru=@thoigianketthuctamtruthuongtru, " +
                    "vipham=@vipham where mahssv=@mahssv";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahssv", hssv.MaHSSV.ToString());
                cmd.Parameters.AddWithValue("@madinhdanh", hssv.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@truong", hssv.Truong.ToString());
                cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@thoigianbatdautamtruthuongtru", hssv.TGBDTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@thoigianketthuctamtruthuongtru", hssv.TGKTTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@vipham", hssv.ViPham.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public DataSet TimKiem(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM hocsinhsinhvien" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
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

        public DataSet TimKiemJoinNhanKhau(string query)
        {
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

        public DataSet TimKiemJoinNhanKhauCuTru(string query)
        {
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
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into hocsinhsinhvien values(@mahssv, @madinhdanh, @truong, @diachithuongtru, " +
                    "@tgbdtttt, @tgkttttt, @vipham)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahssv", hssv.MaHSSV);
                cmd.Parameters.AddWithValue("@madinhdanh", hssv.MaDinhDanh);
                cmd.Parameters.AddWithValue("@truong", hssv.Truong);
                cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@tgbdtttt", hssv.TGBDTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@tgkttttt", hssv.TGKTTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@vipham", hssv.ViPham);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
    }

}
