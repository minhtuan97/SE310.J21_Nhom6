using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanHuyenDTO
    {
        public QUANHUYEN db= new QUANHUYEN();

        public QuanHuyenDTO() { }
        public QuanHuyenDTO(QUANHUYEN x) {
            db = x;
        }
        public QuanHuyenDTO(string maqh, string ten, string kieu, string matp)
        {
            db.maqh = maqh;
            db.ten = ten;
            db.kieu = kieu;
            db.matp = matp;
        }
    }
}
