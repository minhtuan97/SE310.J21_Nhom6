using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class CanBoDAO : DBConnection<CanBoDTO>
    {
        public CanBoDAO() : base() { }
        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM canbo", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "canbo");
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

        public override bool insert(CanBoDTO data)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "insert into canbo values(@macanbo,@manhankhauthuongtru,  @tentaikhoan, @matkhau, @loaicanbo)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@macanbo", data.MaCanBo);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", data.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@tentaikhoan", data.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", data.MatKhau);
                cmd.Parameters.AddWithValue("@loaicanbo", data.LoaiCanBo);
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
                dataset.Tables["canbo"].Rows[row].Delete();
                sqlda.Update(dataset, "canbo");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(CanBoDTO cb, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                
                string sql= "update canbo set manhankhauthuongtru= @manhankhauthuongtru, tentaikhoan =@tentaikhoan , matkhau=@matkhau, loaicanbo=@loaicanbo where macanbo =@macanbo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", cb.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@tentaikhoan", cb.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", cb.MatKhau);
                cmd.Parameters.AddWithValue("@loaicanbo", cb.LoaiCanBo);
                cmd.Parameters.AddWithValue("@macanbo", cb.MaCanBo);
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
        public override bool insert_table(CanBoDTO data)
        {
            try
            {
                DataRow dr = dataset.Tables["canbo"].NewRow();
                dr["macanbo"] = data.MaCanBo;
                dr["manhankhauthuongtru"] = data.MaNhanKhauThuongTru;
                dr["tentaikhoan"] = data.TenTaiKhoan;
                dr["matkhau"] = data.MatKhau;
                dr["loaicanbo"] = data.LoaiCanBo;

                dataset.Tables["canbo"].Rows.Add(dr);
                dataset.Tables["canbo"].Rows.RemoveAt(dataset.Tables["canbo"].Rows.Count - 1);
                sqlda.Update(dataset, "canbo");
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
                if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
                sqlda = new MySqlDataAdapter("SELECT * FROM canbo" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);

                dataset = new DataSet();
                sqlda.Fill(dataset, "canbo");
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
                if (!String.IsNullOrEmpty(query)) query = " AND " + query;
                sqlda = new MySqlDataAdapter("SELECT * FROM canbo, nhankhauthuongtru, nhankhau " +
                    "WHERE canbo.manhankhauthuongtru = nhankhauthuongtru.manhankhauthuongtru AND nhankhau.madinhdanh=nhankhauthuongtru.manhankhau" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);

                dataset = new DataSet();
                sqlda.Fill(dataset, "canbo");
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

        public string GetMaNhanKhauThuongTruFromCanBo(string tendangnhap)
        {
            try
            {
                DataTable dt = new DataTable();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT manhankhauthuongtru FROM canbo where tentaikhoan='" + tendangnhap + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
                string ID = "";
                ID = dt.Rows[0][0].ToString();
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        public string GetMaDinhDanhFromMaNhanKhauTamTru(string manhankhauthuongtru)
        {
            try
            {
                DataTable dt = new DataTable();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT madinhdanh FROM nhankhauthuongtru where manhankhauthuongtru='" + manhankhauthuongtru + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
                string ID = "";
                ID = dt.Rows[0][0].ToString();
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        //Lấy thông tin cán bộ từ bảng nhân khẩu
        public List<NhanKhauThuongTruDTO> getThongTinNhanKhau(string manhankhauthuongtru)
        {
            DataTable dt = new DataTable();
            string madinhdanh = GetMaDinhDanhFromMaNhanKhauTamTru(manhankhauthuongtru);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string sql = "SELECT * FROM nhankhau INNER JOIN nhankhauthuongtru ON nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh WHERE nhankhau.madinhdanh='" + madinhdanh + "' ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            List<NhanKhauThuongTruDTO> items = dt.AsEnumerable().Select(row =>
                 new NhanKhauThuongTruDTO
                 {
                     MaNhanKhauThuongTru = row.Field<string>("manhankhauthuongtru"),
                     HoTen = row.Field<string>("hoten"),
                     GioiTinh = row.Field<string>("gioitinh"),
                     DanToc = row.Field<string>("dantoc"),
                     NgheNghiep = row.Field<string>("nghenghiep"),
                     NgaySinh = row.Field<DateTime>("ngaysinh"),
                     NoiSinh = row.Field<string>("noisinh"),
                     MaDinhDanh = row.Field<string>("madinhdanh"),
                     //Ngày cấp ???
                     //Nơi cấp ???
                     HoChieu = row.Field<string>("hochieu"),
                     NguyenQuan = row.Field<string>("nguyenquan"),
                     TonGiao = row.Field<string>("tongiao"),
                     QuocTich = row.Field<string>("quoctich"),
                     SDT = row.Field<string>("sdt"),
                     SoSoHoKhau = row.Field<string>("sosohokhau"),
                     NoiThuongTru = row.Field<string>("noithuongtru"),
                     DiaChiHienNay = row.Field<string>("diachihiennay"),
                     TrinhDoHocVan = row.Field<string>("trinhdohocvan"),
                     TrinhDoChuyenMon = row.Field<string>("trinhdochuyenmon"),
                     BietTiengDanToc = row.Field<string>("biettiengdantoc"),
                     TrinhDoNgoaiNgu = row.Field<string>("trinhdongoaingu"),
                     //Nơi làm việc
                     QuanHeVoiChuHo = row.Field<string>("quanhevoichuho"),
                 }).ToList();


            return items;
        }


        //Cập nhật mật khẩu cán bộ
        public bool CapNhatMatKhau(string tentaikhoan , string matkhau)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update canbo set matkhau='"+matkhau+"'  where tentaikhoan ='"+tentaikhoan+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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


    }
}
