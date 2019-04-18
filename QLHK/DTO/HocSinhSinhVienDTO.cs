using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhSinhVienDTO
    {
        public HOCSINHSINHVIEN dbhssv;
        public NHANKHAU dbnk;

        public HocSinhSinhVienDTO() : base() { }

        public HocSinhSinhVienDTO(string maHSSV, string maDinhDanh, string truong, string diaChiThuongTru, 
            DateTime tGBDTTTT, DateTime tGKTTTTT, string viPham)
        {
            dbhssv.MAHSSV = maHSSV;
            dbhssv.MADINHDANH = maDinhDanh;
            dbhssv.TRUONG = truong;
            dbhssv.DIACHITHUONGTRU = diaChiThuongTru;
            dbhssv.THOIGIANBATDAUTAMTRUTHUONGTRU = tGBDTTTT;
            dbhssv.THOIGIANKETTHUCTAMTRUTHUONGTRU = tGKTTTTT;
            dbhssv.VIPHAM = viPham;
        }

        public HocSinhSinhVienDTO(HOCSINHSINHVIEN dbs)
        {
            dbhssv = dbs;
            dbnk = dbs.NHANKHAU;
        }
    }
}
