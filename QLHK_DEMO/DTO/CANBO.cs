using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class CANBO
    {
        public CANBO(string maCanBo, string tenTaiKhoan, string matKhau, string loaiCanBo, string str_manhankhauthuongtru) : this()
        {
            MACANBO = maCanBo;
            
            TENTAIKHOAN = tenTaiKhoan;
            MATKHAU= matKhau;
            LOAICANBO = loaiCanBo;
            MANHANKHAUTHUONGTRU = str_manhankhauthuongtru;
        }

        //public CanBoDTO(DataRow dt)
        //{
        //    if (dt.ItemArray.Length == 0)
        //    {
        //        return;
        //    }

        //    db.MACANBO = dt["macanbo"].ToString();
        //    TenTaiKhoan = dt["tentaikhoan"].ToString();
        //    MatKhau = dt["matkhau"].ToString();
        //    LoaiCanBo = dt["loaicanbo"].ToString();
        //    MaNhanKhauThuongTru = dt["manhankhauthuongtru"].ToString();
        //}

        //public CANBO(CANBO cb)
        //{
        //    dbcb = cb;
        //}
        //public CANBO(CanBoDTO a)
        //{
        //    dbcb = a.dbcb;
        //}

    }
}
