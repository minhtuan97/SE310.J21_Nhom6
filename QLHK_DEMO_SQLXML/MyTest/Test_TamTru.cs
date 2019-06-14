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
    class Test_TamTru
    {
        private NhanKhauTamTruBUS nhankhautamtruBus;
        private static DateTime tungay = new DateTime(2018, 1, 1);
        private static DateTime denngay = new DateTime(2018, 12 ,1);
        private static DateTime ngaysinh = new DateTime(1997, 1, 1);
        private static DateTime Denngay = new DateTime(2021, 1, 1);

        //THiết lập các giá trị ban đầu
        [SetUp]
        public void Init()
        {
            nhankhautamtruBus = new NhanKhauTamTruBUS();
        }


        //Test 
        [Test, Order(1)]
        public void TestCase1()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(true, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(2)]
        public void TestCase2()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }

        [Test, Order(3)]
        public void TestCase3()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(4)]
        public void TestCase4()
        {
            NhanKhauTamTruDTO nhankhau= new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(5)]
        public void TestCase5()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(6)]
        public void TestCase6()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(7)]
        public void TestCase7()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(8)]
        public void TestCase8()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000001", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }


        [Test, Order(9)]
        public void TestCase9()
        {
            NhanKhauTamTruDTO nhankhau = new NhanKhauTamTruDTO("TT0000002", "Đông Hòa, Dĩ An, Bình Dương", tungay, denngay, "Đi làm", "ST0000001", "123456789016", "Đặng Minh Tiến", "Tiến ABC", ngaysinh, "nam", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Kinh", "Không", "Việt Nam", "B4815163", "Phường Linh Trung, Quận Thủ Đức, TP Hồ Chí Minh", "Đông Hòa, Dĩ An, Bình Dương", "0123456784", "10/10", "Vẽ", "Thái", "A", "Kỹ sư");
            Assert.AreEqual(false, nhankhautamtruBus.AddNKTT(nhankhau));
        }












    }
}
