﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace BUS
{
    public class SoTamTruBUS:AbstractFormBUS<SoTamTruDTO>
    {
        SoTamTruDAO SoTamTru = new SoTamTruDAO();
        public override DataSet GetAll()
        {
            return SoTamTru.getAll();
        }

        public DataSet GetAllSoTamTru()
        {
            return SoTamTru.getAllSoTamTru();
        }

        public override bool Add(SoTamTruDTO sotamtru)
        {
            return SoTamTru.insert(sotamtru);
        }
        public override bool Add_Table(SoTamTruDTO data)
        {
            return SoTamTru.insert_table(data);
        }
        public bool XoaSoTamTru(string manhankhautamtru)
        {
            return SoTamTru.XoaSoTamTru(manhankhautamtru);
        }
        public override bool Delete(int r)
        {
            return SoTamTru.delete(r);
        }
        public override bool Update(SoTamTruDTO sotamtru, int r)
        {
            return SoTamTru.update(sotamtru, r);
        }

        public DataSet TimKiem(string sosotamtru)
        {
            return SoTamTru.TimKiem(sosotamtru);
        }

        public bool DeleteExperiedSoTamTru()
        {
           return SoTamTru.DeleteExperiedSoTamTru();  
        }


        //Load Data For Combobox
        //Lấy mã tỉnh thành phố

        //public BindingSource Get_TinhThanhPho()
        //{

        //    List<string> TinhThanh_List = new List<string>();
        //    TinhThanh_List = SoTamTru.GetListTinhThanh();

        //    BindingSource bindingSource = new BindingSource();
        //    bindingSource.DataSource = TinhThanh_List;
        //    return bindingSource;
        //}


        //public BindingSource GetListQuanHuyen(string tentinhthanhpho)
        //{
        //    List<string> QuanHuyen_List = new List<string>();
        //    QuanHuyen_List = SoTamTru.GetListQuanHuyen(tentinhthanhpho);

        //    BindingSource bindingSource = new BindingSource();
        //    bindingSource.DataSource = QuanHuyen_List;
        //    return bindingSource;
        //}

        //public BindingSource GetListXaPhuong(string tenquanhuyen)
        //{
        //    List<string> XaPhuong_List = new List<string>();
        //    XaPhuong_List = SoTamTru.GetListXaPhuong(tenquanhuyen);

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

        public BindingSource ImportToComboboxMaChuHo(string sosotamtru)
        {
            List<string> list_tennhankhau = new List<string>();
            list_tennhankhau = SoTamTru.ImportToComboboxMaChuHo(sosotamtru);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = list_tennhankhau;
            return bindingSource;
        }

        public string convertTentoMaNhanKhauTamTru(string tennhankhau, string sosotamtru)
        {
            return SoTamTru.convertTentoMaNhanKhauTamTru(tennhankhau, sosotamtru);
        }

        public string FindTenChuHoTamTru(string sosotamtru)
        {
            return SoTamTru.FindTenChuHoTamTru(sosotamtru);
        }


        //XÁC ĐỊNH SỰ TỒN TẠI CỦA CÁC MÃ SỐ
        public bool ExistedSoTamTru(string sosotamtru)
        {
            int num = SoTamTru.Existed_SoTamTru(sosotamtru);
            if (num > 0) return true;
            else return false;
        }

        public bool Existed_NhanKhau(string madinhdanh)
        {
            int num = SoTamTru.Existed_NhanKhau(madinhdanh);
            if (num > 0) return true;
            else return false;
        }

        public bool Duplicated_NhanKhauTamTru(string manhankhautamtru, string sosotamtru)
        {
            int num = SoTamTru.Duplicated_NhanKhauTamTru(manhankhautamtru, sosotamtru);
            if (num > 0) return true;
            else return false;
        }

        public bool Existed_NhanKhauTamTru(string manhankhautamtru)
        {
            int num = SoTamTru.Existed_NhanKhauTamTru(manhankhautamtru);
            if (num > 0) return true;
            else return false;
        }

        public bool Existed_TieuSu(string matieusu)
        {
            int num = SoTamTru.Existed_TieuSu(matieusu);
            if (num > 0) return true;
            else return false;
        }


        public bool Existed_TienAn(string matienan)
        {
            int num = SoTamTru.Existed_TienAn(matienan);
            if (num > 0) return true;
            else return false;
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
            return SoTamTru.InsertGiaHan(sosotamtru, thoigian);
        }


        public DateTime TimNgayDangKyTamTru(string sosotamtru)
        {
            return SoTamTru.NgayDangKyTamTru(sosotamtru);
        }

        public DateTime ThoiHanSoTamTru(string sosotamtru)
        {
            return SoTamTru.ThoiHanSoTamTru(sosotamtru);
        }

        //Kiểm tra hợp lệ để gia hạn cho sổ tạm trú
        public double CheckGiaHan(DateTime thoihangiahan, string sosotamtru)
        {
            //Kiểm tra thời gian tối đa có thể gia hạn
            DateTime today = DateTime.Today;
            DateTime thoigianbatdau = TimNgayDangKyTamTru(sosotamtru);

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

        public string GetValue_Sub(string table, string value, string namecolumnWhere, string nameColumn)
        {
            return SoTamTru.GetValue_Sub(table, value, namecolumnWhere, nameColumn);
        }

    }
}
