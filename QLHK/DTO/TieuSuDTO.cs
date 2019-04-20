using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TieuSuDTO
    {
        public TIEUSU db= new TIEUSU();

        public TieuSuDTO() { }

        public TieuSuDTO(string maTieuSu, string maDinhDanh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string choO, string ngheNghiep, string noiLamViec)
        {
            db.MATIEUSU = maTieuSu;
            db.MADINHDANH = maDinhDanh;
            db.THOIGIANBATDAU = thoiGianBatDau;
            db.THOIGIANKETTHUC = thoiGianKetThuc;
            db.CHOO = choO;
            db.NGHENGHIEP = ngheNghiep;
            db.NOILAMVIEC= noiLamViec;
        }

        public TieuSuDTO(TIEUSU dbs)
        {
            db = dbs;
        }
    }
}
