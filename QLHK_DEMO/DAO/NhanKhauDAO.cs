using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauDAO:DBConnection<NHANKHAU>
    {
        public NhanKhauDAO() : base() { }
        public override List<NHANKHAU> getAll()
        {
            var kq = from nkdto in qlhk.NHANKHAUs
                     select nkdto;
            List<NHANKHAU> x = kq.ToList();
            return x;
        }

        public List<NHANKHAU> getNHANKHAU()
        {
            quanlyhokhauDataContext qlhk = new quanlyhokhauDataContext();
            var kq = from nk in qlhk.NHANKHAUs
                     select nk;

            return kq.ToList();
        }
        public override bool insert_table(NHANKHAU data)
        {
            qlhk.NHANKHAUs.InsertOnSubmit(data);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SubmitChanges();
                return false;
            }
        }
        public override bool insert(NHANKHAU nk)
        {
            qlhk.NHANKHAUs.InsertOnSubmit(nk);
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //qlhk.SubmitChanges();
                return false;
            }

        }
        public bool deleteNK(string id)
        {
            var kq =
            from nk in qlhk.NHANKHAUs
            where nk.MADINHDANH == id
            select nk;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUs.DeleteOnSubmit(detail);
            }

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                // Provide for exceptions.
            }
        }
        public override bool delete(int row)
        {
            try
            {
                List<NHANKHAU> kq = this.getAll();
                NHANKHAU[] arr = kq.ToArray();
                qlhk.NHANKHAUs.DeleteOnSubmit(arr[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public bool delete(string madinhdanh)
        {
            // Query the database for the rows to be deleted.
            var deleteOrderDetails =
                from details in qlhk.NHANKHAUs
                where details.MADINHDANH == madinhdanh
                select details;

            foreach (var detail in deleteOrderDetails)
            {
                qlhk.NHANKHAUs.DeleteOnSubmit(detail);
            }

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return false;
            }
        }
        public override bool update(NHANKHAU nk)
        {
            // Query the database for the row to be updated.
            var query =
                from NHANKHAU in qlhk.NHANKHAUs
                where nk.MADINHDANH == NHANKHAU.MADINHDANH
                select NHANKHAU;

            // Execute the query, and change the column values
            // you want to change.

            foreach (NHANKHAU kq in query)
            {
                kq.MADINHDANH = nk.MADINHDANH;
                kq.HOTEN = nk.HOTEN;
                kq.TENKHAC = nk.TENKHAC;
                kq.NGAYSINH = nk.NGAYSINH;
                kq.GIOITINH = nk.GIOITINH;
                kq.NOISINH = nk.NOISINH;
                kq.NGUYENQUAN = nk.NGUYENQUAN;
                kq.DANTOC = nk.DANTOC;
                kq.TONGIAO = nk.TONGIAO;
                kq.QUOCTICH = nk.QUOCTICH;
                kq.HOCHIEU = nk.HOCHIEU;
                kq.NOITHUONGTRU = nk.NOITHUONGTRU;
                kq.DIACHIHIENNAY = nk.DIACHIHIENNAY;
                kq.SDT = nk.SDT;
                kq.TRINHDOHOCVAN = nk.TRINHDOHOCVAN;
                kq.TRINHDOCHUYENMON = nk.TRINHDOCHUYENMON;
                kq.BIETTIENGDANTOC = nk.BIETTIENGDANTOC;
                kq.TRINHDONGOAINGU = nk.TRINHDONGOAINGU;
                kq.NGHENGHIEP = nk.NGHENGHIEP;
            }

            // Submit the changes to the database.
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return false;
            }
        }
        public  List<NHANKHAU> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM NHANKHAU" + query;
            var res = qlhk.ExecuteQuery<NHANKHAU>(query).ToList();

            return res;
        }

        public DataSet TimKiemTheoCuTru(string madinhdanh)
        {
            DataSet dataset = new DataSet();
            var querytht = (from nktt in qlhk.NHANKHAUTHUONGTRUs.AsEnumerable()
                                            join nk in qlhk.NHANKHAUs.AsEnumerable() on nktt.MADINHDANH equals nk.MADINHDANH
                                            select new
                                            {
                                                nk.MADINHDANH,
                                                nk.HOTEN ,
                                                nk.TENKHAC,
                                                nk.NGAYSINH,
                                                nk.GIOITINH,
                                                nk.NOISINH,
                                                nk.NGUYENQUAN,
                                                nk.DANTOC,
                                                nk.TONGIAO,
                                                nk.QUOCTICH,
                                                nk.HOCHIEU,
                                                nk.NOITHUONGTRU,
                                                nk.DIACHIHIENNAY,
                                                nk.SDT,
                                                nk.TRINHDOHOCVAN,
                                                nk.TRINHDOCHUYENMON,
                                                nk.BIETTIENGDANTOC,
                                                nk.TRINHDONGOAINGU,
                                                nk.NGHENGHIEP,
                                                nktt.MANHANKHAUTHUONGTRU,
                                                nktt.QUANHEVOICHUHO,
                                                nktt.SOSOHOKHAU,
                                                nktt.DIACHITHUONGTRU
                                            } ) as IEnumerable<DataRow>;
            DataTable tbtht = querytht.CopyToDataTable();
            tbtht.TableName = "thuongtru";
            dataset.Tables.Add(tbtht);

            var querytt = (from nktt in qlhk.NHANKHAUTAMTRUs.AsEnumerable()
                            join nk in qlhk.NHANKHAUs.AsEnumerable() on nktt.MADINHDANH equals nk.MADINHDANH
                            select new
                            {
                                nk.MADINHDANH,
                                nk.HOTEN,
                                nk.TENKHAC,
                                nk.NGAYSINH,
                                nk.GIOITINH,
                                nk.NOISINH,
                                nk.NGUYENQUAN,
                                nk.DANTOC,
                                nk.TONGIAO,
                                nk.QUOCTICH,
                                nk.HOCHIEU,
                                nk.NOITHUONGTRU,
                                nk.DIACHIHIENNAY,
                                nk.SDT,
                                nk.TRINHDOHOCVAN,
                                nk.TRINHDOCHUYENMON,
                                nk.BIETTIENGDANTOC,
                                nk.TRINHDONGOAINGU,
                                nk.NGHENGHIEP,
                                nktt.MANHANKHAUTAMTRU,
                                nktt.NOITAMTRU,
                                nktt.SOSOTAMTRU,
                                nktt.LYDO,
                                nktt.TUNGAY,
                                nktt.DENNGAY
                            }) as IEnumerable<DataRow>;
            DataTable tbtt = querytht.CopyToDataTable();
            tbtt.TableName = "tamtru";
            dataset.Tables.Add(tbtt);

            return dataset;
        }
    }
}
