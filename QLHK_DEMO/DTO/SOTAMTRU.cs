using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class SOTAMTRU
    {

        //public List<NHANKHAUTAMTRU> NhanKhau = new List<NHANKHAUTAMTRU>();


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
        DateTime ngayCap, DateTime denNgay, EntitySet<NHANKHAUTAMTRU> nhanKhau) : this()
        {
            SOSOTAMTRU = soSoTamTru;
            MACHUHO = maChuHoTamTru;
            NOITAMTRU = noiTamTru;
            NGAYCAP = ngayCap;
            DENNGAY = denNgay;
            this.NHANKHAUTAMTRUs = nhanKhau;
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
