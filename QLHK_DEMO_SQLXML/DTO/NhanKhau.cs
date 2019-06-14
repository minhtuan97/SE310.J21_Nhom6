using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class NHANKHAU
    {
        //public NHANKHAU(NHANKHAU dbs)
        //{
        //}
        public NHANKHAU(string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh, 
            string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao, 
            string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay, 
            string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc, 
            string trinhDoNgoaiNgu, string ngheNghiep):this()
        {
            MADINHDANH = maDinhDanh;
            HOTEN = hoTen;
            TENKHAC = tenKhac;
            NGAYSINH = ngaySinh;
            GIOITINH = gioiTinh;
            NOISINH = noiSinh;
            NGUYENQUAN = nguyenQuan;
            DANTOC = danToc;
            TONGIAO = tonGiao;
            QUOCTICH = quocTich;
            HOCHIEU = hoChieu;
            NOITHUONGTRU = noiThuongTru;
            DIACHIHIENNAY = diaChiHienNay;
            SDT = sDT;
            TRINHDOHOCVAN = trinhDoHocVan;
            TRINHDOCHUYENMON = trinhDoChuyenMon;
            BIETTIENGDANTOC = bietTiengDanToc;
            TRINHDONGOAINGU = trinhDoNgoaiNgu;
            NGHENGHIEP = ngheNghiep;
        }
    }
}
