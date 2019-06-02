using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauDTO
    {
        public NHANKHAU db = new NHANKHAU();


        public NhanKhauDTO() {
        }

        public NhanKhauDTO(NHANKHAU dbs)
        {
            db = dbs;
        }
        public NhanKhauDTO(string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh, 
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao, 
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay, 
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc, 
            string trinhDoNgoaiNgu, string ngheNghiep)
        {
            db.MADINHDANH = maDinhDanh;
            db.HOTEN = hoTen;
            db.TENKHAC = tenKhac;
            db.NGAYSINH = ngaySinh;
            db.GIOITINH = gioiTinh;
            db.NOISINH = noiSinh;
            db.NGUYENQUAN = nguyenQuan;
            db.DANTOC = danToc;
            db.TONGIAO = tonGiao;
            db.QUOCTICH = quocTich;
            db.HOCHIEU = hoChieu;
            db.NOITHUONGTRU = noiThuongTru;
            db.DIACHIHIENNAY = diaChiHienNay;
            db.SDT = sDT;
            db.TRINHDOHOCVAN = trinhDoHocVan;
            db.TRINHDOCHUYENMON = trinhDoChuyenMon;
            db.BIETTIENGDANTOC = bietTiengDanToc;
            db.TRINHDONGOAINGU = trinhDoNgoaiNgu;
            db.NGHENGHIEP = ngheNghiep;
        }

        public NhanKhauDTO(string maDinhDanh, string hoTen, DateTime ngaySinh)
        {
            db.MADINHDANH = maDinhDanh;
            db.HOTEN = hoTen;
            db.NGAYSINH = ngaySinh;
        }


    }
}
