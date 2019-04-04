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
        public List<NhanKhauThuongTruDTO> NhanKhau { get; set; }

        public SoHoKhauDTO() {
            NhanKhau = new List<NhanKhauThuongTruDTO>();
        }

        public SoHoKhauDTO(string soSoHoKhau, string maChuHoThuongTru, string diaChi, 
            DateTime ngayCap, string soDangKy, List<NhanKhauThuongTruDTO> nhanKhau)
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
            NhanKhau = new List<NhanKhauThuongTruDTO>();
        }

        public SoHoKhauDTO(SOHOKHAU shk, String tenchuho)
        {
            db = shk;
            TenChuHo = tenchuho;
        }

    }
}
