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
        public CANBO dbcb= new CANBO();
        public CanBoDTO() : base() { }

        public CanBoDTO(string maCanBo, string tenTaiKhoan, string matKhau, string loaiCanBo, string str_manhankhauthuongtru)
        {
            dbcb.MACANBO = maCanBo;
            
            dbcb.TENTAIKHOAN = tenTaiKhoan;
            dbcb.MATKHAU= matKhau;
            dbcb.LOAICANBO = loaiCanBo;
            dbcb.MANHANKHAUTHUONGTRU = str_manhankhauthuongtru;
        }

        public CanBoDTO(DataRow dt)
        {
            if (dt.ItemArray.Length == 0)
            {
                return;
            }

            //db.MACANBO = dt["macanbo"].ToString();
            //TenTaiKhoan = dt["tentaikhoan"].ToString();
            //MatKhau = dt["matkhau"].ToString();
            //LoaiCanBo = dt["loaicanbo"].ToString();
            //MaNhanKhauThuongTru = dt["manhankhauthuongtru"].ToString();
        }

        public CanBoDTO(CANBO cb)
        {
            dbcb = cb;
        }
        public CanBoDTO(CanBoDTO a)
        {
            dbcb = a.dbcb;
        }

    }
}
