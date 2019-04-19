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
    public class NhanKhauTamVangBUS:AbstractFormBUS<NhanKhauTamVangDTO>
    {
        NhanKhauTamVangDAO obj = new NhanKhauTamVangDAO();
        public NhanKhauTamVangBUS() : base() { }

        public override bool Add(NhanKhauTamVangDTO data)
        {
            return obj.insert(data);
        }

        public override bool Add_Table(NhanKhauTamVangDTO data)
        {
            return obj.insert_table(data);
        }

        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override List<NhanKhauTamVangDTO> GetAll()
        {
            return obj.getAll();
        }

        public override bool Update(NhanKhauTamVangDTO data)
        {
            return obj.update(data);
        }

        public List<NhanKhauTamVangDTO> TimKiem(string query)
        {
            return obj.TimKiemJoinNhanKhau(query);
        }


        public List<NhanKhauTamVangDTO> TimKiemnhankhau(string query)
        {
            return obj.TimKiemNhanKhau(query);
        }
        public int TimKiemThuongtru(string query)
        {
            return obj.TimKiemThuongtru(query);
        }
    }
}
