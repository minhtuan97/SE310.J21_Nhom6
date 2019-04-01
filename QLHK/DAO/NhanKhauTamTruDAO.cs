﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauTamTruDAO:DBConnection<NhanKhauTamTruDTO>
    {
        public NhanKhauTamTruDAO() : base() { }

        //Lấy tất cả nhân khẩu tạm trú nằm trong 1 sổ tạm trú
        public List<NhanKhauTamTruDTO> getAllNhanKhauTT(string sosotamtru)
        {
            List<NhanKhauTamTruDTO> nktt = new List<NhanKhauTamTruDTO>();

            var query = from nhankhau in qlhk.NHANKHAUs
                        join nhankhautamtru in qlhk.NHANKHAUTAMTRUs on nhankhau.MADINHDANH equals nhankhautamtru.MADINHDANH
                        where nhankhautamtru.SOSOTAMTRU == sosotamtru
                        select new NhanKhauTamTruDTO(nhankhautamtru.MANHAKHAUTAMTRU, nhankhautamtru.NOITAMTRU, 
                        nhankhautamtru.TUNGAY, nhankhautamtru.DENNGAY, nhankhautamtru.LYDO, nhankhautamtru.SOSOTAMTRU, 
                        nhankhau.MADINHDANH, nhankhau.HOTEN, nhankhau.TENKHAC, nhankhau.NGAYSINH, nhankhau.GIOITINH, 
                        nhankhau.NOISINH, nhankhau.NGUYENQUAN, nhankhau.DANTOC, nhankhau.TONGIAO, nhankhau.QUOCTICH, 
                        nhankhau.HOCHIEU, nhankhau.NOITHUONGTRU, nhankhau.DIACHIHIENNAY, nhankhau.SDT, 
                        nhankhau.TRINHDOHOCVAN, nhankhau.TRINHDOCHUYENMON, nhankhau.BIETTIENGDANTOC, 
                        nhankhau.TRINHDONGOAINGU, nhankhau.NGHENGHIEP);
            

            nktt = query.ToList();
            return nktt;
        }


        public override List<NhanKhauTamTruDTO> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTAMTRUs
                     select new NhanKhauTamTruDTO
                     {
                         db = nktt,
                     };
            List<NhanKhauTamTruDTO> lst_NK = kq.ToList();
            return lst_NK;
        }


        public override bool insert(NhanKhauTamTruDTO nktt)
        {

            qlhk.NHANKHAUTAMTRUs.InsertOnSubmit(nktt.db);
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


        public bool XoaNKTT(string madinhdanh)
        {
            try
            {
                //Tìm nhân khẩu tt với mã định danh
                //Cách 1
                //NHANKHAUTAMTRU nk = new NHANKHAUTAMTRU();
                //nk = qlhk.NHANKHAUTAMTRUs.Single(x => x.MADINHDANH == madinhdanh);
                NhanKhauTamTruDTO nktt = new NhanKhauTamTruDTO(qlhk.NHANKHAUTAMTRUs.Single(x => x.MADINHDANH == madinhdanh));
                qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(nktt.db);

                NhanKhauDAO nk = new NhanKhauDAO();
                nk.delete(madinhdanh);

                //TienAnTienSuDTO tienan = new TienAnTienSuDTO(qlhk.TIENANTIENSUs.Single(x => x.MADINHDANH == madinhdanh));
                //qlhk.TIENANTIENSUs.DeleteOnSubmit(tienan.db);

                TieuSuDTO tieusu = new TieuSuDTO(qlhk.TIEUSUs.Single(x => x.MADINHDANH == madinhdanh));
                qlhk.TIEUSUs.DeleteOnSubmit(tieusu.db);

                qlhk.SubmitChanges();
                return true;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }


        public override bool delete(int row)
        {
            try
            {
                List<NhanKhauTamTruDTO> kq = this.getAll();
                NhanKhauTamTruDTO[] arr = kq.ToArray();
                qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(arr[row].db);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool updateNhanKhauTamTru(NhanKhauTamTruDTO nktt)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == nktt.db.MADINHDANH).Select(x=>x);

            //Execute
            foreach(NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = nktt.db.NOITAMTRU;
                NKTT.TUNGAY = nktt.db.TUNGAY;
                NKTT.DENNGAY = nktt.db.DENNGAY;
                NKTT.LYDO = nktt.db.LYDO;
                NKTT.SOSOTAMTRU = nktt.db.SOSOTAMTRU;
            }


            //UPdate thông tin nhân khẩu
            //NhanKhau nhankhau = new NhanKhau(nktt.db.MADINHDANH, nktt.db.HoTen, tenkhac, ngaysinh,
            //    gioitinh, noisinh, nguyenquan, dantoc, tongiao, quoctich, hochieu, noithuongtru,
            //    diachihiennay, sdt, trinhdohocvan, trinhdochuyenmon, biettiengdantoc, trinhdongoaingu, nghenghiep);


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

        public override bool update(NhanKhauTamTruDTO data)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == data.db.MADINHDANH).Select(x => x);

            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = data.db.NOITAMTRU;
                NKTT.TUNGAY = data.db.TUNGAY;
                NKTT.DENNGAY = data.db.DENNGAY;
                NKTT.LYDO = data.db.LYDO;
                NKTT.SOSOTAMTRU = data.db.SOSOTAMTRU;
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



        public List<NhanKhauTamTruDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM nhankhautamtru" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTAMTRU>(query).ToList();
            List<NhanKhauTamTruDTO> lst = new List<NhanKhauTamTruDTO>();
            foreach (NHANKHAUTAMTRU i in res)
            {
                NhanKhauTamTruDTO ts = new NhanKhauTamTruDTO(i);
                lst.Add(ts);
            }

            return lst;

                //string sql = "SELECT  nhankhau.MaDinhDanh, MaNhanKhauTamTru, HoTen,TenKhac,NgaySinh," +
                //    " GioiTinh,NoiSinh,NguyenQuan,DanToc,TonGiao,QuocTich,HoChieu,NoiThuongTru,DiaChiHienNay," +
                //    "SDT,TrinhDoHocVan,TrinhDoChuyenMon,BietTiengDanToc,TrinhDoNgoaiNgu, NgheNghiep, SoSoTamTru,NoiTamTru,TuNgay,DenNgay,LyDo " +
                //    "FROM nhankhautamtru inner join nhankhau " +
                //    "WHERE nhankhautamtru.madinhdanh=nhankhau.madinhdanh and nhankhau.madinhdanh='" + madinhdanh + "'";
        }



        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            qlhk.NHANKHAUTAMTRUs.InsertOnSubmit(data.db);
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



        //Get Data for Tinh Thanh Pho, Quan Huyen, Xa Phuong Thi Tran
        public List<string> GetListTinhThanh()
        {
            List<string> tinhthanh_list = new List<string>();

            //Cách 1
            //var query = from x in qlhk.TINHTHANHPHOs select x;

            //foreach(var tt in query)
            //{
            //    tinhthanh_list.Add(tt.TEN);
            //}


            //Cách 2
            //if (conn.State != ConnectionState.Open)
            //{
            //    conn.Open();
            //}
            //string sql = "SELECT ten FROM tinhthanhpho";
            //MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            //adapter.SelectCommand.CommandType = CommandType.Text;
            //adapter.Fill(dt);

            //tinhthanh_list = dt.AsEnumerable()
            //          .Select(r => r.Field<string>("ten"))
            //          .ToList();

            return tinhthanh_list;
        }


        public List<string> GetListQuanHuyen(string tentinhthanhpho)
        {
            List<string> quanhuyen_list = new List<string>();

            //Tìm ID Quận huyện tương ứng với TỈnh/TP
            List<String> ID_list = new List<string>();
            //var q = from x in qlhk.TINHTHANHPHOs where x.TEN == tentinhthanhpho select x;
            //foreach (var tt in q)
            //{
            //    ID_list.Add(tt.MATP);
            //}
            String ID = ID_list.First();


            //Lấy danh sách QUận Huyện
            //var query = from x in qlhk.QUANHUYENs where x.MATP == ID select x;
            //foreach (var qh in query)
            //{
            //    quanhuyen_list.Add(qh.TEN);
            //}

            return quanhuyen_list;
        }

        public List<string> GetListXaPhuong(string tenquanhuyen)
        {
            List<string> xaphuong_list = new List<string>();

            //Tìm ID xã phường tương ứng với Quận huyện
            List<string> ID_list = new List<string>();
            //var q = from x in qlhk.XAPHUONGTHITRANs where x.ten == tenquanhuyen select x;
            //foreach (var xp in q)
            //{
            //    ID_list.Add(xp.MAQH);
            //}
            //String ID = ID_list.First();


            //Lấy danh sách QUận Huyện
            //var q = from x in qlhk.XAPHUONGs where x.MAQH == ID select x;
            //foreach (var xp in query)
            //{
            //    xaphuong_list.Add(xp.TEN);
            //}

            return xaphuong_list;

        }






        //
        //XỬ LÝ VỚI TIỀN ÁN TIỀN SỰ
        //
        //Lấy tiền án tiền sự với mã định danh
        public List<TienAnTienSuDTO> getTienAnTienSu(string madinhdanh)
        {
            var query = from tienan in qlhk.TIENANTIENSUs select tienan;

            var kq = from tienan in qlhk.TIENANTIENSUs
                     where tienan.MADINHDANH == madinhdanh
                     select new TienAnTienSuDTO
                     {
                         //db = tienan,
                     };
            List<TienAnTienSuDTO> lst_tienan = kq.ToList();
            return lst_tienan;
        }


        //Xóa tiền án với mã tiền án
        public bool DeleteTienAn(string matienan)
        {
            try
            {
                //TienAnTienSuDTO tienan = new TienAnTienSuDTO(qlhk.TIENANTIENSUs.Single(x => x.MATIENANTIENSU == matienan));
                //qlhk.TIENANTIENSUs.DeleteOnSubmit(tienan.db);

                qlhk.SubmitChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }  
        }


        //
        //XỬ LÝ VỚI TIỂU SỬ
        //
        //Lấy tiểu sử với mã định danh
        public List<TieuSuDTO> getTieuSu(string madinhdanh)
        {
            var query = from tieusu in qlhk.TIEUSUs select tieusu;

            var kq = from tieusu in qlhk.TIEUSUs
                     where tieusu.MADINHDANH == madinhdanh
                     select new TieuSuDTO
                     {
                         //db = tienan,
                     };
            List<TieuSuDTO> lst_tieusu = kq.ToList();
            return lst_tieusu; 
        }


        //Xóa tiểu sử với mã tiểu sử
        public bool DeleteTieuSu(string matieusu)
        {

            try
            {
                TieuSuDTO tieusu = new TieuSuDTO(qlhk.TIEUSUs.Single(x => x.MATIEUSU == matieusu));
                qlhk.TIEUSUs.DeleteOnSubmit(tieusu.db);

                qlhk.SubmitChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }




        //GIA HẠN TẠM TRÚ

        //Tìm ngày hết hạn sổ tạm trú (do người dùng đăng ký)
        public DateTime ThoiHanSoTamTru(string madinhdanh)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.MADINHDANH == madinhdanh select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.DENNGAY);
            }
            date = Date_list.First();
            return date;
        }


        public DateTime NgayDangKyTamTru(string madinhdanh)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.MADINHDANH == madinhdanh select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.TUNGAY);
            }
            date = Date_list.First();
            return date;
        }


        public bool InsertGiaHan(string madinhdanh, DateTime thoigian)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == madinhdanh).Select(x => x);

            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.DENNGAY = thoigian;
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


    }

}
