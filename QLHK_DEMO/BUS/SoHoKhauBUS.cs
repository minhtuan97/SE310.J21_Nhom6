using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class SoHoKhauBUS: AbstractFormBUS<SOHOKHAU>
    {
        SoHoKhauDAO obj = new SoHoKhauDAO();
        NhanKhauThuongTruDAO nktt = new NhanKhauThuongTruDAO();
        public override List<SOHOKHAU> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(SOHOKHAU sohk)
        {
            
            return obj.insert(sohk);
        }
        public override bool Add_Table(SOHOKHAU data)
        {
            return obj.insert_table(data);
        }
        public bool XoaSoHK(string soSoHoKhau)
        {
            return obj.XoaSoHK(soSoHoKhau);
        }
        public bool deleteSHK(string id)
        {
            return obj.deleteSHK(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public override bool Update(SOHOKHAU sohk)
        {   
            return  obj.update(sohk);
        }

        public List<SOHOKHAU> TimKiem(string query)
        {
            List<SOHOKHAU>list = obj.TimKiem(query);
            if (list.Count > 0)
            {
                
                foreach (SOHOKHAU item in list)
                {
                    item.NhanKhau = nktt.TimKiem("SOSOHOKHAU='" + item.SOSOHOKHAU + "'");
                }
            }

            return list;
        }

        //public SOHOKHAU TimSo(string sosohokhau)
        //{
        //    SOHOKHAU so;
        //    DataTable ds = obj.TimKiem("sosohokhau='" + sosohokhau + "'").Tables[0];
        //    if (ds != null)
        //    {
        //        DataRow data = ds.Rows[0];

        //        so = new SOHOKHAU(data["sosohokhau"].ToString(), data["machuho"].ToString(), data["diachi"].ToString(),
        //            DateTime.Parse(data["ngaycap"].ToString()), data["sodangky"].ToString());


        //        DataTable dtnhankhau = nktt.TimKiemJoinNhanKhau("sosohokhau='" + sosohokhau + "'").Tables[0];

        //        foreach (DataRow item in dtnhankhau.Rows)
        //        {
        //            so.NhanKhau.Add(new NhanKhauThuongTruDTO(item));
        //        }

        //    }

        //    return null;
        //}
    }
}
