using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DB;
using DTO;
using System.Data;

namespace DAO.ViDu
{
    public class TruyvanDataset
    {
        public static DataTable CopyDataTable()
        {
            qlhkDataSet db = new qlhkDataSet();
            IEnumerable<DataRow> kq1 = from nktt in db.dbDataSet.Tables["NHANKHAU"].AsEnumerable()
                                       select nktt;
            DataTable tb = kq1.CopyToDataTable<DataRow>();
            return tb;
        }

        public static DataTable layNKLeThuyTrang()
        {
           qlhkDataSet db = new qlhkDataSet();
           var kq = from nk in db.dbDataSet.Tables["NHANKHAU"].AsEnumerable()
                                      where nk.Field<string>("HOTEN").SequenceEqual("Lê Thùy Trang")
                                      select nk;
            DataTable tb = kq.CopyToDataTable<DataRow>();

            return tb;
        }
        public static DataTable layNKTT()
        {
            qlhkDataSet db = new qlhkDataSet();

            DataRow[] childRows = db.dbDataSet.Tables["NHANKHAUTHUONGTRU"].Select();
            DataTable b = new DataTable("NHANKHAU");
            if(childRows[0].GetParentRow("FR_NKTT")!=null)
            {
                b = childRows[0].GetParentRow("FR_NKTT").Table.Clone();
                foreach (DataRow a in childRows)
                {
                    DataRow parentRow = a.GetParentRow("FR_NKTT");
                    b.Rows.Add(parentRow.ItemArray);
                }
                return b;
            }              
            else
            {
                return null;
            }
        }

        public static void AddRow()
        {
            qlhkDataSet db = new qlhkDataSet();
            NhanKhau nk = new NhanKhau("083456789019", "Lê Minh Tuấn", "Phúc", new DateTime(1997,6,23),"nam", "Tân Long, Phú Giáo, Bình Dương", 
            "Huế", "Kinh", "Không", "Việt Nam", "", "Tân Long, Phú Giáo, Bình Dương", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương","0123456789", 
            "ĐH", "IT", "Không", "Anh", "Sinh viên");

            var a = db.dbDataSet.Tables["NHANKHAU"];
            DataRow row = a.NewRow();
            row["MADINHDANH"] = nk.db.MADINHDANH;
            row["HOTEN"] = nk.db.HOTEN;
            row["TENKHAC"] = nk.db.TENKHAC;
            row["NGAYSINH"] = nk.db.NGAYSINH;
            row["GIOITINH"] = nk.db.GIOITINH;
            row["NOISINH"] = nk.db.NOISINH;
            row["NGUYENQUAN"] = nk.db.NGUYENQUAN;
            row["DANTOC"] = nk.db.DANTOC;
            row["TONGIAO"] = nk.db.TONGIAO;
            row["QUOCTICH"] = nk.db.QUOCTICH;
            row["HOCHIEU"] = nk.db.HOCHIEU;
            row["NOITHUONGTRU"] = nk.db.NOITHUONGTRU;
            row["DIACHIHIENNAY"] = nk.db.DIACHIHIENNAY;
            row["SDT"] = nk.db.SDT;
            row["TRINHDOHOCVAN"] = nk.db.TRINHDOHOCVAN;
            row["TRINHDOCHUYENMON"] = nk.db.TRINHDOCHUYENMON;
            row["BIETTIENGDANTOC"] = nk.db.BIETTIENGDANTOC;
            row["TRINHDONGOAINGU"] = nk.db.TRINHDONGOAINGU;
            row["NGHENGHIEP"] = nk.db.NGHENGHIEP;

            a.Rows.Add(row);

        }

        public static void UpdateDataTable()
        {
            qlhkDataSet db = new qlhkDataSet();
            var rowsToUpdate = db.dbDataSet.Tables["NHANKHAU"].AsEnumerable();

            foreach (var row in rowsToUpdate)
            {
                row.SetField("TENKHAC", "");
            }
        }

        public static void DeleteDataRow()
        {
            qlhkDataSet db = new qlhkDataSet();
            var rowsToDelete = db.dbDataSet.Tables["NHANKHAU"].AsEnumerable()
                .Where(r => r.Field<string>("HOTEN").SequenceEqual("Lê Thùy Trang"));

            foreach (var row in rowsToDelete)
            {
                row.Delete();
            }
        }
    }
}
