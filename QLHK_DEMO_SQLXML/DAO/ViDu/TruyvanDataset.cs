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
            if (childRows[0].GetParentRow("FR_NKTT") != null)
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
            NHANKHAU nk = new NHANKHAU("083456789019", "Lê Minh Tuấn", "Phúc", new DateTime(1997, 6, 23), "nam", "Tân Long, Phú Giáo, Bình Dương",
            "Huế", "Kinh", "Không", "Việt Nam", "", "Tân Long, Phú Giáo, Bình Dương", "Tân Lập, Đông Hòa, Dĩ An, Bình Dương", "0123456789",
            "ĐH", "IT", "Không", "Anh", "Sinh viên");

            var a = db.dbDataSet.Tables["NHANKHAU"];
            DataRow row = a.NewRow();
            row["MADINHDANH"] = nk.MADINHDANH;
            row["HOTEN"] = nk.HOTEN;
            row["TENKHAC"] = nk.TENKHAC;
            row["NGAYSINH"] = nk.NGAYSINH;
            row["GIOITINH"] = nk.GIOITINH;
            row["NOISINH"] = nk.NOISINH;
            row["NGUYENQUAN"] = nk.NGUYENQUAN;
            row["DANTOC"] = nk.DANTOC;
            row["TONGIAO"] = nk.TONGIAO;
            row["QUOCTICH"] = nk.QUOCTICH;
            row["HOCHIEU"] = nk.HOCHIEU;
            row["NOITHUONGTRU"] = nk.NOITHUONGTRU;
            row["DIACHIHIENNAY"] = nk.DIACHIHIENNAY;
            row["SDT"] = nk.SDT;
            row["TRINHDOHOCVAN"] = nk.TRINHDOHOCVAN;
            row["TRINHDOCHUYENMON"] = nk.TRINHDOCHUYENMON;
            row["BIETTIENGDANTOC"] = nk.BIETTIENGDANTOC;
            row["TRINHDONGOAINGU"] = nk.TRINHDONGOAINGU;
            row["NGHENGHIEP"] = nk.NGHENGHIEP;

            a.Rows.Add(row);
            db.NHANKHAU.AcceptChanges();

        }

        public static void UpdateDataTable()
        {
            qlhkDataSet db = new qlhkDataSet();
            var rowsToUpdate = db.dbDataSet.Tables["NHANKHAU"].AsEnumerable();

            foreach (var row in rowsToUpdate)
            {
                row.SetField("TENKHAC", "");
            }
            db.NHANKHAU.AcceptChanges();
        }

        public static void DeleteDataRow()
        {
            qlhkDataSet db = new qlhkDataSet();
            db.dbDataSet.Tables["NHANKHAU"].AsEnumerable()
                .SingleOrDefault(r => r.Field<string>("HOTEN").SequenceEqual("Lê Thùy Trang")).Delete();
            db.NHANKHAU.AcceptChanges();
        }

        public static void DeleteDataRow2()
        {
            qlhkDataSet db = new qlhkDataSet();
            var rowsToDelete = db.dbDataSet.Tables["NHANKHAU"].AsEnumerable()
                .Where(r => r.Field<string>("HOTEN").SequenceEqual("Lê Thùy Trang"));

            foreach (var row in rowsToDelete)
            {
                row.Delete();
            }
            db.NHANKHAU.AcceptChanges();
        }
    }
}