using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class NHANKHAUTAMTRU
    {
        public NHANKHAUTAMTRU(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, string str_MaDinhDanh) : this()
        {
            MANHANKHAUTAMTRU = maNhanKhauTamTru;
            NOITAMTRU = noiTamTru;
            TUNGAY = tuNgay;
            DENNGAY = denNgay;
            LYDO = lyDo;
            SOSOTAMTRU = soSoTamTru;
            MADINHDANH = str_MaDinhDanh;
        }

        public NHANKHAUTAMTRU(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, 
            string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
            string trinhDoNgoaiNgu, string ngheNghiep) : this()
        {
            MANHANKHAUTAMTRU = maNhanKhauTamTru;
            NOITAMTRU = noiTamTru;
            TUNGAY = tuNgay;
            DENNGAY = denNgay;
            LYDO = lyDo;
            SOSOTAMTRU = soSoTamTru;
            MADINHDANH = maDinhDanh;

            this.NHANKHAU = new NHANKHAU(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
    noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
    trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep);

        }

        public NHANKHAUTAMTRU(NHANKHAU nk) : this()
        {
            MANHANKHAUTAMTRU = "";
            NOITAMTRU = "";
            TUNGAY = new DateTime();
            DENNGAY = new DateTime();
            LYDO = "";
            SOSOTAMTRU = "";
            MADINHDANH = "";
            this.NHANKHAU = nk;
        }



        //public NhanKhauTamTruDTO(NHANKHAUTAMTRU nktt)
        //{
        //    dbnktamtru = nktt;
        //    db = nktt.NHANKHAU;
        //}

        //public NhanKhauTamTruDTO(NhanKhauTamTruDTO nktt)
        //{
        //    db = nktt.db;
        //    dbnktamtru = nktt.dbnktamtru;
        //}


    }
}
