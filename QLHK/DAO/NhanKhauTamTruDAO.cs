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
    public class NhanKhauTamTruDAO:DBConnection<NhanKhauTamTruDTO>
    {
        public NhanKhauTamTruDAO() : base() { }

        //Lấy tất cả nhân khẩu tạm trú nằm trong 1 sổ tạm trú
        public DataSet getAllNhanKhauTT(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                dataset = new DataSet();
                string sql = "SELECT nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen,TenKhac,NgaySinh, GioiTinh,NoiSinh, NguyenQuan, DanToc,TonGiao, QuocTich,HoChieu,NoiThuongTru,DiaChiHienNay,SDT, TrinhDoHocVan,TrinhDoChuyenMon,BietTiengDanToc,TrinhDoNgoaiNgu, NgheNghiep,SoSoTamTru,NoiTamTru,TuNgay,DenNgay,LyDo FROM nhankhau inner join nhankhautamtru ON nhankhautamtru.madinhdanh=nhankhau.madinhdanh WHERE sosotamtru='"+sosotamtru+"' ";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dataset,"nhankhautamtrujoin");
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


        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                dataset = new DataSet();
                string sql = "SELECT *, 'Delete' as 'Change' FROM nhankhautamtru";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dataset, "nhankhautamtru");
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


        public override bool insert(NhanKhauTamTruDTO nktt)
        {
            
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhautamtru values(@manhankhautamtru, @madinhdanh, @noitamtru,@tungay,@denngay,@lydo,@sosotamtru);"
                             + "insert into nhankhau values(@madinhdanh, @hoten, @tenkhac, @ngaysinh, @gioitinh, @noisinh, @nguyenquan, @dantoc,@tongiao, @quoctich, @hochieu, @noithuongtru, @diachihiennay, @sdt, @trinhdohocvan, @trinhdochuyenmon, @biettiengdantoc, @trinhdongoaingu, @nghenghiep);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru.ToString());
                cmd.Parameters.AddWithValue("@noitamtru", nktt.NoiTamTru.ToString());
                cmd.Parameters.AddWithValue("@tungay", nktt.TuNgay.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@denngay", nktt.DenNgay.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@lydo", nktt.LyDo.ToString());
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru.ToString());

                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@hoten", nktt.HoTen.ToString());
                cmd.Parameters.AddWithValue("@tenkhac", nktt.TenKhac.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nktt.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@gioitinh", nktt.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nktt.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@nguyenquan", nktt.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nktt.DanToc.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nktt.TonGiao.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nktt.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nktt.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@noithuongtru", nktt.NoiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@diachihiennay", nktt.DiaChiHienNay.ToString());
                cmd.Parameters.AddWithValue("@sdt", nktt.SDT.ToString());
                cmd.Parameters.AddWithValue("@trinhdohocvan", nktt.TrinhDoHocVan.ToString());
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nktt.TrinhDoChuyenMon.ToString());
                cmd.Parameters.AddWithValue("@biettiengdantoc", nktt.BietTiengDanToc.ToString());
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nktt.TrinhDoNgoaiNgu.ToString());
                cmd.Parameters.AddWithValue("@nghenghiep", nktt.NgheNghiep.ToString());




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


        public bool XoaNKTT(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nhankhautamtru where madinhdanh=@madinhdanh; delete from nhankhau where madinhdanh=@madinhdanh;" +
                    "delete from tienantiensu where madinhdanh=@madinhdanh;" +
                    "delete from tieusu where madinhdanh=@madinhdanh;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@madinhdanh", madinhdanh);
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
                dataset.Tables["nhankhautamtru"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhautamtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public bool updateNhanKhauTamTru(NhanKhauTamTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhautamtru set noitamtru=@noitamtru, tungay=@tungay, denngay=@denngay,lydo=@lydo,sosotamtru=@sosotamtru where madinhdanh=@madinhdanh; " +
                    "update nhankhau set hoten=@hoten,tenkhac=@tenkhac,ngaysinh=@ngaysinh,gioitinh=@gioitinh," +
                    "noisinh=@noisinh,nguyenquan=@nguyenquan,dantoc=@dantoc,tongiao=@tongiao,quoctich=@quoctich," +
                    "hochieu=@hochieu,noithuongtru=@noithuongtru,diachihiennay=@diachihiennay,sdt=@sdt," +
                    "trinhdohocvan=@trinhdohocvan,trinhdochuyenmon=@trinhdochuyenmon, biettiengdantoc=@biettiengdantoc, " +
                    "trinhdongoaingu=@trinhdongoaingu ,nghenghiep=@nghenghiep where madinhdanh=@madinhdanh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@noitamtru", nktt.NoiTamTru.ToString());
                cmd.Parameters.AddWithValue("@tungay", nktt.TuNgay.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@denngay", nktt.DenNgay.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@lydo", nktt.LyDo.ToString());
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru.ToString());


                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh.ToString());
                cmd.Parameters.AddWithValue("@hoten", nktt.HoTen.ToString());
                cmd.Parameters.AddWithValue("@tenkhac", nktt.TenKhac.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nktt.NgaySinh.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@gioitinh", nktt.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@noisinh", nktt.NoiSinh.ToString());
                cmd.Parameters.AddWithValue("@nguyenquan", nktt.NguyenQuan.ToString());
                cmd.Parameters.AddWithValue("@dantoc", nktt.DanToc.ToString());
                cmd.Parameters.AddWithValue("@tongiao", nktt.TonGiao.ToString());
                cmd.Parameters.AddWithValue("@quoctich", nktt.QuocTich.ToString());
                cmd.Parameters.AddWithValue("@hochieu", nktt.HoChieu.ToString());
                cmd.Parameters.AddWithValue("@noithuongtru", nktt.NoiThuongTru.ToString());
                cmd.Parameters.AddWithValue("@diachihiennay", nktt.DiaChiHienNay.ToString());
                cmd.Parameters.AddWithValue("@sdt", nktt.SDT.ToString());
                cmd.Parameters.AddWithValue("@trinhdohocvan", nktt.TrinhDoHocVan.ToString());
                cmd.Parameters.AddWithValue("@trinhdochuyenmon", nktt.TrinhDoChuyenMon.ToString());
                cmd.Parameters.AddWithValue("@biettiengdantoc", nktt.BietTiengDanToc.ToString());
                cmd.Parameters.AddWithValue("@trinhdongoaingu", nktt.TrinhDoNgoaiNgu.ToString());
                cmd.Parameters.AddWithValue("@nghenghiep", nktt.NgheNghiep.ToString());
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


        public override bool update(NhanKhauTamTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhautamtru set noitamtru=@noitamtru, tungay=@tungay, denngay=@denngay,lydo=@lydo,sosotamtru=@sosotamtru where madinhdanh=@madinhdanh;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noitamtru", nktt.NoiTamTru.ToString());
                cmd.Parameters.AddWithValue("@tungay", nktt.TuNgay.ToString());
                cmd.Parameters.AddWithValue("@denngay", nktt.DenNgay.ToString());
                cmd.Parameters.AddWithValue("@lydo", nktt.LyDo.ToString());
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru.ToString());
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


        public DataSet TimKiem(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataSet ds = new DataSet();
                string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen,TenKhac,NgaySinh," +
                    " GioiTinh,NoiSinh,NguyenQuan,DanToc,TonGiao,QuocTich,HoChieu,NoiThuongTru,DiaChiHienNay," +
                    "SDT,TrinhDoHocVan,TrinhDoChuyenMon,BietTiengDanToc,TrinhDoNgoaiNgu, NgheNghiep, SoSoTamTru,NoiTamTru,TuNgay,DenNgay,LyDo " +
                    "FROM nhankhautamtru inner join nhankhau " +
                    "WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(ds);
                return ds;
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
        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                DataRow dr = dataset.Tables["nhankhautamtru"].NewRow();

                dr["manhankhautamtru"] = data.MaNhanKhauTamTru.ToString();
                dr["madinhdanh"] = data.MaDinhDanh.ToString();
                dr["noitamtru"] = data.NoiTamTru.ToString();
                dr["tungay"] = data.TuNgay;
                dr["denngay"] = data.DenNgay;
                dr["lydo"] = data.LyDo.ToString();
                dr["sosotamtru"] = data.SoSoTamTru.ToString();


                dataset.Tables["nhankhautamtru"].Rows.Add(dr);
                dataset.Tables["nhankhautamtru"].Rows.RemoveAt(dataset.Tables["nhankhautamtru"].Rows.Count - 1);
                sqlda.Update(dataset, "nhankhautamtru");
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



        //Get Data for Tinh Thanh Pho, Quan Huyen, Xa Phuong Thi Tran
        public List<string> GetListTinhThanh()
        {
            DataTable dt = new DataTable();
            List<string> tinhthanh_list = new List<string>();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM tinhthanhpho";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            tinhthanh_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return tinhthanh_list;
        }

        
        public string GetID_DiaChi(string table, string value, string nameColumn)
        {
            try
            {
                DataTable dt = new DataTable();
                string find = value;
                string ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT "+nameColumn+" FROM "+table+" WHERE ten='" + find + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                return ID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        public List<string> GetListQuanHuyen(string tentinhthanhpho)
        {
            DataTable dt = new DataTable();
            List<string> quanhuyen_list = new List<string>();

            string ID_TP = GetID_DiaChi("tinhthanhpho", tentinhthanhpho, "matp");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM quanhuyen WHERE matp='"+ID_TP+"' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            quanhuyen_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return quanhuyen_list;
        }


        public List<string> GetListXaPhuong(string tenquanhuyen)
        {
            DataTable dt = new DataTable();
            List<string> xaphuong_list = new List<string>();

            string ID_QH = GetID_DiaChi("quanhuyen", tenquanhuyen, "maqh");

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT ten FROM xaphuongthitran WHERE maqh='" + ID_QH + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            xaphuong_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("ten"))
                      .ToList();
            return xaphuong_list;
        }


        //
        //XỬ LÝ VỚI TIỀN ÁN TIỀN SỰ
        //
        //Lấy tiền án tiền sự với mã định danh
        public DataSet getTienAnTienSu(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *  FROM tienantiensu WHERE madinhdanh='"+madinhdanh+"'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
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

        //Xóa tiền án với mã tiền án
        public bool DeleteTienAn(string matienan)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from tienantiensu where matienantiensu=@matienan";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matienan", matienan);
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


        //
        //XỬ LÝ VỚI TIỂU SỬ
        //

            //Lấy tiểu sử với mã định danh
        public DataSet getTieuSu(string madinhdanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM tieusu WHERE madinhdanh='" + madinhdanh + "'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
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

        //Xóa tiểu sử với mã tiểu sử
        public bool DeleteTieuSu(string matieusu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from tieusu where matieusu=@matieusu";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matieusu", matieusu);
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




        //GIA HẠN

        //Lấy thời gian tạm trú
        public DateTime GetDayFromSoTamTru(string sql)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            try
            {
                DataTable dt = new DataTable();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);

                date = Convert.ToDateTime(dt.Rows[0][0]);
                return date;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return date;
        }


        public DateTime ThoiHanSoTamTru(string madinhdanh)
        {
            string sql = "SELECT denngay FROM nhankhautamtru where madinhdanh='" + madinhdanh + "'";
            return GetDayFromSoTamTru(sql);
        }


        public DateTime NgayDangKyTamTru(string madinhdanh)
        {
            string sql = "SELECT tungay FROM nhankhautamtru where madinhdanh='" + madinhdanh + "'";
            return GetDayFromSoTamTru(sql);
        }


        public bool InsertGiaHan(string madinhdanh, DateTime thoigian)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update nhankhautamtru set denngay=@denngay where madinhdanh=@madinhdanh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@denngay", thoigian);
                cmd.Parameters.AddWithValue("@madinhdanh", madinhdanh);
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
