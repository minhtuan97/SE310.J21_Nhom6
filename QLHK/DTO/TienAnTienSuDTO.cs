using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TienAnTienSuDTO
    {
        public TIENANTIENSU db= new TIENANTIENSU();
        
        public TienAnTienSuDTO() { }

        public TienAnTienSuDTO(string maTienAnTienSu, string maDinhDanh, string banAn, string toiDanh, string hinhPhat, DateTime ngayPhat)
        {
            db.MATIENANTIENSU = maTienAnTienSu;
            db.MADINHDANH = maDinhDanh;
            db.BANAN = banAn;
            db.TOIDANH = toiDanh;
            db.HINHPHAT = hinhPhat;
            db.NGAYPHAT = ngayPhat;
        }

        public TienAnTienSuDTO(TIENANTIENSU dbs)
        {
            db = dbs;
        }
    }
}
