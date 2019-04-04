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
        public HocSinhSinhVienBUS() : base() { }

        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();

        NhanKhauDAO objnk = new NhanKhauDAO();

        public override List<HocSinhSinhVienDTO> GetAll()
        {
            return objhssv.getAll();
        }

        public List<HocSinhSinhVienDTO> GetAllJoinNhanKhau()
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

        public override bool Update(HocSinhSinhVienDTO hssv)
        {
            return objhssv.update(hssv);
        }

        public DataTable TimKiem(string query)
        {
            return objhssv.TimKiem(query);
        }

        public List<HocSinhSinhVienDTO> TimKiemJoinNhanKhau(string query)
        {
            return objhssv.TimKiemJoinNhanKhau(query);
        }

        public DataTable TimKiemtheoCuTru(string madinhdanh)
        {
            DataTable dt1 = objhssv.TimKiem(" WHERE madinhdanh='" + madinhdanh + "'");
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
            if (!string.IsNullOrEmpty(hssv.dbhssv.MAHSSV) && !string.IsNullOrEmpty(hssv.dbhssv.MADINHDANH) && !string.IsNullOrEmpty(hssv.dbhssv.TRUONG)
                && !string.IsNullOrEmpty(hssv.dbhssv.DIACHITHUONGTRU) && !string.IsNullOrEmpty(hssv.dbhssv.THOIGIANBATDAUTAMTRUTHUONGTRU.ToString()) 
                && !string.IsNullOrEmpty(hssv.dbhssv.THOIGIANKETTHUCTAMTRUTHUONGTRU.ToString()))
                return true;
            return false;
        }
    }
}
