using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class TIEUSU
    {
        public TIEUSU(string maTieuSu, string maDinhDanh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string choO, string ngheNghiep, string noiLamViec) : this()
        {
            MATIEUSU = maTieuSu;
            MADINHDANH = maDinhDanh;
            THOIGIANBATDAU = thoiGianBatDau;
            THOIGIANKETTHUC = thoiGianKetThuc;
            CHOO = choO;
            NGHENGHIEP = ngheNghiep;
            NOILAMVIEC= noiLamViec;
        }

        //public TieuSuDTO(TIEUSU dbs)
        //{
        //    db = dbs;
        //}
    }
}
