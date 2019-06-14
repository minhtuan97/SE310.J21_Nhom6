using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class NHANKHAUTAMVANG
    {
        public NHANKHAUTAMVANG(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhdDanh) : this()
        {
            MANHANKHAUTAMVANG = maNhanKhauTamVang;
            MADINHDANH = maDinhdDanh;
            NGAYBATDAUTAMVANG = ngayBatDauTamVang;
            NGAYKETTHUCTAMVANG = ngayKetThucTamVang;
            LYDO = lyDo;
            NOIDEN = noiDen;
        }
        public NHANKHAUTAMVANG(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, 
            DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhDanh, string hoTen, string tenKhac, 
            DateTime ngaySinh, string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
             string trinhDoNgoaiNgu, string ngheNghiep) : this()
        {
            this.NHANKHAU = new NHANKHAU(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep);
            MANHANKHAUTAMVANG = maNhanKhauTamVang;
            NGAYBATDAUTAMVANG = ngayBatDauTamVang;
            NGAYKETTHUCTAMVANG = ngayKetThucTamVang;
            LYDO = lyDo;
            NOIDEN = noiDen;
        }

        //public NhanKhauTamVangDTO(NHANKHAUTAMVANG dbs)
        //{
        //    db = dbs;
        //}

    }
}
