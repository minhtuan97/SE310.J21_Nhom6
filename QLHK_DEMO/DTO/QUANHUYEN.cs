using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class QUANHUYEN
    {
        //public QuanHuyenDTO(QUANHUYEN x) {
        //    db = x;
        //}
        public QUANHUYEN(string maqh, string ten, string kieu, string matp) : this()
        {
            this.maqh = maqh;
            this.ten = ten;
            this.kieu = kieu;
            this.matp = matp;
        }
    }
}
