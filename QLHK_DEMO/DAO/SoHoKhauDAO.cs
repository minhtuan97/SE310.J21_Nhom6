//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SoHoKhauDAO:DBConnection<SOHOKHAU>
    {
        public SoHoKhauDAO() : base() { }

        public override List<SOHOKHAU> getAll()
        {
            //SOHOKHAU nk = new SOHOKHAU();
            var kq = from shkt in qlhk.SOHOKHAUs
                     select shkt;

            //Lay thong tin nhan khau trong so ho khau
            foreach (SOHOKHAU so in kq)
            {
                so.TenChuHo = qlhk.NHANKHAUs.Where(a => a.MADINHDANH == (
                              qlhk.NHANKHAUTHUONGTRUs.Where(b => b.MANHANKHAUTHUONGTRU == so.MACHUHO)
                              .Select(b1 => b1.MADINHDANH).SingleOrDefault()))
                              .Select(a1 => a1.HOTEN).SingleOrDefault();

                //so.NhanKhau = so.NHANKHAUTHUONGTRUs.ToList();
            }
            List<SOHOKHAU> x = kq.ToList();
            return x;
        }

        public override bool insert_table(SOHOKHAU data)
        {
            qlhk.SOHOKHAUs.InsertOnSubmit(data);
            try
            {
                qlhk.SubmitChanges();
            }
            catch (Exception e)
            {
                error = e;
                qlhk.SubmitChanges();

            }
            return true;
        }
        public override bool insert(SOHOKHAU data)
        {
            qlhk.SOHOKHAUs.InsertOnSubmit(data);

            //foreach (NhanKhauThuongTruDTO item in data.NhanKhau)
            //{
            //    qlhk.NHANKHAUTHUONGTRUs.InsertOnSubmit(item.dbnktt);
            //}
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                qlhk.SubmitChanges();
                return false;
            }

        }
        public bool XoaSoHK(string soSoHoKhau)
        {

            SOHOKHAU[] nktt = this.getAll().ToArray();
            try
            {
                foreach (var item in nktt)
                {
                    if (item.SOSOHOKHAU == soSoHoKhau)
                    {
                        qlhk.SOHOKHAUs.DeleteOnSubmit(item);
                        qlhk.SubmitChanges();
                        break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public bool deleteSHK(string id)
        {
            var kq =
            from shk in qlhk.SOHOKHAUs
            where shk.SOSOHOKHAU == id
            select shk;

            foreach (var detail in kq)
            {
                qlhk.SOHOKHAUs.DeleteOnSubmit(detail);
            }

            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                return false;
                // Provide for exceptions.
            }
        }
        public override bool delete(int row)
        {
            SOHOKHAU[] nktt = this.getAll().ToArray();
            try
            {
                qlhk.SOHOKHAUs.DeleteOnSubmit(nktt[row]);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(SOHOKHAU data)
        {

            // Query the database for the row to be updated.
            var query = qlhk.SOHOKHAUs.Where(q => q.SOSOHOKHAU == data.SOSOHOKHAU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (SOHOKHAU kq in query)
            {
                kq.MACHUHO = data.MACHUHO;
                kq.DIACHI = data.DIACHI;
                kq.NGAYCAP = data.NGAYCAP;
                kq.SODANGKY = data.SODANGKY;
                // Insert any additional changes to column values.
            }
            // Submit the changes to the database.
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                // Provide for exceptions.
                return false;
            }
        }

        public bool update(SOHOKHAU data, EntitySet<NHANKHAUTHUONGTRU> nk)
        {

            // Query the database for the row to be updated.
            var query = qlhk.SOHOKHAUs.Where(q => q.SOSOHOKHAU == data.SOSOHOKHAU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (SOHOKHAU kq in query)
            {
                kq.MACHUHO = data.MACHUHO;
                kq.DIACHI = data.DIACHI;
                kq.NGAYCAP = data.NGAYCAP;
                kq.SODANGKY = data.SODANGKY;
                // Insert any additional changes to column values.
                foreach (var item in nk)
                {
                    
                    if (!kq.NHANKHAUTHUONGTRUs.Any(q=>q.MADINHDANH==item.MADINHDANH))
                    {
                        kq.NHANKHAUTHUONGTRUs.Add(item);
                    }
                    else if (item.SOSOHOKHAU != kq.SOSOHOKHAU || item.DIACHITHUONGTRU != kq.DIACHI)
                    {
                        item.SOSOHOKHAU = kq.SOSOHOKHAU;
                        item.DIACHITHUONGTRU = kq.DIACHI;
                    }
                }
            }
            // Submit the changes to the database.
            try
            {
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                error = e;
                // Provide for exceptions.
                return false;
            }
        }

        public List<SOHOKHAU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM sohokhau" + query;
            var res = qlhk.ExecuteQuery<SOHOKHAU>(query).ToList();

            return res;
            
        }



        /// <summary>
        /// Tự động tạo mã 12 ký tự cho mã định danh
        /// </summary>
        /// <param name="gioitinh"></param>
        /// <param name="namsinh"></param>
        /// <returns></returns>


    }
    
}
