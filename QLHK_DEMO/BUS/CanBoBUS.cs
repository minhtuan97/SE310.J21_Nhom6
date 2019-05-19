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
    public class CanBoBUS:AbstractFormBUS<CANBO>
    {
        CanBoDAO objcb = new CanBoDAO();
        public override List<CANBO> GetAll()
        {
            return objcb.getAll();
        }
        public override bool Add(CANBO cb)
        {
            return objcb.insert(cb);
        }
        public override bool Delete(int row)
        {
            return objcb.delete(row);
        }
        public bool deleteCB(string id)
        {
            return objcb.deleteCB(id);
        }
        public override bool Update(CANBO cb)
        {
            return objcb.update(cb);
        }
        public override bool Add_Table(CANBO data)
        {
            return objcb.insert_table(data);
        }
        public List<CANBO> TimKiem(string query)
        {
            return objcb.TimKiem(query).ToList();
        }

        public string GetMaNhanKhauThuongTruFromCanBo(string tendangnhap)
        {
            return objcb.GetMaNhanKhauThuongTruFromCanBo(tendangnhap);
        }

        public List<NHANKHAUTHUONGTRU> getTTNhanKhauThuongTru(string manhankhauthuongtru)
        {
            return objcb.getThongTinNhanKhau(manhankhauthuongtru);
        }

        public bool CapNhatMatKhau(string tentaikhoan, string matkhau)
        {
            return objcb.CapNhatMatKhau(tentaikhoan, matkhau);
        }

    }
}
