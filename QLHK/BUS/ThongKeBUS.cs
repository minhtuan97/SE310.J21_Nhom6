using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class ThongKeBUS
    {
        static NhanKhau nk;
        static NhanKhauThuongTruDTO nkth;
        static NhanKhauTamTruDTO nktt;
        static SoHoKhauDTO shk;
        static SoTamTruDTO stt;

        public static string Dem1bang(string column, string aTable, string aGioiHan)
        {

            return ThongKeDAO.dem1Bang(column, aTable, aGioiHan); 
        }

        public static string DemNhanKhauThuongTru(string column, string gioiHan = "", string giaTri = "", bool coCuTru=true){
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND TIMESTAMPDIFF(MONTH, sohokhau.ngaycap, CURDATE())<=" + gioiHan;
            return ThongKeDAO.demNhanKhauThuongTru(column,gioiHan, giaTri, coCuTru);
        }
        public static string DemNhanKhauTamTru(string column, string gioiHan = "", string giaTri = "", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND TIMESTAMPDIFF(MONTH, nhankhautamtru.tungay, CURDATE())<=" + gioiHan;
            //" AND MONTH(DATEDIFF(CURDATE(), nhankhautamtru.tungay))<=" + gioiHan;
            //" AND MONTH(nhankhautamtru.tungay)=MONTH(DATE_SUB(CURDATE(), INTERVAL -" + gioiHan + " MONTH)) AND YEAR(nhankhautamtru.tungay)=YEAR(DATE_SUB(CURDATE(), INTERVAL -" + gioiHan + " MONTH))";
            return ThongKeDAO.demNhanKhauTamTru(column, gioiHan, giaTri, coCuTru);
        }
        public static string DemSoHoKhau(string column, string gioiHan="", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND TIMESTAMPDIFF(MONTH, sohokhau.ngaycap, CURDATE())<=" + gioiHan;
            return ThongKeDAO.demSoHoKhau(column, gioiHan, coCuTru);
        }
        public static string DemSoTamTru(string column, string gioiHan = "", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND TIMESTAMPDIFF(MONTH, sotamtru.ngaycap, CURDATE())<=" + gioiHan;
            return ThongKeDAO.demSoTamTru(column, gioiHan, coCuTru);
        }
    }
}
