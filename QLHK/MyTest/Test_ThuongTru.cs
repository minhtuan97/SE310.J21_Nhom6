using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DTO;

namespace MyTest
{
    [TestFixture]
    class Test_ThuongTru
    {
        private SoHoKhauBUS SoHoKhau_BUS;
        private NhanKhauThuongTruBUS NhanKhauThuongTru_BUS;

        private static DateTime Today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static DateTime DiffDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 12);


        //Giá trị cho Thêm sổ hộ khẩu
        static object[] Array_SoHoKhau_Insert =
        {
            new SoHoKhauDTO("080000001","TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương", Today, "2130459"),
            new SoHoKhauDTO("080000002","TH0000002","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, "2130459"),
        };


        //Giá trị cho Sửa sổ hộ khẩu
        static object[] Array_SoHoKhau_Update=
        {
            new SoHoKhauDTO("080000001","TH0000003","Tân Lập, Đông Hòa, Dĩ An, Bình Dương", Today, "2130459"),
            new SoHoKhauDTO("080000002","TH0000004","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, "2130459"),
            new SoHoKhauDTO("080000005","TH0000004","Khu Phố 6, Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", Today, "2130459"),
        };


        //Giá trị cho Xóa sổ hộ khẩu
        static String[] Array_SoHoKhau_Delete =
        {
          "080000001", "080000002"
        };


        //THiết lập các giá trị ban đầu
        [SetUp]
        public void Init()
        {
            SoHoKhau_BUS = new SoHoKhauBUS();
            NhanKhauThuongTru_BUS = new NhanKhauThuongTruBUS();
        }


        //Test hàm thêm sổ hộ khẩu
        [Test, Order(1), TestCaseSource("Array_SoHoKhau_Insert")]
        public void ThemSoHoKhau(SoHoKhauDTO SoHoKhau)
        {
            Assert.AreEqual(true, SoHoKhau_BUS.Add(SoHoKhau));
        }

        //Test hàm sửa sổ hộ khẩu
        [Test, Order(2), TestCaseSource("Array_SoHoKhau_Update")]
        public void SuaSoHoKhau(SoHoKhauDTO SoHoKhau)
        {
            Assert.AreEqual(true, SoHoKhau_BUS.Update(SoHoKhau, 0));
        }


        //Test hàm xóa sổ hộ khẩu
        [Test, Order(3), TestCaseSource("Array_SoHoKhau_Delete")]
        public void XoaSoHoKhau(string SoSoHoKhau)
        {
            Assert.AreEqual(true, SoHoKhau_BUS.XoaSoHK(SoSoHoKhau));
        }

        //
        //NHÂN KHẨU THƯỜNG TRÚ
        //
        //Giá trị sai cho kiểm tra, thêm nhân khẩu thường trú
        static object[] Array_NhanKhauThuongTru_InValid =
        {
            new NhanKhauThuongTruDTO("","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "Chủ hộ", "080000010", "078251000085585",
                "", "", Today, "nam", "Bình Dương", "Bình Dương", "Kinh", "không", "VN", "không", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "0355301156", "12/12", "không", "", "", "sinh viên"),
            //new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
            //    "Nguyễn Bảo Quốc","", default(DateTime),"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
            //    "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"), ///không tìm ra mẫu null DateTime
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "","0355301156","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","","12/12","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","","không","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","","","","sinh viên"),
            new NhanKhauThuongTruDTO("TH0000001","Tân Lập, Đông Hòa, Dĩ An, Bình Dương","Chủ hộ","080000010","078251000085585",
                "Nguyễn Bảo Quốc","", Today,"nam","Bình Dương","Bình Dương","Kinh","không","VN","không","Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0355301156","12/12","không","","",""),
            new NhanKhauThuongTruDTO()
        };
        //Test hàm kiểm tra thông tin nhân khẩu thường trú
        [Test, Order(4), TestCaseSource("Array_NhanKhauThuongTru_InValid")]
        public void isValidNhanKhauTT(NhanKhauThuongTruDTO nktt)
        {

            Assert.AreEqual(false, NhanKhauThuongTru_BUS.isValidNhanKhauTT(nktt));
        }

        //Test hàm thêm nhân khẩu thường trú
        [Test, Order(5)]
        public void c1ThemNhanKhauThuongTru()
        {
            NhanKhauThuongTruDTO nktt = new NhanKhauThuongTruDTO("TH0000001", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "Chủ hộ", "080000010", "078251000085585",
                "Nguyễn Bảo Quốc", "", Today, "nam", "Bình Dương", "Bình Dương", "Kinh", "không", "VN", "không", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "0355301156", "12/12", "không", "", "", "sinh viên");
            Assert.AreEqual(true, NhanKhauThuongTru_BUS.Add(nktt));
        }
        //Test hàm thêm nhân khẩu thường trú
        [Test, Order(6), TestCaseSource("Array_NhanKhauThuongTru_InValid")]
        public void c2_c20ThemNhanKhauThuongTru(NhanKhauThuongTruDTO nktt)
        {
            Assert.AreEqual(false, NhanKhauThuongTru_BUS.Add(nktt));
        }
        //Test hàm thêm nhân khẩu thường trú
        [Test, Order(7)]
        public void c21ThemNhanKhauThuongTru()
        {
            NhanKhauThuongTruDTO nktt = new NhanKhauThuongTruDTO("TH0000001", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "Chủ hộ", "080000010", "078251000085585",
                "Nguyễn Bảo Quốc", "", Today, "nam", "Bình Dương", "Bình Dương", "Kinh", "không", "VN", "không", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "0355301156", "12/12", "không", "", "", "sinh viên");
            Assert.AreEqual(false, NhanKhauThuongTru_BUS.Add(nktt));
        }














    }
}
