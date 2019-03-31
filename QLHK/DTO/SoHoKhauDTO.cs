using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SoHoKhauDTO
    {
        public SOHOKHAU db;
        public string TenChuHo;
        public List<NHANKHAUTHUONGTRU> NhanKhau { get; set; }

        public SoHoKhauDTO() {
            NhanKhau = new List<NHANKHAUTHUONGTRU>();
        }

        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi, 
            DateTime ngayCap, string soDangKy, List<NHANKHAUTHUONGTRU> nhanKhau)
        {
            db.SOSOHOKHAU = soSoHoKhau;
            db.MACHUHO = maChuHoThuongTru;
            db.DIACHI = diaChi;
            db.NGAYCAP = ngayCap;
            db.SODANGKY = soDangKy;
            NhanKhau = nhanKhau;
        }
        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi,
            DateTime ngayCap, string soDangKy)
        {
            db.SOSOHOKHAU = soSoHoKhau;
            db.MACHUHO = maChuHoThuongTru;
            db.DIACHI = diaChi;
            db.NGAYCAP = ngayCap;
            db.SODANGKY = soDangKy;
            NhanKhau = new List<NHANKHAUTHUONGTRU>();
        }

    }
}
