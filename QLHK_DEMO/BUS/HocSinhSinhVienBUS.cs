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
    public class HocSinhSinhVienBUS : AbstractFormBUS<HOCSINHSINHVIEN>
    {
        public HocSinhSinhVienBUS() : base() { }

        HocSinhSinhVienDAO objhssv = new HocSinhSinhVienDAO();

        NhanKhauDAO objnk = new NhanKhauDAO();

        public override List<HOCSINHSINHVIEN> GetAll()
        {
            return objhssv.getAll();
        }

        public List<HOCSINHSINHVIEN> GetAllJoinNhanKhau()
        {
            return objhssv.getAllJoinNhanKhau();
        }

        public override bool Add(HOCSINHSINHVIEN hssv)
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
        public bool DeleteHSSV(string id)
        {
            return objhssv.deleteHSSV(id);
        }

        public override bool Update(HOCSINHSINHVIEN hssv)
        {
            return objhssv.update(hssv);
        }

        public DataTable TimKiem(string query)
        {
            return objhssv.TimKiem(query);
        }

        public List<HOCSINHSINHVIEN> TimKiemJoinNhanKhau(string query)
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

        public override bool Add_Table(HOCSINHSINHVIEN hssv)
        {
            return objhssv.insert_table(hssv);
        }

        public bool isValidHSSV(HOCSINHSINHVIEN hssv)
        {
            if (!string.IsNullOrEmpty(hssv.MAHSSV) && !string.IsNullOrEmpty(hssv.MADINHDANH) && !string.IsNullOrEmpty(hssv.TRUONG)
                && !string.IsNullOrEmpty(hssv.DIACHITHUONGTRU) && !string.IsNullOrEmpty(hssv.THOIGIANBATDAUTAMTRUTHUONGTRU.ToString()) 
                && !string.IsNullOrEmpty(hssv.THOIGIANKETTHUCTAMTRUTHUONGTRU.ToString()))
                return true;
            return false;
        }
    }
}
