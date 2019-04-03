using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XaPhuongThiTranDTO
    {
        public XAPHUONGTHITRAN db;


        public XaPhuongThiTranDTO() { }
        public XaPhuongThiTranDTO( XAPHUONGTHITRAN x)
        {
            db = x;
        }
        public XaPhuongThiTranDTO(string maxp, string ten, string kieu, string maqh)
        {
            db.maxp = maxp;
            db.ten = ten;
            db.kieu = kieu;
            db.maqh = maqh;
        }
    }
}
