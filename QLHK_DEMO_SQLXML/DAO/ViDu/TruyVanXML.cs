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

    public class NhanKhauXML
    {
        public string MADINHDANH { get; set; }
        public string TENKHAC { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public string NOISINH { get; set; }
        public string NGUYENQUAN { get; set; }
        public string DANTOC { get; set; }
        public string TONGIAO { get; set; }
        public string QUOCTICH { get; set; }
        public string HOCHIEU { get; set; }
        public string NOITHUONGTRU { get; set; }
        public string DIACHIHIENNAY { get; set; }
        public string SDT { get; set; }
        public string TRINHDOHOCVAN { get; set; }
        public string TRINHDOCHUYENMON { get; set; }
        public string BIETTIENGDANTOC { get; set; }
        public string TRINHDONGOAINGU { get; set; }
        public string NGHENGHIEP { get; set; }
    }

    public class TruyVanXML
    {
        public static List<NhanKhauXML> layNhanKhauLeThuyTrang()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            var data = from c in qlhk.Descendants("nhankhau")
                       where c.Element("HOTEN").Value == "Lê Thùy Trang"
                       select new NhanKhauXML
                       {
                           MADINHDANH = c.Attribute("MADINHDANH").Value,
                           TENKHAC = c.Element("TENKHAC").Value,
                           NGAYSINH = DateTime.ParseExact(c.Element("NGAYSINH").Value, "yyyy-MM-dd", null),
                           GIOITINH = c.Element("GIOITINH").Value,
                           NOISINH = c.Element("NOISINH").Value,
                           NGUYENQUAN = c.Element("NGUYENQUAN").Value,
                           DANTOC = c.Element("DANTOC").Value,
                           TONGIAO = c.Element("TONGIAO").Value,
                           QUOCTICH = c.Element("QUOCTICH").Value,
                           HOCHIEU = c.Element("HOCHIEU").Value,
                           NOITHUONGTRU = c.Element("NOITHUONGTRU").Value,
                           DIACHIHIENNAY = c.Element("DIACHIHIENNAY").Value,
                           SDT = c.Element("SDT").Value,
                           TRINHDOHOCVAN = c.Element("TRINHDOHOCVAN").Value,
                           TRINHDOCHUYENMON = c.Element("TRINHDOCHUYENMON").Value,
                           BIETTIENGDANTOC = c.Element("BIETTIENGDANTOC").Value,
                           TRINHDONGOAINGU = c.Element("TRINHDONGOAINGU").Value,
                           NGHENGHIEP = c.Element("NGHENGHIEP").Value
                       };

            return data.ToList();
        }

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
            XElement nk = new XElement("nhankhau", new XAttribute("MADINHDANH", "221400038544"),
                            new XElement("HOTEN", "Võ Sĩ Vai"),
                            new XElement("TENKHAC", ""),
                            new XElement("NGAYSINH", "1997-1-10"),
                            new XElement("GIOITINH", "nam"),
                            new XElement("NOISINH", "21 Khu Phố Tây A, Tuy An, Phú Yên"),
                            new XElement("NGUYENQUAN", "21 Khu Phố Tây A, Tuy An, Phú Yên"),
                            new XElement("DANTOC", "Kinh"),
                            new XElement("TONGIAO", "Không"),
                            new XElement("QUOCTICH", "Việt Nam"),
                            new XElement("HOCHIEU", ""),
                            new XElement("NOITHUONGTRU", "21 Khu Phố Tây A Tuy An, Phú Yên"),
                            new XElement("DIACHIHIENNAY", "1 Tô Vĩnh Diện, Phường Dĩ An, Thị xã Dĩ An, Tỉnh Bình Dương"),
                            new XElement("SDT", "0964639962"),
                            new XElement("TRINHDOHOCVAN", "12/12"),
                            new XElement("TRINHDOCHUYENMON", "Không"),
                            new XElement("BIETTIENGDANTOC", "Không"),
                            new XElement("TRINHDONGOAINGU", " Tiếng Anh B"),
                            new XElement("NGHENGHIEP", "Lập Trình Viên"));

            //Thêm nhankhau này vào danh sách
            //Cách 1: Lấy danh sách tất cả nhân khẩu từ CSDL và thêm nhankhau vào danh sách
            var data = qlhk.Root.Element("NHANKHAUs");
            data.Add(nk);

            //Cách 2: thêm trực tiếp nhân khẩu này bằng XDocument.Element
            qlhk.Root.Element("NHANKHAUs").Add(nk);

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
            var data = qlhk.Descendants("NHANKHAUs");
            foreach(var nk in data)
            {
                if (nk.Attribute("MADINHDANH").Value == "074097000011")
                {
                    nk.Remove();
                    break;
                }
            }

            //Cách 2: Truy vấn và xóa trực tiếp nhân khẩu này sử dụng XElement.Remove
            qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "074097000011").Remove();

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }

        public static void xoaNHANKHAU2()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Xóa nhankhau ra khỏi danh sách
            //Cách 1: Lấy danh sách tất cả nhân khẩu từ CSDL rồi tìm và xóa nhankhau
            var data = qlhk.Descendants("NHANKHAUs");
            foreach (var nk in data)
            {
                if (nk.Element("HOTEN").Value == "Lê Thùy Trang")
                {
                    nk.Remove();
                    break;
                }
            }

            //Cách 2: Truy vấn và xóa trực tiếp nhân khẩu này sử dụng XElement.Remove
            qlhk.Descendants("nhankhau").Single(q => q.Element("HOTEN").Value == "Lê Thùy Trang").Remove();

            //Lưu lại các thay đổi
            qlhk.Save(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");
        }

        public static void nodeLienKe()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Lấy thông tin node của nhân khẩu có MADINHDANH "074097000011"
            var curNode = qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "074097000011");

            //Lấy thông tin nhân khẩu liền sau
            var nextNode = curNode.NextNode;

            //Lấy thông tin nhân khẩu liền trước
            var prevNode = curNode.PreviousNode;

            //Lấy thông tin Node đầu và cuối phân cấp
            var firstNode = curNode.FirstNode;
            var lastNode = curNode.LastNode;

            //Lấy các Element, Attribute, Comment,... liền sau
            var nextNodes = curNode.NodesAfterSelf();

            //Lấy các Element, Attribute, Comment,... liền sau
            var prevNodes = curNode.NodesBeforeSelf();

            //Lấy các Element <nhankhau> liền sau
            var nextNhankhau = curNode.ElementsAfterSelf("nhankhau");

            //Lấy các Element <nhankhau> liền trước
            var prevNhankhau = curNode.ElementsBeforeSelf("nhankhau");

        }

        public static void nodeTienThan()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Lấy thông tin node của nhân khẩu có MADINHDANH "074097000011"
            var curNode = qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "074097000011");

            //Lấy thông tin Document
            XDocument doc = curNode.Document; // trong trường hợp này, doc == qlhk

            //Lấy thông tin Node cha của node hiện tại
            var parentNode = curNode.Parent;

            //Lấy các Node cấp trên
            var ancNodes = curNode.Ancestors();
        }

        public static void nodeHauboi()
        {
            XDocument qlhk = XDocument.Load(
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml");

            //Lấy thông tin node của nhân khẩu có MADINHDANH "074097000011"
            var curNode = qlhk.Descendants("nhankhau").Single(q => q.Attribute("MADINHDANH").Value == "074097000011");

            //Lấy thông tin các Node con
            var childNodes = curNode.Nodes();
            var childComment = curNode.Nodes().OfType<XComment>(); // Trường hợp này, chỉ trả về các node con kiểu XComment

            //Lấy thông các Element của node hiện tại
            var childElements = curNode.Elements();

            //Lấy thông tin Element con <HOTEN> của node hiện tại
            var childElement = curNode.Element("HOTEN");

            //Lấy các Element Con cháu của node hiện tại
            var DescentantElems = curNode.Descendants();
        }
    }
}
