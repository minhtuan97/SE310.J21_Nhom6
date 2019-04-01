using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class NhanKhauTamVangDAO : DBConnection<NhanKhauTamVangDTO>
    {
        public NhanKhauTamVangDAO() : base() { }

        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["nhankhautamvang"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhautamvang");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhautamvang", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhautamvang");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public override bool insert(NhanKhauTamVangDTO data)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "insert into nhankhautamvang values" +
                    "(@manhankhautamvang, @madinhdanh, @ngaybatdautamvang, @ngayketthuctamvang, @lydo, @noiden)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamvang", data.MaNhanKhauTamVang);
                cmd.Parameters.AddWithValue("@madinhdanh", data.MaDinhDanh);
                cmd.Parameters.AddWithValue("@ngaybatdautamvang", data.NgayBatDauTamVang);
                cmd.Parameters.AddWithValue("@ngayketthuctamvang", data.NgayKetThucTamVang);
                cmd.Parameters.AddWithValue("@lydo", data.LyDo);
                cmd.Parameters.AddWithValue("@noiden", data.NoiDen);
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

        public override bool insert_table(NhanKhauTamVangDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["nhankhautamvang"].NewRow();
                dr["manhankhautamvang"] = data.MaNhanKhauTamVang;
                dr["madinhdanh"] = data.MaDinhDanh;
                dr["ngaybatdautamvang"] = data.NgayBatDauTamVang;
                dr["ngayketthuctamvang"] = data.NgayKetThucTamVang;
                dr["lydo"] = data.LyDo;
                dr["noiden"] = data.NoiDen;

                dataset.Tables["nhankhautamvang"].Rows.Add(dr);
                dataset.Tables["nhankhautamvang"].Rows.RemoveAt(dataset.Tables["nhankhautamvang"].Rows.Count - 1);
                sqlda.Update(dataset, "nhankhautamvang");
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

        public override bool update(NhanKhauTamVangDTO data, int r)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "update nhankhautamvang set ngaybatdautamvang=@ngaybatdautamvang, ngayketthuctamvang=@ngayketthuctamvang, " +
                    "lydo=@lydo, noiden=@noiden where manhankhautamvang=@manhankhautamvang";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamvang", data.MaNhanKhauTamVang);
                cmd.Parameters.AddWithValue("@ngaybatdautamvang", data.NgayBatDauTamVang);
                cmd.Parameters.AddWithValue("@ngayketthuctamvang", data.NgayKetThucTamVang);
                cmd.Parameters.AddWithValue("@lydo", data.LyDo);
                cmd.Parameters.AddWithValue("@noiden", data.NoiDen);
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
        public DataSet TimKiemJoinNhanKhau(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM nhankhau left join nhankhautamvang " +
                    "on nhankhau.madinhdanh=nhankhautamvang.madinhdanh" + query+ " ORDER BY ngayketthuctamvang DESC", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset,"timkiem");
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
        public DataSet TimKiemNhanKhau(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM nhankhau " + query, conn);
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
        public int TimKiemThuongtru(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM nhankhauthuongtru " + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                dataset = new DataSet();
                sqlda.Fill(dataset,"kq");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
            if (dataset.Tables["kq"].Rows.Count > 0)
                return 0;
            if (dataset.Tables["kq"].Rows.Count == 0)
                return 1;
            return -1;
        }

    }
}
