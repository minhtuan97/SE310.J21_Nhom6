using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamVangDTO: NhanKhau
    {
        public string MaNhanKhauTamVang { get; set; }
        public DateTime NgayBatDauTamVang { get; set; }
        public DateTime NgayKetThucTamVang { get; set; }
        public string LyDo { get; set; }
        public string NoiDen { get; set; }

        public NhanKhauTamVangDTO() { }

        public NhanKhauTamVangDTO(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhdDanh)
        {
            MaNhanKhauTamVang = maNhanKhauTamVang;
            MaDinhDanh = maDinhdDanh;
            NgayBatDauTamVang = ngayBatDauTamVang;
            NgayKetThucTamVang = ngayKetThucTamVang;
            LyDo = lyDo;
            NoiDen = noiDen;
        }
        public NhanKhauTamVangDTO(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, 
            DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhDanh, string hoTen, string tenKhac, 
            DateTime ngaySinh, string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
             string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh, 
                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
        {
            MaNhanKhauTamVang = maNhanKhauTamVang;
            NgayBatDauTamVang = ngayBatDauTamVang;
            NgayKetThucTamVang = ngayKetThucTamVang;
            LyDo = lyDo;
            NoiDen = noiDen;
        }

    }
}
