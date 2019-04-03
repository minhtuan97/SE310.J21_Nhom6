using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanHuyenDTO
    {
        public QUANHUYEN db;


        public QuanHuyenDTO() { }
        public QuanHuyenDTO(string maqh, string ten, string kieu, string matp)
        {
            db.maqh = maqh;
            db.ten = ten;
            db.kieu = kieu;
            db.matp = matp;
        }
    }
}
