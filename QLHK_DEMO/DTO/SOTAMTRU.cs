using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class SOTAMTRU
    {

        public List<NHANKHAUTAMTRU> NhanKhau = new List<NHANKHAUTAMTRU>();


        public SOTAMTRU(string soSoTamTru, string maChuHoTamTru, string noiTamTru, 
            DateTime ngayCap, DateTime denNgay) : this()
        {
            SOSOTAMTRU = soSoTamTru;
            MACHUHO  = maChuHoTamTru;
            NOITAMTRU = noiTamTru;
            NGAYCAP = ngayCap;
            DENNGAY = denNgay;
        }

        public SOTAMTRU(string soSoTamTru, string maChuHoTamTru, string noiTamTru,
        DateTime ngayCap, DateTime denNgay, List<NHANKHAUTAMTRU> nhanKhau) : this()
        {
            SOSOTAMTRU = soSoTamTru;
            MACHUHO = maChuHoTamTru;
            NOITAMTRU = noiTamTru;
            NGAYCAP = ngayCap;
            DENNGAY = denNgay;
            NhanKhau = nhanKhau;
        }

  
        //public SoTamTruDTO(SOTAMTRU dbs)
        //{
        //    db = dbs;
        //}

        //public SoTamTruDTO(SoTamTruDTO stt)
        //{
        //    db = stt.db;
        //}
    }
}
