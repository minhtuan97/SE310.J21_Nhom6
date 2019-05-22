using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauTamTruDAO:DBConnection<NHANKHAUTAMTRU>
    {
        public NhanKhauTamTruDAO() : base() { }

        //Lấy tất cả nhân khẩu tạm trú nằm trong 1 sổ tạm trú
        public List<NHANKHAUTAMTRU> getAllNhanKhauTT(string sosotamtru)
        {
            List<NHANKHAUTAMTRU> nktt = new List<NHANKHAUTAMTRU>();

            var query = from nhankhau in qlhk.NHANKHAUs
                        join nhankhautamtru in qlhk.NHANKHAUTAMTRUs on nhankhau.MADINHDANH equals nhankhautamtru.MADINHDANH
                        where nhankhautamtru.SOSOTAMTRU == sosotamtru
                        //select new NHANKHAUTAMTRU(nhankhautamtru.MANHANKHAUTAMTRU, nhankhautamtru.NOITAMTRU, 
                        //nhankhautamtru.TUNGAY, nhankhautamtru.DENNGAY, nhankhautamtru.LYDO, nhankhautamtru.SOSOTAMTRU, 
                        //nhankhau.MADINHDANH, nhankhau.HOTEN, nhankhau.TENKHAC, nhankhau.NGAYSINH, nhankhau.GIOITINH, 
                        //nhankhau.NOISINH, nhankhau.NGUYENQUAN, nhankhau.DANTOC, nhankhau.TONGIAO, nhankhau.QUOCTICH, 
                        //nhankhau.HOCHIEU, nhankhau.NOITHUONGTRU, nhankhau.DIACHIHIENNAY, nhankhau.SDT, 
                        //nhankhau.TRINHDOHOCVAN, nhankhau.TRINHDOCHUYENMON, nhankhau.BIETTIENGDANTOC, 
                        //nhankhau.TRINHDONGOAINGU, nhankhau.NGHENGHIEP);
                        select nhankhautamtru;
            

            nktt = query.ToList();
            return nktt;
        }


        public override List<NHANKHAUTAMTRU> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTAMTRUs
                     select nktt;
            List<NHANKHAUTAMTRU> lst_NK = kq.ToList();
            return lst_NK;
        }


        public override bool insert(NHANKHAUTAMTRU data)
        {
            if (!String.IsNullOrEmpty(data.NHANKHAU.MADINHDANH))
            {
                qlhk.NHANKHAUs.InsertOnSubmit(data.NHANKHAU);
            }
            if (!String.IsNullOrEmpty(data.MADINHDANH))
            {
                qlhk.NHANKHAUTAMTRUs.InsertOnSubmit(data);
            }

            try
            {
                qlhk.SubmitChanges();
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

                //Xoa tieu su
                List<String> listMaTieuSu = new List<string>();
                listMaTieuSu = qlhk.TIEUSUs.Where(x => x.MADINHDANH == madinhdanh).Select(x=>x.MATIEUSU).ToList();

                for(int i=0; i<listMaTieuSu.Count; i++)
                {
                    TIEUSU tieusu = qlhk.TIEUSUs.Single(x => x.MATIEUSU == listMaTieuSu[i]);
                    qlhk.TIEUSUs.DeleteOnSubmit(tieusu);
                }

                qlhk.SubmitChanges();

                //Xoa tien an tien su
                List<String> listMaTienan = new List<string>();
                listMaTienan = qlhk.TIENANTIENSUs.Where(x => x.MADINHDANH == madinhdanh).Select(x => x.MATIENANTIENSU).ToList();

                for (int i = 0; i < listMaTieuSu.Count; i++)
                {
                    TIENANTIENSU tienan = qlhk.TIENANTIENSUs.Single(x => x.MATIENANTIENSU == listMaTienan[i]);
                    qlhk.TIENANTIENSUs.DeleteOnSubmit(tienan);
                }
                qlhk.SubmitChanges();

                //Xoa nhan khau tam tru
                NHANKHAUTAMTRU nktt = qlhk.NHANKHAUTAMTRUs.Single(x => x.MADINHDANH == madinhdanh);
                qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(nktt);

                qlhk.SubmitChanges();

                NhanKhauDAO nk= new NhanKhauDAO();
                nk.delete(madinhdanh);

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
           where nktt.MANHANKHAUTAMTRU == id
           select nktt;

            foreach (var detail in kq)
            {
                qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(detail);
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
                List<NHANKHAUTAMTRU> kq = this.getAll();
                NHANKHAUTAMTRU[] arr = kq.ToArray();
 //               qlhk.NHANKHAUTAMTRUs.DeleteOnSubmit(arr[row].db);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool updatenktt(NHANKHAUTAMTRU nktt)
        {
            // Query the database for the row to be updated.
            var query = qlhk.NHANKHAUTAMTRUs.Where(q => q.MANHANKHAUTAMTRU == nktt.MANHANKHAUTAMTRU);

            // Execute the query, and change the column values
            // you want to change.
            foreach (NHANKHAUTAMTRU kq in query)
            {
                kq.MANHANKHAUTAMTRU = nktt.MANHANKHAUTAMTRU;
                kq.MADINHDANH = nktt.MADINHDANH;
                kq.SOSOTAMTRU = nktt.SOSOTAMTRU;
                kq.NOITAMTRU = nktt.NOITAMTRU;
                kq.TUNGAY = nktt.TUNGAY;
                kq.DENNGAY = nktt.DENNGAY;
                kq.LYDO = nktt.LYDO;
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

        public bool updateNhanKhauTamTru(NHANKHAUTAMTRU nktt)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == nktt.NHANKHAU.MADINHDANH).Select(x=>x);
            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = nktt.NOITAMTRU;
                NKTT.TUNGAY = nktt.TUNGAY;
                NKTT.DENNGAY = nktt.DENNGAY;
                NKTT.LYDO = nktt.LYDO;
                NKTT.SOSOTAMTRU = nktt.SOSOTAMTRU;
            }


            var query1 = qlhk.NHANKHAUs.Where(x => x.MADINHDANH == nktt.NHANKHAU.MADINHDANH).Select(x => x);
            foreach (NHANKHAU NK in query1)
            {
                NK.HOTEN = nktt.NHANKHAU.HOTEN;
                NK.TENKHAC = nktt.NHANKHAU.TENKHAC;
                NK.NGAYSINH = nktt.NHANKHAU.NGAYSINH;
                NK.GIOITINH = nktt.NHANKHAU.GIOITINH;
                NK.NOISINH = nktt.NHANKHAU.NOISINH;
                NK.NGUYENQUAN = nktt.NHANKHAU.NGUYENQUAN;
                NK.DANTOC = nktt.NHANKHAU.DANTOC;
                NK.TONGIAO = nktt.NHANKHAU.TONGIAO;
                NK.QUOCTICH = nktt.NHANKHAU.QUOCTICH;
                NK.HOCHIEU = nktt.NHANKHAU.HOCHIEU;
                NK.NOITHUONGTRU = nktt.NHANKHAU.NOITHUONGTRU;
                NK.DIACHIHIENNAY = nktt.NHANKHAU.DIACHIHIENNAY;
                NK.SDT = nktt.NHANKHAU.SDT;
                NK.TRINHDOHOCVAN = nktt.NHANKHAU.TRINHDOHOCVAN;
                NK.TRINHDOCHUYENMON = nktt.NHANKHAU.TRINHDOCHUYENMON;
                NK.BIETTIENGDANTOC = nktt.NHANKHAU.BIETTIENGDANTOC;
                NK.TRINHDONGOAINGU = nktt.NHANKHAU.TRINHDONGOAINGU;
                NK.NGHENGHIEP = nktt.NHANKHAU.NGHENGHIEP;
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
            }

           
        }

        public override bool update(NHANKHAUTAMTRU data)
        {
            //Query
            var query = qlhk.NHANKHAUTAMTRUs.Where(x => x.MADINHDANH == data.NHANKHAU.MADINHDANH).Select(x => x);

            //Execute
            foreach (NHANKHAUTAMTRU NKTT in query)
            {
                NKTT.NOITAMTRU = data.NOITAMTRU;
                NKTT.TUNGAY = data.TUNGAY;
                NKTT.DENNGAY = data.DENNGAY;
                NKTT.LYDO = data.LYDO;
                NKTT.SOSOTAMTRU = data.SOSOTAMTRU;
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



        public List<NHANKHAUTAMTRU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM nhankhautamtru" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTAMTRU>(query).ToList();

            return res;
        }


        public List<NHANKHAUTAMTRU> TimKiemNKTT(string madinhdanh)
        {
            qlhk = new quanlyhokhauDataContext();

            String query = "SELECT * FROM nhankhautamtru where madinhdanh=" + madinhdanh;
            var res = qlhk.ExecuteQuery<NHANKHAUTAMTRU>(query).ToList();

            return res;
        }

        

        public override bool insert_table(NHANKHAUTAMTRU data)
        {
            qlhk.NHANKHAUTAMTRUs.InsertOnSubmit(data);
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








        //
        //XỬ LÝ VỚI TIỀN ÁN TIỀN SỰ
        //
        //Lấy tiền án tiền sự với mã định danh
        public List<TIENANTIENSU> getTienAnTienSu(string madinhdanh)
        {
            var query = from tienan in qlhk.TIENANTIENSUs select tienan;

            var kq = from tienan in qlhk.TIENANTIENSUs
                     where tienan.MADINHDANH == madinhdanh
                     select new TIENANTIENSU
                     {
                         //db = tienan,
                     };
            List<TIENANTIENSU> lst_tienan = kq.ToList();
            return lst_tienan;
        }


        //Xóa tiền án với mã tiền án
        public bool DeleteTienAn(string matienan)
        {
            try
            {
                TIENANTIENSU tienan = qlhk.TIENANTIENSUs.Single(x => x.MATIENANTIENSU == matienan);
                qlhk.TIENANTIENSUs.DeleteOnSubmit(tienan);

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
        public List<TIEUSU> getTieuSu(string madinhdanh)
        {
            var query = from tieusu in qlhk.TIEUSUs select tieusu;

            var kq = from tieusu in qlhk.TIEUSUs
                     where tieusu.MADINHDANH == madinhdanh
                     select new TIEUSU
                     {
                         //db = tienan,
                     };
            List<TIEUSU> lst_tieusu = kq.ToList();
            return lst_tieusu; 
        }


        //Xóa tiểu sử với mã tiểu sử
        public bool DeleteTieuSu(string matieusu)
        {

            try
            {
                TIEUSU tieusu = qlhk.TIEUSUs.Single(x => x.MATIEUSU == matieusu);
                qlhk.TIEUSUs.DeleteOnSubmit(tieusu);

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
