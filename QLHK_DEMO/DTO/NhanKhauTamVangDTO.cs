using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauTamVangDTO: NhanKhau
    {
        public NHANKHAUTAMVANG db= new NHANKHAUTAMVANG();
       
        public NhanKhauTamVangDTO() { }

        public NhanKhauTamVangDTO(string maNhanKhauTamVang, DateTime ngayBatDauTamVang, DateTime ngayKetThucTamVang, string lyDo, string noiDen, string maDinhdDanh)
        {
            db.MANHANKHAUTAMVANG = maNhanKhauTamVang;
            db.MADINHDANH = maDinhdDanh;
            db.NGAYBATDAUTAMVANG = ngayBatDauTamVang;
            db.NGAYKETTHUCTAMVANG = ngayKetThucTamVang;
            db.LYDO = lyDo;
            db.NOIDEN = noiDen;
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
            db.MANHANKHAUTAMVANG = maNhanKhauTamVang;
            db.NGAYBATDAUTAMVANG = ngayBatDauTamVang;
            db.NGAYKETTHUCTAMVANG = ngayKetThucTamVang;
            db.LYDO = lyDo;
            db.NOIDEN = noiDen;
        }

        public NhanKhauTamVangDTO(NHANKHAUTAMVANG dbs)
        {
            db = dbs;
        }

    }
}
