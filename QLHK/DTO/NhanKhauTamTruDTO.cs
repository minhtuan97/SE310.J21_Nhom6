using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamTruDTO : NhanKhau
    {
        public string MaNhanKhauTamTru { get; set; }
        public string NoiTamTru { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string LyDo { get; set; }
        public string SoSoTamTru { get; set; }

        public NhanKhauTamTruDTO() : base() { }

        public NhanKhauTamTruDTO(string maNhanKhauTamTru, string noiTamTru, DateTime tuNgay, DateTime denNgay, string lyDo, string soSoTamTru, string str_MaDinhDanh)
        {
            MaNhanKhauTamTru = maNhanKhauTamTru;
            NoiTamTru = noiTamTru;
            TuNgay = tuNgay;
            DenNgay = denNgay;
            LyDo = lyDo;
            SoSoTamTru = soSoTamTru;
            MaDinhDanh = str_MaDinhDanh;
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
            MaNhanKhauTamTru = maNhanKhauTamTru;
            NoiTamTru = noiTamTru;
            TuNgay = tuNgay;
            DenNgay = denNgay;
            LyDo = lyDo;
            SoSoTamTru = soSoTamTru;
        }




    }
}
