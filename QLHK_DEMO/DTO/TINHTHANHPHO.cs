using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class TINHTHANHPHO
    {
        //public TinhThanhPhoDTO(TINHTHANHPHO x)
        //{
        //    db = x;
        //}
        public TINHTHANHPHO(string matp, string ten, string kieu) : this()
        {
            this.matp = matp;
            this.ten = ten;
            this.kieu = kieu;
        }
    }
}
