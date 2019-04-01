using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanHuyenDTO
    {
        public string MaQH { get; set; }
        public string Ten { get; set; }
        public string Kieu { get; set; }
        public string MaTP { get; set; }


        public QuanHuyenDTO() { }
        public QuanHuyenDTO(string maqh, string ten, string kieu, string matp)
        {
            this.MaQH = maqh;
            this.Ten = ten;
            this.Kieu = kieu;
            this.MaTP = matp;
        }
    }
}
