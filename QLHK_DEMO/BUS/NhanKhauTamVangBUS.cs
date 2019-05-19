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
    public class NhanKhauTamVangBUS:AbstractFormBUS<NHANKHAUTAMVANG>
    {
        NhanKhauTamVangDAO obj = new NhanKhauTamVangDAO();
        public NhanKhauTamVangBUS() : base() { }

        public override bool Add(NHANKHAUTAMVANG data)
        {
            return obj.insert(data);
        }

        public override bool Add_Table(NHANKHAUTAMVANG data)
        {
            return obj.insert_table(data);
        }
        public bool deleteNKTV(string id)
        {
            return obj.deleteNKTV(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override List<NHANKHAUTAMVANG> GetAll()
        {
            return obj.getAll();
        }

        public override bool Update(NHANKHAUTAMVANG data)
        {
            return obj.update(data);
        }

        public List<NHANKHAUTAMVANG> TimKiem(string query)
        {
            return obj.TimKiemJoinNhanKhau(query);
        }


        public List<NHANKHAUTAMVANG> TimKiemnhankhau(string query)
        {
            return obj.TimKiemNhanKhau(query);
        }
        public int TimKiemThuongtru(string query)
        {
            return obj.TimKiemThuongtru(query);
        }
    }
}
