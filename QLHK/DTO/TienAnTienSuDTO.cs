using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TienAnTienSuDTO
    {
        public string MaTienAnTienSu { get; set; }
        public string MaDinhDanh { get; set; }
        public string ToiDanh { get; set; }
        public string HinhPhat { get; set; }
        public string BanAn { get; set; }
        public DateTime NgayPhat { get; set; }
        public TienAnTienSuDTO() { }

        public TienAnTienSuDTO(string maTienAnTienSu, string maDinhDanh, string banAn, string toiDanh, string hinhPhat, DateTime ngayPhat)
        {
            MaTienAnTienSu = maTienAnTienSu;
            MaDinhDanh = maDinhDanh;
            BanAn = banAn;
            ToiDanh = toiDanh;
            HinhPhat = hinhPhat;
            NgayPhat = ngayPhat;
        }
    }
}
