using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamTruDTO : NhanKhau
    {
        public NHANKHAUTAMTRU db;

        public NhanKhauTamTruDTO() : base() { }

        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, string str_MaDinhDanh)
        {
            db.MANHANKHAUTAMTRU = maNhanKhauTamTru;
            db.NOITAMTRU = noiTamTru;
            db.TUNGAY = tuNgay;
            db.DENNGAY = denNgay;
            db.LYDO = lyDo;
            db.SOSOTAMTRU = soSoTamTru;
            db.MADINHDANH = str_MaDinhDanh;
        }

        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, 
            string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
            string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh,hoTen,tenKhac, ngaySinh,gioiTinh, 
                noiSinh,nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
        {
            db.MANHANKHAUTAMTRU = maNhanKhauTamTru;
            db.NOITAMTRU = noiTamTru;
            db.TUNGAY = tuNgay;
            db.DENNGAY = denNgay;
            db.LYDO = lyDo;
            db.SOSOTAMTRU = soSoTamTru;
            db.MADINHDANH = maDinhDanh;
        }

        public NhanKhauTamTruDTO(NHANKHAUTAMTRU dbs)
        {
            db = dbs;
        }


    }
}
