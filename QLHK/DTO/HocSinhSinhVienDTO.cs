using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhSinhVienDTO
    {
        public string MaHSSV { get; set; }
        public string MaDinhDanh { get; set; }
        public string Truong { get; set; }
        public string DiaChiThuongTru { get; set; }
        public DateTime TGBDTTTT { get; set; }
        public DateTime TGKTTTTT { get; set; }
        public string ViPham { get; set; }

        public HocSinhSinhVienDTO() : base() { }

        public HocSinhSinhVienDTO(string maHSSV, string maDinhDanh, string truong, string diaChiThuongTru, 
            DateTime tGBDTTTT, DateTime tGKTTTTT, string viPham)
        {
            MaHSSV = maHSSV;
            MaDinhDanh = maDinhDanh;
            Truong = truong;
            DiaChiThuongTru = diaChiThuongTru;
            TGBDTTTT = tGBDTTTT;
            TGKTTTTT = tGKTTTTT;
            ViPham = viPham;
        }
    }
}
