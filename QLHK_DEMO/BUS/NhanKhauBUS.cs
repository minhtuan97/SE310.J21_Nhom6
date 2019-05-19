
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
    public class NhanKhauBUS:AbstractFormBUS<NHANKHAU>
    {
        NhanKhauDAO objnhankhau = new NhanKhauDAO();
        public override List<NHANKHAU> GetAll()
        {
            return objnhankhau.getAll();
        }
        public override bool Add(NHANKHAU nk)
        {
            return objnhankhau.insert(nk);
        }
          public  bool Delete(string madinhdanh)
        {
            return objnhankhau.delete(madinhdanh);
        }
        public override bool Update(NHANKHAU nk)
        {
            return objnhankhau.update(nk);
        }
        public override bool Delete(int row)
        {
            return objnhankhau.delete(row);
        }
        public bool DeleteNK(string id)
        {
            return objnhankhau.deleteNK(id);
        }
        public override bool Add_Table(NHANKHAU data)
        {
            return objnhankhau.insert_table(data);
        }
        public List<NHANKHAU> TimKiem(string query)
        {
            return objnhankhau.TimKiem(query);
        }
        public DataSet TimKiemTheoCuTru(string madinhdanh)
        {
            return objnhankhau.TimKiemTheoCuTru(madinhdanh);
        }
    }
}
