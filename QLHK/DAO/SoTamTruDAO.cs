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
    public class SoTamTruDAO:DBConnection<SoTamTruDTO>
    {
        public SoTamTruDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT* , 'Delete' as 'Change' FROM sotamtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sotamtru");
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


        public  DataSet getAllSoTamTru()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM sotamtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sotamtru");
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


        public override bool insert(SoTamTruDTO sotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into sotamtru values(@sosotamtru, @chuhotamtru, @noitamtru, @ngaycap, @denngay)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosotamtru", sotamtru.SoSoTamTru);
                cmd.Parameters.AddWithValue("@chuhotamtru", sotamtru.MaChuHoTamTru);
                cmd.Parameters.AddWithValue("@noitamtru", sotamtru.NoiTamTru);
                cmd.Parameters.AddWithValue("@ngaycap", sotamtru.NgayCap);
                cmd.Parameters.AddWithValue("@denngay", sotamtru.DenNgay);
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


        /// <summary>
        /// Lấy mã định danh
        /// </summary>
        /// <param name="sosotamtru"></param>
        /// <returns></returns>
        public List<string> getListMaDinhDanhBySoSoTamTru(string sosotamtru)
        {
            DataTable dt = new DataTable();
            List<string> madinhdanh_list = new List<string>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT madinhdanh FROM nhankhautamtru WHERE sosotamtru='" + sosotamtru + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            madinhdanh_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("madinhdanh"))
                      .ToList();
            return madinhdanh_list;
        }

        public List<string> getListExperiedSoTamTru()
        {
            DataTable dt = new DataTable();
            List<string> sotamtru_list = new List<string>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT SOSOTAMTRU FROM `sotamtru` WHERE DENNGAY<CURDATE() ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            sotamtru_list = dt.AsEnumerable()
                      .Select(r => r.Field<string>("SOSOTAMTRU"))
                      .ToList();
            return sotamtru_list;
        }


        public bool XoaSoTamTru(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                NhanKhauTamTruDAO nhankhautamtruDao = new NhanKhauTamTruDAO();
                List<string> madinhdanh_list = getListMaDinhDanhBySoSoTamTru(sosotamtru);

                //Xóa nhân khẩu tạm trú trong sổ tạm trú
                for(int i=0; i < madinhdanh_list.Count; i++)
                {
                    nhankhautamtruDao.XoaNKTT(madinhdanh_list[i]);
                }
                string sql = "delete from sotamtru where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosotamtru", sosotamtru);
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



        public bool DeleteExperiedSoTamTru()
        {
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                     //Lấy list số sổ tạm trú quá hạn
                    List<string> sosotamtru_list = getListExperiedSoTamTru();

                    //Xóa list số tạm trú quá hạn
                    for (int i = 0; i < sosotamtru_list.Count; i++)
                    {
                            XoaSoTamTru(sosotamtru_list[i]);
                    }
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
                dataset.Tables["sotamtru"].Rows[row].Delete();
                sqlda.Update(dataset, "sotamtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(SoTamTruDTO sotamtru, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update sotamtru set chuho=@chuho, noitamtru=@noitamtru, ngaycap=@ngaycap, denngay=@denngay where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sosotamtru", sotamtru.SoSoTamTru);
                cmd.Parameters.AddWithValue("@chuho", sotamtru.MaChuHoTamTru);
                cmd.Parameters.AddWithValue("@noitamtru", sotamtru.NoiTamTru);
                cmd.Parameters.AddWithValue("@ngaycap", sotamtru.NgayCap);
                cmd.Parameters.AddWithValue("@denngay", sotamtru.DenNgay);
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
        public DataSet TimKiem(string sosotamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM sotamtru WHERE sosotamtru='"+sosotamtru+"'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "sotamtru");
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
        public override bool insert_table(SoTamTruDTO data)
        {
            try
            {
                DataRow dr = dataset.Tables["sotamtru"].NewRow();
                dr["sosotamtru"] = data.SoSoTamTru;
                dr["chuho"] = data.MaChuHoTamTru;
                dr["noitamtru"] = data.NoiTamTru;
                dr["ngaycap"] = data.NgayCap;
                dr["denngay"] = data.DenNgay;

                dataset.Tables["sotamtru"].Rows.Add(dr);
                dataset.Tables["sotamtru"].Rows.RemoveAt(dataset.Tables["sotamtru"].Rows.Count - 1);
                sqlda.Update(dataset, "sotamtru");
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


        //Lấy thông tin của Chỗ ở trong bảng thành phố, quận huyện, xã phường thị trấn

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
                string sqltemp = "SELECT " + nameColumn + " FROM " + table + " WHERE ten='" + find + "'";
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
            string sql = "SELECT ten FROM quanhuyen WHERE matp='" + ID_TP + "' ";
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

        /// <summary>
        /// Lấy danh sách tên nhân khẩu trong sổ tạm trú
        /// </summary>
        /// <param name="sosotamtru"></param>
        /// <returns></returns>
        public List<string> ImportToComboboxMaChuHo(string sosotamtru)
        {
            DataTable dt = new DataTable();
            List<string> list_tennhankhau = new List<string>();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            string sql = "SELECT hoten FROM nhankhau inner join nhankhautamtru where nhankhau.madinhdanh=nhankhautamtru.madinhdanh and sosotamtru='" + sosotamtru + "' ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dt);

            list_tennhankhau = dt.AsEnumerable()
                      .Select(r => r.Field<string>("HoTen"))
                      .ToList();
            return list_tennhankhau;
        }


        public string convertTentoMaNhanKhauTamTru(string tennhankhau, string sosotamtru)
        {
            try
            {
                DataTable dt = new DataTable();
                string ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT manhankhautamtru FROM nhankhau inner join nhankhautamtru where nhankhau.madinhdanh=nhankhautamtru.madinhdanh and HOTEN='"+tennhankhau+"' and sosotamtru='"+sosotamtru+"'";
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

        public string FindMaChuHo(string sosotamtru)
        {
            try
            {
                DataTable dt = new DataTable();
                string ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT chuho FROM sotamtru where sosotamtru='"+sosotamtru+"'";
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


        public string FindTenChuHoTamTru(string sosotamtru)
        {
            try
            {
                DataTable dt = new DataTable();
                string machuho=FindMaChuHo(sosotamtru);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sqltemp = "SELECT hoten FROM nhankhau INNER JOIN nhankhautamtru ON nhankhau.madinhdanh=nhankhautamtru.madinhdanh where manhankhautamtru='" + machuho + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqltemp, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
                string ten = "";
                ten = dt.Rows[0][0].ToString();
                return ten;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        //Xác định sự tồn tại của một trường trong một bảng
        public int ExistedValue(string sql)
        {
            try
            {
                int numrow = 0;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                numrow = Convert.ToInt32(cmd.ExecuteScalar());
                return numrow;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 100;
        }


        public int Existed_SoTamTru(string sosotamtru)
        {
            string sql = "SELECT COUNT(*) FROM sotamtru WHERE sosotamtru='" + sosotamtru + "'";
            int num = ExistedValue(sql);
            return num;
        }

        public int Existed_NhanKhau(string madinhdanh)
        {
            string sql = "SELECT COUNT(*) FROM nhankhau WHERE madinhdanh='" + madinhdanh + "'";
            int num = ExistedValue(sql);
            return num;
        }

        public int Existed_NhanKhauTamTru(string manhankhautamtru)
        {
            string sql = "SELECT COUNT(*) FROM nhankhautamtru WHERE manhankhautamtru='" + manhankhautamtru + "'";
            int num = ExistedValue(sql);
            return num;
        }


        public int Duplicated_NhanKhauTamTru(string manhankhautamtru, string sosotamtru)
        {
            string sql = "SELECT COUNT(*) FROM nhankhautamtru inner join sotamtru ON nhankhautamtru.sosotamtru=sotamtru.sosotamtru WHERE manhankhautamtru='" + manhankhautamtru + "' and sotamtru.sosotamtru!='"+sosotamtru+"'";
            int num = ExistedValue(sql);
            return num;
        }


        public int Existed_TieuSu(string matieusu)
        {
            string sql = "SELECT COUNT(*) FROM tieusu WHERE matieusu='" + matieusu + "'";
            int num = ExistedValue(sql);
            return num;
        }

        public int Existed_TienAn(string matienan)
        {
            string sql = "SELECT COUNT(*) FROM tienantiensu WHERE matienantiensu='" + matienan + "'";
            int num = ExistedValue(sql);
            return num;
        }

        //GIA HẠN

            //Lấy thời gian tạm trú
        public DateTime GetDayFromSoTamTru(string sql)
        {
            DateTime date = new DateTime(12/12/1800);
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


        public DateTime ThoiHanSoTamTru(string sosotamtru)
        {
            string sql = "SELECT denngay FROM sotamtru where sosotamtru='" + sosotamtru + "'";
            return GetDayFromSoTamTru(sql);
        }


        public DateTime NgayDangKyTamTru(string sosotamtru)
        {
            string sql = "SELECT ngaycap FROM sotamtru where sosotamtru='" + sosotamtru + "'";
            return GetDayFromSoTamTru(sql);
        }


        public bool InsertGiaHan(string sosotamtru, DateTime thoigian)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update sotamtru set denngay=@denngay where sosotamtru=@sosotamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@denngay", thoigian);
                cmd.Parameters.AddWithValue("@sosotamtru", sosotamtru);
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


        public string GetValue_Sub(string table, string value,string namecolumnWhere, string nameColumn)
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
                string sqltemp = "SELECT " + nameColumn + " FROM " + table + " WHERE "+ namecolumnWhere + "='" + find + "'";
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


    }

}
