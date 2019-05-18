using System;
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



            return nktt;
        }


        public override List<NhanKhauTamTruDTO> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTAMTRUs
                     select new NhanKhauTamTruDTO
                     {
                         dbnktamtru = nktt,
                     };
            List<NhanKhauTamTruDTO> lst_NK = kq.ToList();
            return lst_NK;
        }


        public override bool insert(NhanKhauTamTruDTO data)
        {
            if (!String.IsNullOrEmpty(data.db.MADINHDANH))
            {
                qlhk.NHANKHAUs.Add(data.db);
                qlhk.SaveChanges();
            }
            if (!String.IsNullOrEmpty(data.dbnktamtru.MADINHDANH))
            {
                qlhk.NHANKHAUTAMTRUs.Add(data.dbnktamtru);
                qlhk.SaveChanges();
            }


            try
            {
                qlhk.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }

        }


        public bool XoaNKTT(string madinhdanh)
        {
            try
            {

                //Xoa nhan khau tam tru
                NhanKhauTamTruDTO nktt = new NhanKhauTamTruDTO(qlhk.NHANKHAUTAMTRUs.Single(x => x.MADINHDANH == madinhdanh));
                qlhk.NHANKHAUTAMTRUs.Remove(nktt.dbnktamtru);

                qlhk.SaveChanges();
                return true;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool deletenktt(string id)
        {
            var kq =
           from nktt in qlhk.NHANKHAUTAMTRUs
           where nktt.MANHAKHAUTAMTRU == id
           select nktt;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUTAMTRUs.Remove(detail);
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
            try
            {
                List<NhanKhauTamTruDTO> kq = this.getAll();
                NhanKhauTamTruDTO[] arr = kq.ToArray();
 //               qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(arr[row].db);
                qlhk.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool updatenktt(NhanKhauTamTruDTO nktt)
        {
            // Query the database for the row to be updated.
            var query = qlhk.NHANKHAUTAMTRUs.Where(q => q.MANHAKHAUTAMTRU == nktt.dbnktamtru.MANHAKHAUTAMTRU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (NHANKHAUTAMTRU kq in query)
            {
                kq.MANHAKHAUTAMTRU = nktt.dbnktamtru.MANHAKHAUTAMTRU;
                kq.MADINHDANH = nktt.dbnktamtru.MADINHDANH;
                kq.SOSOTAMTRU = nktt.dbnktamtru.SOSOTAMTRU;
                kq.NOITAMTRU = nktt.dbnktamtru.NOITAMTRU;
                kq.TUNGAY = nktt.dbnktamtru.TUNGAY;
                kq.DENNGAY = nktt.dbnktamtru.DENNGAY;
                kq.LYDO = nktt.dbnktamtru.LYDO;
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
                return false;
            }
        }

        public bool updateNhanKhauTamTru(NhanKhauTamTruDTO nktt)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == nktt.db.MADINHDANH).Select(x=>x);
            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = nktt.dbnktamtru.NOITAMTRU;
                NKTT.TUNGAY = nktt.dbnktamtru.TUNGAY;
                NKTT.DENNGAY = nktt.dbnktamtru.DENNGAY;
                NKTT.LYDO = nktt.dbnktamtru.LYDO;
                NKTT.SOSOTAMTRU = nktt.dbnktamtru.SOSOTAMTRU;
            }


            var query1 = qlhk.NHANKHAUs.Where(x => x.MADINHDANH == nktt.db.MADINHDANH).Select(x => x);
            foreach (NHANKHAU NK in query1)
            {
                NK.HOTEN = nktt.db.HOTEN;
                NK.TENKHAC = nktt.db.TENKHAC;
                NK.NGAYSINH = nktt.db.NGAYSINH;
                NK.GIOITINH = nktt.db.GIOITINH;
                NK.NOISINH = nktt.db.NOISINH;
                NK.NGUYENQUAN = nktt.db.NGUYENQUAN;
                NK.DANTOC = nktt.db.DANTOC;
                NK.TONGIAO = nktt.db.TONGIAO;
                NK.QUOCTICH = nktt.db.QUOCTICH;
                NK.HOCHIEU = nktt.db.HOCHIEU;
                NK.NOITHUONGTRU = nktt.db.NOITHUONGTRU;
                NK.DIACHIHIENNAY = nktt.db.DIACHIHIENNAY;
                NK.SDT = nktt.db.SDT;
                NK.TRINHDOHOCVAN = nktt.db.TRINHDOHOCVAN;
                NK.TRINHDOCHUYENMON = nktt.db.TRINHDOCHUYENMON;
                NK.BIETTIENGDANTOC = nktt.db.BIETTIENGDANTOC;
                NK.TRINHDONGOAINGU = nktt.db.TRINHDONGOAINGU;
                NK.NGHENGHIEP = nktt.db.NGHENGHIEP;
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
            }

           
        }

        public override bool update(NhanKhauTamTruDTO data)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == data.db.MADINHDANH).Select(x => x);

            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = data.dbnktamtru.NOITAMTRU;
                NKTT.TUNGAY = data.dbnktamtru.TUNGAY;
                NKTT.DENNGAY = data.dbnktamtru.DENNGAY;
                NKTT.LYDO = data.dbnktamtru.LYDO;
                NKTT.SOSOTAMTRU = data.dbnktamtru.SOSOTAMTRU;
            }


            try
            {
                qlhk.SaveChanges();
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
            query = "SELECT * FROM nhankhautamtru" + query;
            var res = qlhk.Database.SqlQuery<NHANKHAUTAMTRU>(query).ToList();
            List<NhanKhauTamTruDTO> lst = new List<NhanKhauTamTruDTO>();
            foreach (NHANKHAUTAMTRU i in res)
            {
                NhanKhauTamTruDTO ts = new NhanKhauTamTruDTO(i);
                lst.Add(ts);
            }

            return lst;
        }



        public List<NhanKhauTamTruDTO> TimKiemNKTT(string madinhdanh)
        {
            String query = "SELECT * FROM nhankhautamtru, nhankhau where nhankhau.madinhdanh=nhankhautamtru.madinhdanh and nhankhau.madinhdanh=" + madinhdanh;
            var res = qlhk.Database.SqlQuery<NHANKHAUTAMTRU>(query).ToList();
            List<NhanKhauTamTruDTO> lst = new List<NhanKhauTamTruDTO>();
            foreach (NHANKHAUTAMTRU i in res)
            {
                NhanKhauTamTruDTO ts = new NhanKhauTamTruDTO(i);
                lst.Add(ts);
            }
            return lst;
        }



        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            qlhk.NHANKHAUTAMTRUs.Add(data.dbnktamtru);
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
                         db = tienan,
                     };
            List<TienAnTienSuDTO> lst_tienan = kq.ToList();
            return lst_tienan;
        }


        //Xóa tiền án với mã tiền án
        public bool DeleteTienAn(string matienan)
        {
            try
            {
                TienAnTienSuDTO tienan = new TienAnTienSuDTO(qlhk.TIENANTIENSUs.Single(x => x.MATIENANTIENSU == matienan));
                qlhk.TIENANTIENSUs.Remove(tienan.db);

                qlhk.SaveChanges();
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
                         db = tieusu,
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
                qlhk.TIEUSUs.Remove(tieusu.db);

                qlhk.SaveChanges();
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
            date = Date_list[0];
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
                qlhk.SaveChanges();
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
