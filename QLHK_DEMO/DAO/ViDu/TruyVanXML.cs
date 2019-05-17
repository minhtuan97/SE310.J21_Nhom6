using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO.ViDu
{

    public class TieuSuXML
    {
        public string MATIEUSU { get; set; }
        public string MADINHDANH { get; set; }
        public DateTime THOIGIANBATDAU { get; set; }
        public DateTime THOIGIANKETTHUC { get; set; }
        public string CHOO { get; set; }
        public string NGHENGHIEP { get; set; }
        public string NOILAMVIEC { get; set; }
    }

    public class TruyVanXML
    {
        public static string layNHANKHAU()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            var data = from c in qlhk.Descendants("nhankhau")
                       select new
                       {
                           madinhdanh = c.Attribute("MADINHDANH").Value,
                           hoten = c.Element("HOTEN").Value
                       };

            return data.ToList().First().hoten.ToString();
        }

        public static List<TieuSuXML> layTIEUSU()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            var data = from c in qlhk.Descendants("tieusu")
                       select new TieuSuXML
                       {
                           MATIEUSU = c.Attribute("MATIEUSU").Value,
                           MADINHDANH = c.Element("MADINHDANH").Value,
                           THOIGIANBATDAU = DateTime.ParseExact(c.Element("THOIGIANBATDAU").Value, "yyyy-MM-dd", null),
                           THOIGIANKETTHUC = DateTime.ParseExact(c.Element("THOIGIANKETTHUC").Value, "yyyy-MM-dd", null),
                           CHOO = c.Element("CHOO").Value,
                           NGHENGHIEP = c.Element("NGHENGHIEP").Value,
                           NOILAMVIEC = c.Element("NOILAMVIEC").Value
                       };

            return data.ToList();
        }

        public static void layTIEUSUTructiep()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            var data = from c in qlhk.Descendants("tieusu")
                       select c;
        }

        public static void capNhatNHANKHAU()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Lấy một nhân khẩu từ CSDL
            var data = qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "083456789019");

            //Cập nhật tên khác và SDT của nhân khẩu đó
            data.Element("TENKHAC").SetValue("Huy");
            data.Element("SDT").SetValue("0974719147");

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }

        public static void capNhatNHANKHAUElementAttribute()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Lấy một nhân khẩu từ CSDL
            var data = qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "083456789019");

            //Đổi tên Attribute MADINHDANH thành MA
            var listAtt = data.Attributes().ToList();
            var oldAtt = listAtt.Single(q => q.Name == "MADINHDANH");
            XAttribute newAtt = new XAttribute("MA", oldAtt.Value);
            listAtt.Add(newAtt); listAtt.Remove(oldAtt);

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }

        public static void themNHANKHAU()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Tạo một Element nhankhau
            XElement nk = new XElement("nhankhau", new XAttribute("MADINHDANH", "074097000011"),
                            new XElement("HOTEN", "Trần Văn An"),
                            new XElement("TENKHAC", ""),
                            new XElement("NGAYSINH", "1997-10-15"),
                            new XElement("GIOITINH", "nam"),
                            new XElement("NOISINH", "21 Khu Phố Tây A, Phường Dĩ An, Thị xã Dĩ An, Tỉnh Bình Dương"),
                            new XElement("NGUYENQUAN", "21 Khu Phố Tây A, Phường Dĩ An, Thị xã Dĩ An, Tỉnh Bình Dương"),
                            new XElement("DANTOC", "Kinh"),
                            new XElement("TONGIAO", "Không"),
                            new XElement("QUOCTICH", "Việt Nam"),
                            new XElement("HOCHIEU", ""),
                            new XElement("NOITHUONGTRU", "21 Khu Phố Tây A, Phường Dĩ An, Thị xã Dĩ An, Tỉnh Bình Dương"),
                            new XElement("DIACHIHIENNAY", "21 Khu Phố Tây A, Phường Dĩ An, Thị xã Dĩ An, Tỉnh Bình Dương"),
                            new XElement("SDT", "0946283526"),
                            new XElement("TRINHDOHOCVAN", "12/12"),
                            new XElement("TRINHDOCHUYENMON", "Không"),
                            new XElement("BIETTIENGDANTOC", "Không"),
                            new XElement("TRINHDONGOAINGU", " Tiếng Anh B"),
                            new XElement("NGHENGHIEP", "Bác sĩ"));

            //Thêm nhankhau này vào danh sách
            //Cách 1: Lấy danh sách tất cả nhân khẩu từ CSDL và thêm nhankhau vào danh sách
            var data = qlhk.Descendants("NHANKHAUs").ToList();
            data.Add(nk);

            //Cách 2: thêm trực tiếp nhân khẩu này bằng XDocument.Element
            qlhk.Element("NHANKHAUs").Add(nk);

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }

        public static void xoaNHANKHAU()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Xóa nhankhau ra khỏi danh sách
            //Cách 1: Lấy danh sách tất cả nhân khẩu từ CSDL rồi tìm và xóa nhankhau
            var data = qlhk.Descendants("NHANKHAUs").ToList();
            foreach(var nk in data)
            {
                if (nk.Attribute("MADINHDANH").Value == "074097000011")
                {
                    data.Remove(nk);
                    break;
                }
            }

            //Cách 2: Truy vấn và xóa trực tiếp nhân khẩu này sử dụng XElement.Remove
            qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "074097000011").Remove();

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }
    }
}
