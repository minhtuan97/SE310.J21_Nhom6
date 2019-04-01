using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TinhThanhPhoDTO
    {
        public string MaTP { get; set; }
        public string Ten { get; set; }
        public string Kieu { get; set; }


        public TinhThanhPhoDTO() { }
        public TinhThanhPhoDTO(string matp, string ten, string kieu)
        {
            this.MaTP = matp;
            this.Ten = ten;
            this.Kieu = kieu;
        }
    }
}
