using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ViDu
{
    public class TruyVanSQL
    {
        public static void quanHeNKvaTATS()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from tienantiensu in qlhk.TIENANTIENSUs
                     select tienantiensu;

            TIENANTIENSU ta = kq.First();
            NHANKHAU nk = ta.NHANKHAU;
        }

        public static void suDungStoredProcedure()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Sử dụng truy vấn LINQ
            IEnumerable<NHANKHAU> kq = from n in qlhk.NHANKHAUs
                                       where n.MADINHDANH == "251004985585"
                                       select n;

            //Gọi SPROC
            var nk = qlhk.GetNHANKHAUByMADINHDANH("251004985585");
        }

        public static void suDungStoredProcedureThemXoaSuaDL()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            NHANKHAU n = qlhk.NHANKHAUs.Single(q => q.MADINHDANH == "251004985585");

            n.NGUYENQUAN = "Lâm Đồng";
            n.NGHENGHIEP = "Sinh viên";

            qlhk.SubmitChanges();
        }

        public static void layCacNhanKhau()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from nk in qlhk.NHANKHAUs
                     select nk;

            foreach(NHANKHAU i in kq)
            {
                Console.WriteLine(i.MADINHDANH.ToString());
            }
        }

        public static void truyVanWhere()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from ta in qlhk.TIENANTIENSUs
                     where ta.TOIDANH=="Trộm cắp"
                     select ta;
        }

        public static void truyVanWhere2()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.TIENANTIENSUs.Count > 5 
                     select nk;
        }

        public static void truyVanTenNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.HOTEN== "Lê Thùy Trang"
                     select nk;
        }

        public static void truyVanNHANKHAUTAMTRUkoTATS()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.NHANKHAUTAMTRUs.First().NOITAMTRU.Contains("Đông Hòa") && nk.TIENANTIENSUs.Count==0
                     select nk;
        }

        public static void capNhatNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            NHANKHAU kq = qlhk.NHANKHAUs.Single(q => q.HOTEN == "Lê Thùy Trang");

            kq.NGHENGHIEP = "Bác sĩ";
            kq.SDT = "0398678991";

            qlhk.SubmitChanges();
        }

        public static void truyVanXoaTenKhacNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.NHANKHAUTHUONGTRUs.Count>0
                     select nk;

            foreach (NHANKHAU nk in kq)
            {
                nk.TENKHAC = "";
            }

            qlhk.SubmitChanges();
        }

        public static void themNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            NHANKHAU nk = new NHANKHAU();

            nk.MADINHDANH = "251004985585";
            nk.HOTEN = "Nguyễn Bảo Duy";
            nk.TENKHAC = "";
            nk.NGAYSINH = new DateTime(1997, 2, 8);
            nk.NOISINH = "Lâm Đồng";
            nk.NGUYENQUAN = "Thừa Thiên - Huế";
            nk.DANTOC = "Kinh";
            nk.NGHENGHIEP = "Sinh Viên";
            nk.SDT = "0374442766";

            qlhk.NHANKHAUs.InsertOnSubmit(nk);

            qlhk.SubmitChanges();
        }

        public static void xoaNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            NHANKHAU kq = qlhk.NHANKHAUs.Single(q => q.HOTEN == "Lê Thùy Trang");

            qlhk.NHANKHAUs.DeleteOnSubmit(kq);

            qlhk.SubmitChanges();
        }

        public static void themTATS()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Lấy thông tin nhân khẩu
            NHANKHAU kq = qlhk.NHANKHAUs.Single(q => q.HOTEN == "Lê Thùy Trang");

            //Tạo một tiền án tiền sự 
            TIENANTIENSU ta = new TIENANTIENSU();
            ta.TOIDANH = "Vi phạm luật an toàn giao thông";
            ta.HINHPHAT = "Phạt hành chính 500000VND";
            ta.BANAN = "";
            ta.NGAYPHAT = DateTime.Now;

            //Gán tiền án tiền sự vào nhân khẩu
            kq.TIENANTIENSUs.Add(ta);

            //Cập nhật vào database
            qlhk.SubmitChanges();
        }

        public static void themNhieuvaoNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Lấy thông tin nhân khẩu
            NHANKHAU kq = qlhk.NHANKHAUs.Single(q => q.MADINHDANH == "083456789019");

            //Tạo một NHANKHAUTHUONGTRU
            NHANKHAUTHUONGTRU tt = new NHANKHAUTHUONGTRU();
            tt.DIACHITHUONGTRU = "Tân Lập, Đông Hòa, Dĩ An, Bình Dương";
            tt.QUANHEVOICHUHO = "Chủ hộ";
            //Gán NHANKHAUTHUONGTRU vào NHANKHAU
            kq.NHANKHAUTHUONGTRUs.Add(tt);

            //lấy thông tin một sổ hộ khẩu
            SOHOKHAU so = qlhk.SOHOKHAUs.Single(q => q.SOSOHOKHAU == "SH0000001");
            //Thêm NHANKHAUTHUONGTRU vào SOHOKHAU
            so.NHANKHAUTHUONGTRUs.Add(tt);

            //tạo 2 TIEUSU
            TIEUSU ts1 = new TIEUSU();
            ts1.THOIGIANBATDAU = new DateTime(1999, 1, 1);
            ts1.THOIGIANKETTHUC = new DateTime(2012, 8, 1);
            ts1.CHOO = "Tân Lập, Đông Hòa, Dĩ An, Bình Dương";
            ts1.NGHENGHIEP = "Học sinh";
            ts1.NOILAMVIEC = "Bình Dương";
            TIEUSU ts2 = new TIEUSU();
            ts2.THOIGIANBATDAU = new DateTime(2012, 9, 5);
            ts2.THOIGIANKETTHUC = new DateTime(2017, 8, 1);
            ts2.CHOO = "Tân Lập, Đông Hòa, Dĩ An, Bình Dương";
            ts2.NGHENGHIEP = "Sinh viên";
            ts2.NOILAMVIEC = "Bình Dương";
            //Thêm TIEUSU vào NHANKHAU
            kq.TIEUSUs.Add(ts1); kq.TIEUSUs.Add(ts2);

            //Tạo một CANBO
            CANBO cb = new CANBO();
            cb.LOAICANBO = "0";
            cb.TENTAIKHOAN = "cbbongda1";
            cb.MATKHAU = "123";

            //Gán CANBO vào NHANKHAUTHUONGTRU
            tt.CANBOs.Add(cb);

            //Cập nhật vào database
            qlhk.SubmitChanges();
        }

        public static void capNhatSDT1()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Lấy thông tin nhân khẩu
            NHANKHAU nk = qlhk.NHANKHAUs.Single(q => q.MADINHDANH == "083456789019");

            nk.SDT = "0398711863";

            qlhk.SubmitChanges();
        }

        public static void capNhatSDT2()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Lấy thông tin nhân khẩu
            NHANKHAU nk = qlhk.NHANKHAUs.Single(q => q.MADINHDANH == "083456789019");

            nk.SDT = "asdfqwerty";

            qlhk.SubmitChanges();
        }

        public static void themTIEUSU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();

            //Lấy thông tin nhân khẩu
            NHANKHAU nk = qlhk.NHANKHAUs.Single(q => q.MADINHDANH == "083456789019");

            //Tạo một tiểu sử
            TIEUSU ts = new TIEUSU();
            ts.THOIGIANBATDAU = new DateTime(2019, 1, 1);
            ts.THOIGIANKETTHUC = new DateTime(2018, 1, 1);
            ts.CHOO = "Tân Lập, Đông Hòa, Dĩ An, Bình Dương";
            ts.NGHENGHIEP = "VĐV Bóng đá";
            ts.NOILAMVIEC = "Bình Dương";

            nk.TIEUSUs.Add(ts);
            qlhk.SubmitChanges();
        }

        public static void SPROCgetAllNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();
            NHANKHAU nk = qlhk.GetNHANKHAUByMADINHDANH("083456789019").First();
        } 
    }
}
