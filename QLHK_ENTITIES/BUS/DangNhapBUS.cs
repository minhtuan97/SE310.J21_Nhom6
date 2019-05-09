using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public static class DangNhapBUS
    {
        static CanBoBUS cbBUS = new CanBoBUS();
        static CanBoDTO cb;
        static bool isSuccess = false;
        public static List<CanBoDTO> TimKiem(string taikhoan, string matkhau)
        {
            List<CanBoDTO> tb = cbBUS.TimKiem("tentaikhoan='" + taikhoan + "' AND matkhau='" + matkhau + "'");
            if(tb.Count>0)
            {
                isSuccess = true;
                return tb;
            }

            isSuccess= false;
            return null;
        }
    }
}
