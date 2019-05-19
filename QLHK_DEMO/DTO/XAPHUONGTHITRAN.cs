using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class XAPHUONGTHITRAN
    {
        //public XaPhuongThiTranDTO( XAPHUONGTHITRAN x)
        //{
        //    db = x;
        //}
        public XAPHUONGTHITRAN(string maxp, string ten, string kieu, string maqh) : this()
        {
            this.maxp = maxp;
            this.ten = ten;
            this.kieu = kieu;
            this.maqh = maqh;
        }
    }
}
