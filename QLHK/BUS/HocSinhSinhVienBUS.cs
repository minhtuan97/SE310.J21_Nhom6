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
    public class HocSinhSinhVienBUS : AbstractFormBUS<HocSinhSinhVienDTO>
    {
        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();
        NhanKhauDAO objnk = new NhanKhauDAO();
        public override DataSet GetAll()
        {
            return objhssv.getAll();
        }
        public DataSet GetAllJoinNhanKhau()
        {
            return objhssv.getAllJoinNhanKhau();
        }
        public override bool Add(HocSinhSinhVienDTO hssv)
        {
            if (isValidHSSV(hssv) == false)
                return false;
            return objhssv.insert(hssv);
        }
        public bool XoaHSSV(string mssv)
        {
            return objhssv.XoaHHSV(mssv);
        }
        public override bool Delete(int r)
        {
            return objhssv.delete(r);
        }
        public override bool Update(HocSinhSinhVienDTO hssv, int r)
        {
            return objhssv.update(hssv, r);
        }

        public DataSet TimKiem(string query)
        {
            return objhssv.TimKiem(query);
        }
        public DataSet TimKiemJoinNhanKhau(string query)
        {
            return objhssv.TimKiemJoinNhanKhau(query);
        }
        public DataTable TimKiemtheoCuTru(string madinhdanh)
        {
            DataTable dt1 = objhssv.TimKiem(" WHERE madinhdanh='" + madinhdanh + "'").Tables[0];
            DataSet nhanKhau = objnk.TimKiemTheoCuTru(madinhdanh);
            DataTable dt2 = nhanKhau.Tables["thuongtru"].Rows.Count > 0? nhanKhau.Tables["thuongtru"]:nhanKhau.Tables["tamtru"];

            dt1.PrimaryKey = new DataColumn[] { dt1.Columns["madinhdanh"] };
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["madinhdanh"] };
            dt1.Merge(dt2);
            return dt1;
        }
        public override bool Add_Table(HocSinhSinhVienDTO hssv)
        {
            return objhssv.insert_table(hssv);
        }
        public bool isValidHSSV(HocSinhSinhVienDTO hssv)
        {
            if (!string.IsNullOrEmpty(hssv.MaHSSV) && !string.IsNullOrEmpty(hssv.MaDinhDanh) && !string.IsNullOrEmpty(hssv.Truong)
                && !string.IsNullOrEmpty(hssv.DiaChiThuongTru) && !string.IsNullOrEmpty(hssv.TGBDTTTT.ToString()) 
                && !string.IsNullOrEmpty(hssv.TGKTTTTT.ToString()))
                return true;
            return false;
        }
    }
}
