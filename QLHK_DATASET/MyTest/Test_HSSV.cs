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
    class Test_HSSV
    {

        private HocSinhSinhVienBUS hocsinhsinhvienBus;

        [SetUp]
        public void Init()
        {
            hocsinhsinhvienBus = new HocSinhSinhVienBUS();
        }


        [Test, Order(1)]
        public void TestCase1()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime(2019, 12, 12);

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000100", "123486789013", "Đại học Công Nghệ Thông Tin",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(true, hocsinhsinhvienBus.Add(hssv));
        }

        [Test, Order(1)]
        public void TestCase2()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime();

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000101", "123486789010", "Đại học Công Nghệ Thông Tin",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(true, hocsinhsinhvienBus.Add(hssv));
        }

        [Test, Order(1)]
        public void TestCase3()
        {
            DateTime ngaybd = new DateTime();
            DateTime ngaykt = new DateTime(2019, 2, 2);

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000102", "123486789010", "Đại học Công Nghệ Thông Tin",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(true, hocsinhsinhvienBus.Add(hssv));
        }
        [Test, Order(1)]
        public void TestCase4()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime(2019, 12, 12);
            string diachi = null;

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000103", "123486789013", "Đại học Công Nghệ Thông Tin",
               diachi, ngaybd, ngaykt, "");
            Assert.AreEqual(false, hocsinhsinhvienBus.Add(hssv));
        }

        [Test, Order(1)]
        public void TestCase5()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime(2019, 12, 12);
            string truong = null;

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000104", "123486789010", truong,
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(false, hocsinhsinhvienBus.Add(hssv));
        }

        [Test, Order(1)]
        public void TestCase6()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime();
            string madinhdanh = null;

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO("HS0000105", madinhdanh, "Đại học Công Nghệ Thông Tin",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(false, hocsinhsinhvienBus.Add(hssv));
        }
        [Test, Order(1)]
        public void TestCase7()
        {
            DateTime ngaybd = new DateTime(2019, 1, 1);
            DateTime ngaykt = new DateTime(2019, 12, 12);
            string mahssv = null;

            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO(mahssv, "123486789013", "Đại học Công Nghệ Thông Tin",
                "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", ngaybd, ngaykt, "");
            Assert.AreEqual(false, hocsinhsinhvienBus.Add(hssv));
        }

    }
}
