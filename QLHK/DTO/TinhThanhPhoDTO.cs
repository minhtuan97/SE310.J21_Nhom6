using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhThanhPhoDTO
    {
        public TINHTHANHPHO db;

        public TinhThanhPhoDTO() { }
        public TinhThanhPhoDTO(TINHTHANHPHO x)
        {
            db = x;
        }
        public TinhThanhPhoDTO(string matp, string ten, string kieu)
        {
            db.matp = matp;
            db.ten = ten;
            db.kieu = kieu;
        }
    }
}
