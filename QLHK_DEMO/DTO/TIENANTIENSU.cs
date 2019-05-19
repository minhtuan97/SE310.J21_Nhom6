using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class TIENANTIENSU
    {

        public TIENANTIENSU(string maTienAnTienSu, string maDinhDanh, string banAn, string toiDanh, string hinhPhat, DateTime ngayPhat) : this()
        {
            MATIENANTIENSU = maTienAnTienSu;
            MADINHDANH = maDinhDanh;
            BANAN = banAn;
            TOIDANH = toiDanh;
            HINHPHAT = hinhPhat;
            NGAYPHAT = ngayPhat;
        }

        //public TienAnTienSuDTO(TIENANTIENSU dbs)
        //{
        //    db = dbs;
        //}
    }
}
