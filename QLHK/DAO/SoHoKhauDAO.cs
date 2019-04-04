//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SoHoKhauDAO:DBConnection<SoHoKhauDTO>
    {
        public SoHoKhauDAO() : base() { }

        public override List<SoHoKhauDTO> getAll()
        {
            //SoHoKhauDTO nk = new SoHoKhauDTO();
            var kq = from shkt in qlhk.SOHOKHAUs
                     select new SoHoKhauDTO
                     {
                         db = shkt,
                         TenChuHo = qlhk.NHANKHAUs.Where(a => a.MADINHDANH == (
                           qlhk.NHANKHAUTHUONGTRUs.Where(b => b.MANHANKHAUTHUONGTRU == shkt.MACHUHO)
                           .Select(b1 => b1.MADINHDANH).SingleOrDefault()))
                           .Select(a1 => a1.HOTEN).SingleOrDefault()
                         //NhanKhau = qlhk.NHANKHAUTHUONGTRUs.Where(nk => nk.SOSOHOKHAU == shkt.SOSOHOKHAU).ToList(),

                     };

            //Lay thong tin nhan khau trong so ho khau
            foreach (SoHoKhauDTO so in kq)
            {
                so.NhanKhau = (from nktt in qlhk.NHANKHAUTHUONGTRUs
                              where nktt.SOSOHOKHAU == so.db.SOSOHOKHAU
                              select new NhanKhauThuongTruDTO
                              {
                                  dbnktt = nktt
                              }).ToList();
            }
            List<SoHoKhauDTO> x = kq.ToList();
            return x;
        }

        public override bool insert_table(SoHoKhauDTO data)
        {
            qlhk.SOHOKHAUs.InsertOnSubmit(data.db);
            try
            {
                qlhk.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SubmitChanges();

            }
            return true;
        }
        public override bool insert(SoHoKhauDTO data)
        {
            qlhk.SOHOKHAUs.InsertOnSubmit(data.db);

            foreach (NhanKhauThuongTruDTO item in data.NhanKhau)
            {
                qlhk.NHANKHAUTHUONGTRUs.InsertOnSubmit(item.dbnktt);
            }
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
        public bool XoaSoHK(string soSoHoKhau)
        {

            SoHoKhauDTO[] nktt = this.getAll().ToArray();
            try
            {
                foreach (var item in nktt)
                {
                    if(item.db.SOSOHOKHAU==soSoHoKhau)
                        qlhk.SOHOKHAUs.DeleteOnSubmit(item.db);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public override bool delete(int row)
        {
            SoHoKhauDTO[] nktt = this.getAll().ToArray();
            try
            {
                qlhk.SOHOKHAUs.DeleteOnSubmit(nktt[row].db);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(SoHoKhauDTO data)
        {

            // Query the database for the row to be updated.
            var query = qlhk.SOHOKHAUs.Where(q => q.SOSOHOKHAU == data.db.SOSOHOKHAU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (SOHOKHAU kq in query)
            {
                kq.MACHUHO = data.db.MACHUHO;
                kq.DIACHI = data.db.DIACHI;
                kq.NGAYCAP = data.db.NGAYCAP;
                kq.SODANGKY = data.db.SODANGKY;
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
                Console.WriteLine(e);
                // Provide for exceptions.
                return false;
            }
        }
        public List<SoHoKhauDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM sohokhau" + query;
            var res = qlhk.ExecuteQuery<SOHOKHAU>(query).ToList();
            List<SoHoKhauDTO> lst = new List<SoHoKhauDTO>();
            foreach (SOHOKHAU i in res)
            {
                SoHoKhauDTO shk = new SoHoKhauDTO(i, qlhk.NHANKHAUs.Where(a => a.MADINHDANH == (
                          qlhk.NHANKHAUTHUONGTRUs.Where(b => b.MANHANKHAUTHUONGTRU == i.MACHUHO)
                          .Select(b1 => b1.MADINHDANH).SingleOrDefault()))
                           .Select(a1 => a1.HOTEN).SingleOrDefault());
                lst.Add(shk);
            }

            return lst;
            
        }



        /// <summary>
        /// Tự động tạo mã 12 ký tự cho mã định danh
        /// </summary>
        /// <param name="gioitinh"></param>
        /// <param name="namsinh"></param>
        /// <returns></returns>


    }
    
}
