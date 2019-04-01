﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanKhauThuongTruDTO:NhanKhau
    {
        public string MaNhanKhauThuongTru { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public string SoSoHoKhau { get; set; }


        public NhanKhauThuongTruDTO() { }

        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru, 
            string quanHeVoiChuHo, string soSoHoKhau, string maDinhDanh)
        {
            MaNhanKhauThuongTru = maNhanKhauThuongTru;
            DiaChiThuongTru = diaChiThuongTru;
            QuanHeVoiChuHo = quanHeVoiChuHo;
            SoSoHoKhau = soSoHoKhau;
            MaDinhDanh = maDinhDanh;
        }

        public NhanKhauThuongTruDTO(string maNhanKhauThuongTru, string diaChiThuongTru,
            string quanHeVoiChuHo, string soSoHoKhau,
             string maDinhDanh, string hoTen, string tenKhac, DateTime ngaySinh,
             string gioiTinh, string noiSinh, string nguyenQuan, string danToc, string tonGiao,
             string quocTich, string hoChieu, string noiThuongTru, string diaChiHienNay,
             string sDT, string trinhDoHocVan, string trinhDoChuyenMon, string bietTiengDanToc,
             string trinhDoNgoaiNgu, string ngheNghiep) : base(maDinhDanh, hoTen, tenKhac, ngaySinh, gioiTinh,
                 noiSinh, nguyenQuan, danToc, tonGiao, quocTich, hoChieu, noiThuongTru, diaChiHienNay, sDT, trinhDoHocVan,
                 trinhDoChuyenMon, bietTiengDanToc, trinhDoNgoaiNgu, ngheNghiep)
        {
            MaNhanKhauThuongTru = maNhanKhauThuongTru;
            DiaChiThuongTru = diaChiThuongTru;
            QuanHeVoiChuHo = quanHeVoiChuHo;
            SoSoHoKhau = soSoHoKhau;
        }

        public NhanKhauThuongTruDTO(DataRow dt):base(dt["madinhdanh"].ToString(),dt["hoten"].ToString(), dt["tenkhac"].ToString(), DateTime.Parse(dt["ngaysinh"].ToString()),
            dt["gioitinh"].ToString(), dt["noisinh"].ToString(), dt["nguyenquan"].ToString(), dt["dantoc"].ToString(), dt["tongiao"].ToString(), dt["quoctich"].ToString(),
            dt["hochieu"].ToString(), dt["noithuongtru"].ToString(), dt["diachihiennay"].ToString(), dt["sdt"].ToString(), dt["trinhdohocvan"].ToString(),
            dt["trinhdochuyenmon"].ToString(), dt["biettiengdantoc"].ToString(), dt["trinhdongoaingu"].ToString(), dt["nghenghiep"].ToString())
        {
            if (dt.ItemArray.Length == 0)
                return;
            MaNhanKhauThuongTru = dt["manhankhauthuongtru"].ToString();
            DiaChiThuongTru = dt["diachithuongtru"].ToString();
            QuanHeVoiChuHo = dt["quanhevoichuho"].ToString();
            SoSoHoKhau = dt["sosohokhau"].ToString();
        }
    }
}
