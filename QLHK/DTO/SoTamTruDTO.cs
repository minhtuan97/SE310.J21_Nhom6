using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SoTamTruDTO
    {
        public string SoSoTamTru { get; set; }
        public string MaChuHoTamTru { get; set; }
        public string NoiTamTru { get; set; }
        public DateTime NgayCap { get; set; }
        public DateTime DenNgay { get; set; }

        public SoTamTruDTO() { }

        public SoTamTruDTO(string soSoTamTru, string maChuHoTamTru, string noiTamTru, 
            DateTime ngayCap, DateTime denNgay)
        {
            SoSoTamTru = soSoTamTru;
            MaChuHoTamTru = maChuHoTamTru;
            NoiTamTru = noiTamTru;
            NgayCap = ngayCap;
            DenNgay = denNgay;
        }
    }
}
