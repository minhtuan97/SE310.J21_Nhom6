using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ViDu
{
    public class TruyVanEntity
    {

        //1. Truy vấn tìm nhân khẩu Lê Thùy Trang
        public static List<NHANKHAU> truyVanNHANKHAULeThuyTrang()
        {
            quanlyhokhauEntities qlhk = new quanlyhokhauEntities();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.HOTEN == "Lê Thùy Trang"
                     select nk;

            return kq.ToList();
        }



        //2. Truy vấn nhân khẩu có nơi thường trú là Đông Hòa
        public static List<NHANKHAU> truyVanNHANKHAUNoiThuongTruDongHoa()
        {
            quanlyhokhauEntities qlhk = new quanlyhokhauEntities();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.NHANKHAUTHUONGTRUs.FirstOrDefault().DIACHITHUONGTRU.Contains("Đông Hòa")
                     select nk;

            return kq.ToList();
        }


        //3. Truy vấn các nhân khẩu thường trú và sửa tên khác thành rỗng
        public static bool suaTenKhacNKTTThanhRong()
        {
            quanlyhokhauEntities qlhk = new quanlyhokhauEntities();

            var kq = from nk in qlhk.NHANKHAUs
                     where nk.NHANKHAUTHUONGTRUs.FirstOrDefault().MADINHDANH == nk.MADINHDANH
                     select nk;

            foreach(NHANKHAU nk in kq)
            {
                nk.TENKHAC = "";
            }

            try
            {
                qlhk.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            

            return true;
        }


        //4. Thêm một nhân khẩu có thông tin là tt mình
        public static bool themNHANKHAU()
        {
            quanlyhokhauEntities qlhk = new quanlyhokhauEntities();
            NHANKHAU nk = new NHANKHAU();

            nk.MADINHDANH = "074219000005";
            nk.HOTEN = "Nguyễn Anh Tuấn";
            nk.TENKHAC = "";
            nk.NGAYSINH = new DateTime(1997, 10, 6);
            nk.GIOITINH = "Nam";
            nk.NOISINH = "Kiên Giang";
            nk.NGUYENQUAN = "Kiên Giang";
            nk.DANTOC = "Kinh";
            nk.TONGIAO = "Phật giáo";
            nk.QUOCTICH = "Việt Nam";
            nk.HOCHIEU = "";
            nk.NOITHUONGTRU = "Thủ Đức, TPHCM";
            nk.DIACHIHIENNAY = "Thủ Đức, TPHCM";
            nk.SDT = "0946283526";
            nk.TRINHDOHOCVAN = "12/12";
            nk.TRINHDOCHUYENMON = "IT";
            nk.BIETTIENGDANTOC = "Không";
            nk.TRINHDONGOAINGU = "Tiếng ANh";
            nk.NGHENGHIEP = "Sinh Viên";

            qlhk.NHANKHAUs.Add(nk);
            try
            {
                qlhk.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;   
        }


        //5. Xóa nhân khẩu thường trú Lê Thùy Trang
        public static bool xoaNHANKHAU()
        {
            quanlyhokhauEntities qlhk = new quanlyhokhauEntities();

            NHANKHAU kq = qlhk.NHANKHAUs.Single(q => q.HOTEN == "Lê Thùy Trang");

            qlhk.NHANKHAUs.Remove(kq);


            try
            {
                qlhk.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
            
        }


    }
}
