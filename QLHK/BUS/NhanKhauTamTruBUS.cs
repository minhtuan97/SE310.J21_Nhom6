﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class NhanKhauTamTruBUS: AbstractFormBUS<NhanKhauTamTruDTO>
    {
        NhanKhauTamTruDAO objnktt = new NhanKhauTamTruDAO();
        public override DataSet GetAll()
        {
            return objnktt.getAll();
        }
        public DataSet GetAllNhanKhauTamTru(string sosotamtru)
        {
            return objnktt.getAllNhanKhauTT(sosotamtru);
        }
        public override bool Add(NhanKhauTamTruDTO nhankhautamtru)
        {
            return objnktt.insert(nhankhautamtru);
        }

        public bool AddNKTT(NhanKhauTamTruDTO nhankhautamtru)
        {
            if(nhankhautamtru.MaNhanKhauTamTru=="" || nhankhautamtru.MaDinhDanh=="" || nhankhautamtru.HoTen =="" || nhankhautamtru.DanToc =="" 
                || nhankhautamtru.NgheNghiep == "" || nhankhautamtru.QuocTich == "")
            {
                return false;
            }
            SoTamTruBUS stt = new SoTamTruBUS();

            if (stt.Existed_NhanKhau(nhankhautamtru.MaDinhDanh))
            {
                return false;
            }

            double ngay = (nhankhautamtru.DenNgay - nhankhautamtru.TuNgay).TotalDays;
            double sum = 730;
            if (ngay > sum)
            {
                return false;
            }

            return Add(nhankhautamtru);
        }

        public bool XoaNKTT(string madinhdanh)
        {
            return objnktt.XoaNKTT(madinhdanh);
        }
        public override bool Delete(int r)
        {
            return objnktt.delete(r);
        }
        public override bool Update(NhanKhauTamTruDTO nhankhautamtru, int r)
        {
            return objnktt.updateNhanKhauTamTru(nhankhautamtru, r);
        }

        public DataSet TimKiem(string madinhdanh)
        {
            return objnktt.TimKiem(madinhdanh);
        }
        public override bool Add_Table(NhanKhauTamTruDTO data)
        {
            return objnktt.insert_table(data);
        }


        //Load Data For Combobox
        //Lấy mã tỉnh thành phố
        //public BindingSource Get_TinhThanhPho()
        //{

        //    List<string> TinhThanh_List = new List<string>();
        //    TinhThanh_List = objnktt.GetListTinhThanh();

        //    BindingSource bindingSource = new BindingSource();
        //    bindingSource.DataSource = TinhThanh_List;
        //    return bindingSource;
        //}


        //public BindingSource GetListQuanHuyen(string tentinhthanhpho)
        //{
        //    List<string> QuanHuyen_List = new List<string>();
        //    QuanHuyen_List = objnktt.GetListQuanHuyen(tentinhthanhpho);

        //    BindingSource bindingSource = new BindingSource();
        //    bindingSource.DataSource = QuanHuyen_List;
        //    return bindingSource;
        //}

        //public BindingSource GetListXaPhuong(string tenquanhuyen)
        //{
        //    List<string> XaPhuong_List = new List<string>();
        //    XaPhuong_List = objnktt.GetListXaPhuong(tenquanhuyen);

        //    BindingSource bindingSource = new BindingSource();
        //    bindingSource.DataSource = XaPhuong_List;
        //    return bindingSource;
        //}


        //public string[] SplitDiaChi(string diachi)
        //{
        //    string data = diachi;
        //    string[] result = data.Split(',');
        //    return result;
        //}




        //
        //XỬ LÍ VỚI TIỀN ÁN TIỀN SỰ
        //
        public DataSet GetTienAnTienSu(string madinhdanh)
        {
            return objnktt.getTienAnTienSu(madinhdanh);
        }

        public bool DeleteTienAnTienSu(string matienan)
        {
            return objnktt.DeleteTienAn(matienan);
        }


        //
        //XỬ LÍ VỚI TIỂU SỬ
        //
        public DataSet GetTieuSu(string madinhdanh)
        {
            return objnktt.getTieuSu(madinhdanh);
        }


        public bool DeleteTieuSu(string matieusu)
        {
            return objnktt.DeleteTieuSu(matieusu);
        }


        //Tính toán số ngày giửa hai thời điểm
        public double TimeBetweenTwoDays(DateTime start, DateTime End)
        {
            return (End - start).TotalDays;
        }

        //Đăng ký tạm trú có thời hạn tối đa không quá 2 năm 
        public bool CheckThoiGianDangKyTamTru(DateTime tungay, DateTime denngay)
        {
            double songay = TimeBetweenTwoDays(tungay, denngay);
            if (songay > 729) { return false; }
            return true;
        }

        public bool InsertGiaHan(string sosotamtru, DateTime thoigian)
        {
            return objnktt.InsertGiaHan(sosotamtru, thoigian);
        }


        public DateTime TimNgayDangKyTamTru(string madinhdanh)
        {
            return objnktt.NgayDangKyTamTru(madinhdanh);
        }

        public DateTime ThoiHanSoTamTru(string madinhdanh)
        {
            return objnktt.ThoiHanSoTamTru(madinhdanh);
        }

        //Kiểm tra hợp lệ để gia hạn cho sổ tạm trú
        public double CheckGiaHan(DateTime thoihangiahan, string madinhdanh)
        {
            //Kiểm tra thời gian tối đa có thể gia hạn
            DateTime today = DateTime.Today;
            DateTime thoigianbatdau = TimNgayDangKyTamTru(madinhdanh);

            //Tính số ngày đã tạm trú
            double thoigiandatamtru = (today - thoigianbatdau).TotalDays;

            double thoigiantong = 730;

            //Tính số ngày còn lại có thể gia hạn 
            double songaycothegiahan = thoigiantong - thoigiandatamtru;

            //Thời gian gia hạn thêm
            double thoigianthem = TimeBetweenTwoDays(today, thoihangiahan);

            //Kiểm tra
            if (thoigianthem > songaycothegiahan)
            {
                return songaycothegiahan;
            }

            return 0;
        }

    }
}
