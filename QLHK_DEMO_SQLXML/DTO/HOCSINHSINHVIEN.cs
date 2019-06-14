using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class HOCSINHSINHVIEN
    {
        public HOCSINHSINHVIEN(string maHSSV, string maDinhDanh, string truong, string diaChiThuongTru, 
            DateTime tGBDTTTT, DateTime tGKTTTTT, string viPham) : this()
        {
            MAHSSV = maHSSV;
            MADINHDANH = maDinhDanh;
            TRUONG = truong;
            DIACHITHUONGTRU = diaChiThuongTru;
            THOIGIANBATDAUTAMTRUTHUONGTRU = tGBDTTTT;
            THOIGIANKETTHUCTAMTRUTHUONGTRU = tGKTTTTT;
            VIPHAM = viPham;
        }

        //public HOCSINHSINHVIEN(HOCSINHSINHVIEN dbs)
        //{
        //    dbhssv = dbs;
        //    dbnk = dbs.NHANKHAU;
        //}
    }
}
