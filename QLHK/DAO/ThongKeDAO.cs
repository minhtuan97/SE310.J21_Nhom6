using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class ThongKeDAO
    {
        public static string dem1Bang(string column, string aTable, string aGioiHan)
        {
            aGioiHan = String.IsNullOrEmpty(aGioiHan) ? "" : " AND " + aGioiHan;
            DataTable tb = DBConnection<object>.getData("SELECT COUNT(" + column + ") FROM" + aTable + aGioiHan).Tables[0];

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();

            }
            return "0";
        }

        public static string demNhanKhauThuongTru(string column, string gioiHan, string giaTri, bool coCuTru)
        {
            giaTri = String.IsNullOrEmpty(giaTri) ? "" : " AND " + giaTri;

            string cuTru = coCuTru ? "" : " AND diachihiennay NOT LIKE '%Đông Hòa, Dĩ An, Bình Dương%'";
            DataTable tb = DBConnection<object>.getData("SELECT COUNT(" + column 
                + ") FROM nhankhau, nhankhauthuongtru, sohokhau where nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh " +
                "AND nhankhauthuongtru.sosohokhau=sohokhau.sosohokhau" + gioiHan + giaTri + cuTru).Tables[0];

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();

            }
            return "0";
        }

        public static string demNhanKhauTamTru(string column, string gioiHan, string giaTri, bool coCuTru)
        {
            giaTri = String.IsNullOrEmpty(giaTri) ? "" : " AND " + giaTri;

            string cuTru = coCuTru ? "" : " AND diachihiennay NOT LIKE '%Đông Hòa, Dĩ An, Bình Dương%'";
            DataTable tb = DBConnection<object>.getData("SELECT COUNT(" + column
                + ") FROM nhankhau, nhankhautamtru, sotamtru where nhankhau.madinhdanh=nhankhautamtru.madinhdanh" +
                " AND nhankhautamtru.sosotamtru=sotamtru.sosotamtru" + gioiHan + giaTri + cuTru).Tables[0];

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();

            }
            return "";
        }

        public static string demSoHoKhau(string column, string gioiHan, bool coCuTru)
        {
            
            string cuTru = coCuTru ? "" : " AND diachihiennay NOT LIKE '%Đông Hòa, Dĩ An, Bình Dương%'";
            DataTable tb = DBConnection<object>.getData("SELECT COUNT(" + column
                + ") FROM sohokhau, nhankhau, nhankhauthuongtru where sohokhau.machuho=nhankhauthuongtru.manhankhauthuongtru AND nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh" + gioiHan + cuTru).Tables[0];

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();

            }
            return "0";
        }

        public static string demSoTamTru(string column, string gioiHan, bool coCuTru)
        {
            string cuTru = coCuTru ? "" : " AND diachihiennay NOT LIKE '%Đông Hòa, Dĩ An, Bình Dương%'";
            DataTable tb = DBConnection<object>.getData("SELECT COUNT(" + column
                + ") FROM sotamtru, nhankhau, nhankhautamtru where sotamtru.chuho=nhankhautamtru.manhankhautamtru AND nhankhau.madinhdanh=nhankhautamtru.madinhdanh" + gioiHan + cuTru).Tables[0];

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();

            }
            return "0";
        }

    }
}
