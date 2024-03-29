﻿//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauThuongTruDAO:DBConnection<NhanKhauThuongTruDTO>
    {
        public NhanKhauThuongTruDAO() : base() { }

        public override List<NhanKhauThuongTruDTO> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTHUONGTRUs
                        select new NhanKhauThuongTruDTO {
                            dbnktt=nktt
                        };

            return kq.ToList();

        }

        public List<NhanKhauThuongTruDTO> getAllJoinNhanKhau()
        {
            var kq = from nktt in qlhk.NHANKHAUTHUONGTRUs
                     join nk in qlhk.NHANKHAUs on nktt.MADINHDANH equals nk.MADINHDANH
                     select new NhanKhauThuongTruDTO
                     {
                         db = nk,
                         dbnktt = nktt
                     };

            return kq.ToList();
        }
        public override bool insert_table(NhanKhauThuongTruDTO data)
        {
            if(!String.IsNullOrEmpty(data.db.MADINHDANH))
                qlhk.NHANKHAUs.Add(data.db);
            if (!String.IsNullOrEmpty(data.dbnktt.MADINHDANH))
                qlhk.NHANKHAUTHUONGTRUs.Add(data.dbnktt);

            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                qlhk.SaveChanges();
                return false;
            }
        }
        public override bool insert(NhanKhauThuongTruDTO data)
        {
            //qlhk.NHANKHAUs.InsertOnSubmit(data.db);
            data.dbnktt.MADINHDANH = data.db.MADINHDANH;
            qlhk.NHANKHAUTHUONGTRUs.Add(data.dbnktt);

            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               // qlhk.SubmitChanges();
                return false;
            }
        }
        public bool XoaNKTT(string maNhanKhauthuongtru)
        {
            var kq = qlhk.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == maNhanKhauthuongtru).SingleOrDefault();

            try
            {
                qlhk.NHANKHAUTHUONGTRUs.Remove(kq);
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool deleteNKTT(string id)
        {
            var kq =
            from nktt in qlhk.NHANKHAUTHUONGTRUs
            where nktt.MANHANKHAUTHUONGTRU == id
            select nktt;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUTHUONGTRUs.Remove(detail);
            }

            try
            {
                qlhk.SaveChanges();
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
            NhanKhauThuongTruDTO[] nktt = this.getAll().ToArray();
            try
            {
                qlhk.NHANKHAUTHUONGTRUs.Remove(nktt[row].dbnktt);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public bool updateTTThuongTru(string manktt, SOHOKHAU shk)
        {
            NHANKHAUTHUONGTRU nk = qlhk.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == manktt).FirstOrDefault();

            //nk.SOHOKHAU = shk;
            nk.SOSOHOKHAU = shk.SOSOHOKHAU;
            nk.DIACHITHUONGTRU = shk.DIACHI;
            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public override bool update(NhanKhauThuongTruDTO nktt) {
            // Query the database for the row to be updated.
            var query = qlhk.NHANKHAUTHUONGTRUs.Where(q => q.MANHANKHAUTHUONGTRU == nktt.dbnktt.MANHANKHAUTHUONGTRU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (NHANKHAUTHUONGTRU kq in query)
            {
                //if (kq.MANHANKHAUTHUONGTRU == nktt.dbnktt.MANHANKHAUTHUONGTRU)
                //{
                if (kq.NHANKHAU.MADINHDANH != nktt.db.MADINHDANH && nktt.db.MADINHDANH != null)
                {
                    if (nktt.dbnktt.NHANKHAU != null) kq.NHANKHAU = nktt.db;
                    kq.MADINHDANH = nktt.db.MADINHDANH;
                }

                kq.DIACHITHUONGTRU = nktt.dbnktt.DIACHITHUONGTRU;
                kq.QUANHEVOICHUHO = nktt.dbnktt.QUANHEVOICHUHO;
                if (kq.SOSOHOKHAU != nktt.dbnktt.SOSOHOKHAU)
                {
                    if (nktt.dbnktt.SOHOKHAU != null && nktt.dbnktt.SOSOHOKHAU != null) kq.SOHOKHAU = nktt.dbnktt.SOHOKHAU;
                    kq.SOSOHOKHAU = nktt.dbnktt.SOSOHOKHAU;
                }

                //    break;
                //}

                // Insert any additional changes to column values.
            }
            // Submit the changes to the database.
            try
            {
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return true;
            }

        }




        //public bool doiChuHo(List<NhanKhauThuongTruDTO> danhSach, string maDinhDanhChuHo)
        //{
        //    bool contain = false;
        //    foreach (NhanKhauThuongTruDTO item in danhSach)
        //    {
        //        if (item.MaDinhDanh == maDinhDanhChuHo)
        //        {
        //            contain = true;
        //            break;
        //        }
        //        //else
        //        //{
        //        //    item.LaChuHo = false;
        //        //}
        //    }
        //    if (!contain) return false;

        //    foreach (NhanKhauThuongTruDTO item in danhSach)
        //    {
        //        item.maChuHo = maDinhDanhChuHo;

        //        try
        //        {
        //            update(item, -1);
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }

        //    }

        //    return true;

        //}
        public List<NhanKhauThuongTruDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM NHANKHAUTHUONGTRU" + query;
            var res = qlhk.Database.SqlQuery<NHANKHAUTHUONGTRU>(query).ToList();
            List<NhanKhauThuongTruDTO> lst = new List<NhanKhauThuongTruDTO>();
            foreach (NHANKHAUTHUONGTRU i in res)
            {
                NhanKhauThuongTruDTO ts = new NhanKhauThuongTruDTO(i);
                lst.Add(ts);
            }

            return lst;
        }

        public List<NhanKhauThuongTruDTO> TimKiemJoinNhanKhau(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " AND " + query;
            query = "SELECT * FROM nhankhauthuongtru, nhankhau where nhankhau.madinhdanh=nhankhauthuongtru.madinhdanh" + query;
            var res = qlhk.Database.SqlQuery<NHANKHAUTHUONGTRU>(query);
            List<NhanKhauThuongTruDTO> lst = new List<NhanKhauThuongTruDTO>();
            foreach (NHANKHAUTHUONGTRU i in res)
            {
                NhanKhauThuongTruDTO ts = new NhanKhauThuongTruDTO(i);
                lst.Add(ts);
            }

            return lst;
        }
    }
    
}
