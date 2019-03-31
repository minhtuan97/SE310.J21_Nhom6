using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CanBoDTO: NhanKhauThuongTruDTO
    {
        public CANBO db;
        public CanBoDTO() : base() { }

        public CanBoDTO(string maCanBo, string tenTaiKhoan, string matKhau, string loaiCanBo, string str_manhankhauthuongtru)
        {
            db.MACANBO = maCanBo;

            db.TENTAIKHOAN = tenTaiKhoan;
            db.MATKHAU= matKhau;
            db.LOAICANBO = loaiCanBo;
            db.MANHANKHAUTHUONGTRU = str_manhankhauthuongtru;
        }

        public CanBoDTO(DataRow dt)
        {
            if (dt.ItemArray.Length == 0)
            {
                return;
            }

            db.MACANBO = dt["macanbo"].ToString();
            TenTaiKhoan = dt["tentaikhoan"].ToString();
            MatKhau = dt["matkhau"].ToString();
            LoaiCanBo = dt["loaicanbo"].ToString();
            MaNhanKhauThuongTru = dt["manhankhauthuongtru"].ToString();
        }

    }
}
