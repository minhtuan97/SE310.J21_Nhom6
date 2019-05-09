using System;
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
        NhanKhauTamTruDAO nktt = new NhanKhauTamTruDAO();
        public override List<SoTamTruDTO> GetAll()
        {
            return SoTamTru.getAll();
        }

        public List<SoTamTruDTO> GetAllSoTamTru()
        {
            return SoTamTru.getAllSoTamTru();
        }


        public override bool Update(SoTamTruDTO data)
        {
            return SoTamTru.update(data);
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
        public bool deleteSTT(string id)
        {
            return SoTamTru.deleteSTT(id);
        }
        public List<SoTamTruDTO> TimKiem(string query)
        {
            List<SoTamTruDTO> list = SoTamTru.TimKiem(query);
            if (list.Count > 0)
            {
                foreach (SoTamTruDTO item in list)
                {
                    item.NhanKhau = nktt.TimKiem("SOSOTAMTRU='" + item.db.SOSOTAMTRU + "'");
                }
            }

            return list;
        }

        public List<SoTamTruDTO> TimKiemSoTamTru(string sosotamtru)
        {
            return SoTamTru.TimKiemSoTamTru(sosotamtru);
        }

        

        public bool DeleteExperiedSoTamTru()
        {
           return SoTamTru.DeleteExperiedSoTamTru();  
        }


       

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

        public DateTime getTuNgay(string manhankhautamtru)
        {
            return SoTamTru.getTuNgay(manhankhautamtru);
        }

        public DateTime getDenNgay(string manhankhautamtru)
        {
            return SoTamTru.getDenNgay(manhankhautamtru);
        }

        public String getNoiTamTru(string manhankhautamtru)
        {
            return SoTamTru.getNoiTamTru(manhankhautamtru);
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

    }
}
