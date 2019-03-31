using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhau
    {
        NHANKHAU db;

        public quanlyhokhauDataContext qlhk;

        public NhanKhau() {
            qlhk = new quanlyhokhauDataContext();
        }

        public NhanKhau(string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh, 
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao, 
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay, 
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc, 
            string trinhDoNgoaiNgu, string ngheNghiep)
        {
            db.MADINHDANH = maDinhDanh;
            db.HOTEN = hoTen;
            db.TENKHAC = tenKhac;
            db.NGAYSINH = ngaySinh;
            GioiTinh = gioiTinh;
            NoiSinh = noiSinh;
            NguyenQuan = nguyenQuan;
            DanToc = danToc;
            TonGiao = tonGiao;
            QuocTich = quocTich;
            HoChieu = hoChieu;
            NoiThuongTru = noiThuongTru;
            DiaChiHienNay = diaChiHienNay;
            SDT = sDT;
            TrinhDoHocVan = trinhDoHocVan;
            TrinhDoChuyenMon = trinhDoChuyenMon;
            BietTiengDanToc = bietTiengDanToc;
            TrinhDoNgoaiNgu = trinhDoNgoaiNgu;
            NgheNghiep = ngheNghiep;
        }
    }
}
