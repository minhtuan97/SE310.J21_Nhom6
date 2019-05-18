using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public static class TrinhTaoMa
    {
        public static quanlyhokhauEntities qlhk = new quanlyhokhauEntities();

        #region các hàm lấy mã cuối cùng
        public static string getLastID_MaDinhDanh()
        {
            string sql = "SELECT madinhdanh FROM nhankhau ORDER BY madinhdanh DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "000000000000";
            }
        }
        public static string getLastID_SoSoHoKhau()
        {
            string sql = "SELECT sosohokhau FROM sohokhau where sosohokhau LIKE '08%' ORDER BY sosohokhau DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "080000000";
            }
        }
        public static string getLastID_MaNhanKhauThuongTru()
        {
            string sql = "SELECT manhankhauthuongtru FROM nhankhauthuongtru where manhankhauthuongtru LIKE 'TH%' ORDER BY manhankhauthuongtru DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "TH0000000";
            }
        }
        public static string getLastID_SoSoTamTru()
        {
            string sql = "SELECT sosotamtru FROM sotamtru where sosotamtru LIKE '08%' ORDER BY sosotamtru DESC LIMIT 1;";

            try
            {
                 return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch(Exception e)
            {
                return "080000000";
            }

            
        }
        public static string getLastID_MaNhanKhauTamTru()
        {
            string sql = "SELECT manhakhautamtru FROM nhankhautamtru where manhakhautamtru LIKE 'TT%' ORDER BY manhakhautamtru DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "TT0000000";
            }
        }

        public static string getLastID_MaTieuSu()
        {
            string sql = "SELECT matieusu FROM tieusu where matieusu LIKE 'TS%' ORDER BY matieusu DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "TS0000000";
            }
        }

        public static string getLastID_MaTienAnTienSu()
        {
            string sql = "SELECT matienantiensu FROM tienantiensu where matienantiensu LIKE 'TA%' ORDER BY matienantiensu DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "TA0000000";
            }
        }

        public static string getLastID_CanBo()
        {
            string sql = "SELECT macanbo FROM canbo where macanbo LIKE 'CB%' ORDER BY macanbo DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "CB0000000";
            }
        }
        public static string getLastID_NhanKhauTamVang()
        {
            string sql = "SELECT manhankhautamvang FROM nhankhautamvang where manhankhautamvang LIKE 'TV%' ORDER BY manhankhautamvang DESC LIMIT 1;";
            try
            {
                return qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch (Exception e)
            {
                return "TV0000000";
            }
        }

        public static string getLastID_SoHoKhauSoTamTru()
        {
            string hk = getLastID_SoSoHoKhau();
            string tt = getLastID_SoSoTamTru();

            return Int32.Parse(hk.Substring(2)) > Int32.Parse(tt.Substring(2)) ? hk : tt;
        }

        #endregion

        #region Các hàm tăng mã
        public static string TangMa9kytu(string mabandau)
        {
            string str1 = mabandau.Substring(0, 2);
            string str2 = mabandau.Substring(2);
            int i_str2 = Int32.Parse(str2) + 1;
            string str3 = i_str2.ToString();
            string str4 = null;
            for (int i = 0; i < (7 - str3.Length); i++)
            {
                str4 = str4 + "0";
            }
            string chuoikq = str1 + str4 + str3;
            return chuoikq;
        }
        public static string TangMa12Kytu(string gioitinh, string namsinh)
        {
            string str_matinh = "074";
            string str_magioitinh = null;
            string str_manamsinh = null;
            string sausocuoi = null;
            string kq = null;

            string sql = "select madinhdanh from nhankhau where gioitinh='" + gioitinh + "' and year(ngaysinh)='" + namsinh + "'ORDER BY madinhdanh desc";

            string madinhdanh;

            try
            {
                madinhdanh = qlhk.Database.SqlQuery<String>(sql).Single();
            }
            catch(Exception e)
            {
                return "074219000001";
            }


            int i_namsinh = Int16.Parse(namsinh);
            if (i_namsinh > 1900 & i_namsinh <= 1999)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "0";
                }
                //if (String.Compare(gioitinh, "nu", true) == 0)
                else
                {
                    str_magioitinh = "1";
                }
            }
            if (i_namsinh >= 2000 & i_namsinh <= 2099)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "2";
                }
                //if (String.Compare(gioitinh, "nu", true) == 0) 
                else
                {
                    str_magioitinh = "3";
                }
            }
            if (i_namsinh >= 2100 & i_namsinh <= 2199)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "4";
                }
                //if (String.Compare(gioitinh, "nu", true) == 0)
                else
                {
                    str_magioitinh = "5";
                }
            }
            if (i_namsinh >= 2200 & i_namsinh <= 2299)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "6";
                }
                //if (String.Compare(gioitinh, "nu", true) == 0)
                else
                {
                    str_magioitinh = "7";
                }
            }
            if (i_namsinh >= 2300 & i_namsinh <= 2399)
            {
                if (String.Compare(gioitinh, "nam", true) == 0)
                {
                    str_magioitinh = "8";
                }
                //if (String.Compare(gioitinh, "nu", true) == 0)
                else
                {
                    str_magioitinh = "9";
                }
            }

            str_manamsinh = namsinh.Substring(2);

            string str_madinhdanh;
            try
            {
                sql = "select madinhdanh from nhankhau where gioitinh='" + gioitinh + "' and year(ngaysinh)='" + namsinh + "' ORDER BY madinhdanh DESC LIMIT 1";
                madinhdanh = qlhk.Database.SqlQuery<String>(sql).Single();
                str_madinhdanh = madinhdanh;
            }
            catch (Exception e)
            {
                sausocuoi = "000001";
                kq = str_matinh + str_magioitinh + str_manamsinh + sausocuoi;
                return kq;
            }
            sausocuoi = str_madinhdanh.Substring(6);
            int x = Int32.Parse(sausocuoi) + 1;
            sausocuoi = x.ToString();
            string str = null;
            for (int i = 0; i < 6 - sausocuoi.Length; i++)
            {
                str = str + "0";
            }
            kq = str_matinh + str_magioitinh + str_manamsinh + str + sausocuoi;
            return kq;
        }
        #endregion

        #region Các hàm phụ
        public static string random7()
        {
            Random rand = new Random();
            string num =  rand.Next(9999999).ToString();
            int len = num.Length;

            for (int i = 0; i < 7-len; i++)
            {
                num = "0" + num;
            }
            return num;
        }
        #endregion
    }
}
