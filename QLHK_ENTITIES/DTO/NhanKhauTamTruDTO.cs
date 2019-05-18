using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamTruDTO : NhanKhauDTO
    {
        public NHANKHAUTAMTRU dbnktamtru = new NHANKHAUTAMTRU();

        public NhanKhauTamTruDTO() : base() { }

        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, string str_MaDinhDanh)
        {
            dbnktamtru.MANHAKHAUTAMTRU = maNhanKhauTamTru;
            dbnktamtru.NOITAMTRU = noiTamTru;
            dbnktamtru.TUNGAY = tuNgay;
            dbnktamtru.DENNGAY = denNgay;
            dbnktamtru.LYDO = lyDo;
            dbnktamtru.SOSOTAMTRU = soSoTamTru;
            dbnktamtru.MADINHDANH = str_MaDinhDanh;
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
            dbnktamtru.MANHAKHAUTAMTRU = maNhanKhauTamTru;
            dbnktamtru.NOITAMTRU = noiTamTru;
            dbnktamtru.TUNGAY = tuNgay;
            dbnktamtru.DENNGAY = denNgay;
            dbnktamtru.LYDO = lyDo;
            dbnktamtru.SOSOTAMTRU = soSoTamTru;
            dbnktamtru.MADINHDANH = maDinhDanh;
        }



        public NhanKhauTamTruDTO(NHANKHAUTAMTRU nktt)
        {
            dbnktamtru = nktt;
            db = nktt.NHANKHAU;
        }

        public NhanKhauTamTruDTO(NHANKHAU nk)
        {
            dbnktamtru = new NHANKHAUTAMTRU();
            db = nk;
        }

        public NhanKhauTamTruDTO(NhanKhauTamTruDTO nktt)
        {
            db = nktt.db;
            dbnktamtru = nktt.dbnktamtru;
        }


    }
}
