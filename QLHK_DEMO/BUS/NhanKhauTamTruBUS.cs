using System;
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
    public class NhanKhauTamTruBUS: AbstractFormBUS<NHANKHAUTAMTRU>
    {
        NhanKhauTamTruDAO objnktt = new NhanKhauTamTruDAO();
        public override List<NHANKHAUTAMTRU> GetAll()
        {
            return objnktt.getAll();
        }
        public List<NHANKHAUTAMTRU> GetAllNhanKhauTamTru(string sosotamtru)
        {
            return objnktt.getAllNhanKhauTT(sosotamtru);
        }
        public override bool Add(NHANKHAUTAMTRU nhankhautamtru)
        {
            return objnktt.insert(nhankhautamtru);
        }

        public bool AddNKTT(NHANKHAUTAMTRU nhankhautamtru)
        {
            if(nhankhautamtru.MANHANKHAUTAMTRU=="" || nhankhautamtru.NHANKHAU.MADINHDANH == "" 
                // || nhankhautamtru.db.HOTEN == "" || nhankhautamtru.DanToc =="" || nhankhautamtru.NgheNghiep == "" || nhankhautamtru.QuocTich == ""
              )
            {
                return false;
            }
            SoTamTruBUS stt = new SoTamTruBUS();

            if (stt.Existed_NhanKhau(nhankhautamtru.NHANKHAU.MADINHDANH))
            {
                return false;
            }

            double ngay = (nhankhautamtru.DENNGAY - nhankhautamtru.TUNGAY).TotalDays;
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
        public bool DeleteNKTT(string id)
        {
            return objnktt.deletenktt(id);
        }
        public override bool Delete(int r)
        {
            return objnktt.delete(r);
        }
        public bool UpdateNKTT(NHANKHAUTAMTRU nktt)
        {
            return objnktt.updatenktt(nktt);
        }
        public override bool Update(NHANKHAUTAMTRU nhankhautamtru)
        {
            return objnktt.updateNhanKhauTamTru(nhankhautamtru);
        }

        public List<NHANKHAUTAMTRU> TimKiem(string query)
        {
            return objnktt.TimKiem(query);
        }

        public List<NHANKHAUTAMTRU> TimKiemNKTT(string madinhdanh)
        {
            return objnktt.TimKiemNKTT(madinhdanh);
        }

        public override bool Add_Table(NHANKHAUTAMTRU data)
        {
            return objnktt.insert_table(data);
        }





        //
        //XỬ LÍ VỚI TIỀN ÁN TIỀN SỰ
        //
        public List<TIENANTIENSU> GetTienAnTienSu(string madinhdanh)
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
        public List<TIEUSU> GetTieuSu(string madinhdanh)
        {
            return objnktt.getTieuSu(madinhdanh);
        }


        public bool DeleteTieuSu(string matieusu)
        {
            return objnktt.DeleteTieuSu(matieusu);
        }


        public DateTime GetTuNgay(String madinhdanh)
        {
            return objnktt.NgayDangKyTamTru(madinhdanh);
        }

        public DateTime GetDenNgay(String madinhdanh)
        {
            return objnktt.ThoiHanSoTamTru(madinhdanh);
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
