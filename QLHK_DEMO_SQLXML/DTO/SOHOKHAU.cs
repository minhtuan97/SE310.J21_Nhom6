﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace DTO
{
    public partial class SOHOKHAU
    {
        public string TenChuHo;
        //public List<NHANKHAUTHUONGTRU> NhanKhau = new List<NHANKHAUTHUONGTRU>();

        public SOHOKHAU(string soSoHoKhau, string maChuHoThuongTru, string diaChi, 
            DateTime ngayCap, string soDangKy, EntitySet<NHANKHAUTHUONGTRU> nhanKhau) : this()
        {
            SOSOHOKHAU = soSoHoKhau;
            MACHUHO = maChuHoThuongTru;
            DIACHI = diaChi;
            NGAYCAP = ngayCap;
            SODANGKY = soDangKy;
            NHANKHAUTHUONGTRUs = nhanKhau;
        }
        public SOHOKHAU(string soSoHoKhau, string maChuHoThuongTru, string diaChi,
            DateTime ngayCap, string soDangKy) : this()
        {
            SOSOHOKHAU = soSoHoKhau;
            MACHUHO = maChuHoThuongTru;
            DIACHI = diaChi;
            NGAYCAP = ngayCap;
            SODANGKY = soDangKy;
            //NhanKhau = new List<NHANKHAUTHUONGTRU>();
        }

        //public SoHoKhauDTO(SOHOKHAU shk, String tenchuho)
        //{
        //    db = shk;
        //    TenChuHo = tenchuho;
        //}

    }
}