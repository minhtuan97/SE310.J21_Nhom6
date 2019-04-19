﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SoTamTruDTO
    {
        public SOTAMTRU db = new SOTAMTRU();

        public SoTamTruDTO() { }

        public SoTamTruDTO(string soSoTamTru, string maChuHoTamTru, string noiTamTru, 
            DateTime ngayCap, DateTime denNgay)
        {
            db.SOSOTAMTRU = soSoTamTru;
            db.MACHUHO  = maChuHoTamTru;
            db.NOITAMTRU = noiTamTru;
            db.NGAYCAP = ngayCap;
            db.DENNGAY = denNgay;
        }

        public SoTamTruDTO(SOTAMTRU dbs)
        {
            db = dbs;
        }
    }
}
