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
        static NHANKHAU nk;
        static NHANKHAUTHUONGTRU nkth;
        static NHANKHAUTAMTRU nktt;
        static SOHOKHAU shk;
        static SOTAMTRU stt;

        public static string Dem1bang(string column, string aTable, string aGioiHan)
        {

            return ThongKeDAO.dem1Bang(column, aTable, aGioiHan); 
        }

        public static string DemNhanKhauThuongTru(string column, string gioiHan = "", string giaTri = "", bool coCuTru=true){
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND DATEDIFF(MONTH, sohokhau.ngaycap, GETDATE())<=" + gioiHan;
            return ThongKeDAO.demNhanKhauThuongTru(column,gioiHan, giaTri, coCuTru);
        }
        public static string DemNhanKhauTamTru(string column, string gioiHan = "", string giaTri = "", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND DATEDIFF(MONTH, nhankhautamtru.tungay, GETDATE())<=" + gioiHan;
            //" AND MONTH(DATEDIFF(GETDATE(), nhankhautamtru.tungay))<=" + gioiHan;
            //" AND MONTH(nhankhautamtru.tungay)=MONTH(DATE_SUB(GETDATE(), INTERVAL -" + gioiHan + " MONTH)) AND YEAR(nhankhautamtru.tungay)=YEAR(DATE_SUB(GETDATE(), INTERVAL -" + gioiHan + " MONTH))";
            return ThongKeDAO.demNhanKhauTamTru(column, gioiHan, giaTri, coCuTru);
        }
        public static string DemSoHoKhau(string column, string gioiHan="", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND DATEDIFF(MONTH, sohokhau.ngaycap, GETDATE())<=" + gioiHan;
            return ThongKeDAO.demSoHoKhau(column, gioiHan, coCuTru);
        }
        public static string DemSoTamTru(string column, string gioiHan = "", bool coCuTru = true)
        {
            gioiHan = string.IsNullOrEmpty(gioiHan) ? "" : " AND DATEDIFF(MONTH, sotamtru.ngaycap, GETDATE())<=" + gioiHan;
            return ThongKeDAO.demSoTamTru(column, gioiHan, coCuTru);
        }
    }
}
