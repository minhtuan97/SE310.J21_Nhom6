﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class NHANKHAUTHUONGTRU
    {
        public NHANKHAUTHUONGTRU(string maNhanKhauThuongTru, string diaChiThuongTru, 
            string quanHeVoiChuHo, string soSoHoKhau, string maDinhDanh):this()
        {
            MANHANKHAUTHUONGTRU = maNhanKhauThuongTru;
            DIACHITHUONGTRU = diaChiThuongTru;
            QUANHEVOICHUHO = quanHeVoiChuHo;
            SOSOHOKHAU = soSoHoKhau;
            MADINHDANH = maDinhDanh;
        }

        public NHANKHAUTHUONGTRU(string maNhanKhauThuongTru, string diaChiThuongTru,
            string quanHeVoiChuHo, string soSoHoKhau,
             string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
             string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
             string trinhDoNgoaiNgu, string ngheNghiep) : this()
        {
            MANHANKHAUTHUONGTRU = maNhanKhauThuongTru;
            DIACHITHUONGTRU = diaChiThuongTru;
            QUANHEVOICHUHO = quanHeVoiChuHo;
            SOSOHOKHAU = soSoHoKhau;
            MADINHDANH = maDinhDanh;
            this.NHANKHAU = new NHANKHAU(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep);
        }

        public NHANKHAUTHUONGTRU(NHANKHAU nk) : this()
        {
            MANHANKHAUTHUONGTRU = "";
            DIACHITHUONGTRU = "";
            QUANHEVOICHUHO = "";
            SOSOHOKHAU = "";
            this.NHANKHAU = nk;
        }

        //public NhanKhauThuongTruDTO(DataRow dt):base(dt["madinhdanh"].ToString(),dt["hoten"].ToString(), dt["tenkhac"].ToString(), DateTime.Parse(dt["ngaysinh"].ToString()),
        //    dt["gioitinh"].ToString(), dt["noisinh"].ToString(), dt["nguyenquan"].ToString(), dt["dantoc"].ToString(), dt["tongiao"].ToString(), dt["quoctich"].ToString(),
        //    dt["hochieu"].ToString(), dt["noithuongtru"].ToString(), dt["diachihiennay"].ToString(), dt["sdt"].ToString(), dt["trinhdohocvan"].ToString(),
        //    dt["trinhdochuyenmon"].ToString(), dt["biettiengdantoc"].ToString(), dt["trinhdongoaingu"].ToString(), dt["nghenghiep"].ToString())
        //{
        //    if (dt.ItemArray.Length == 0)
        //        return;
        //    MaNhanKhauThuongTru = dt["manhankhauthuongtru"].ToString();
        //    DiaChiThuongTru = dt["diachithuongtru"].ToString();
        //    QuanHeVoiChuHo = dt["quanhevoichuho"].ToString();
        //    SoSoHoKhau = dt["sosohokhau"].ToString();
        //}

        //public NhanKhauThuongTruDTO(NHANKHAUTHUONGTRU nktt)
        //{
        //    dbnktt = nktt;
        //    db = nktt.NHANKHAU;
        //}

        //public NhanKhauThuongTruDTO(NHANKHAU nk)
        //{
        //    dbnktt = new NHANKHAUTHUONGTRU();
        //    db = nk;
        //}

        //public NhanKhauThuongTruDTO(NhanKhauThuongTruDTO nktt)
        //{
        //    db = nktt.db;
        //    dbnktt = nktt.dbnktt;
        //}
    }
}