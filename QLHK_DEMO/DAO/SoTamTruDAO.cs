using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SoTamTruDAO:DBConnection<SOTAMTRU>
    {
        public SoTamTruDAO() : base() { }

        public override List<SOTAMTRU> getAll()
        {
            var kq = from stt in qlhk.SOTAMTRUs
                     select stt;
                List<SOTAMTRU> lst = kq.ToList();
                return lst;
        }


        public List<SOTAMTRU> getAllSoTamTru()
        {
            var kq = from stt in qlhk.SOTAMTRUs
                     select stt;
            List<SOTAMTRU> lst = kq.ToList();
            return lst;
        }


        public override bool insert(SOTAMTRU sotamtru)
        {

            qlhk.SOTAMTRUs.InsertOnSubmit(sotamtru);
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


        /// <summary>
        /// Lấy mã định danh
        /// </summary>
        /// <param name="sosotamtru"></param>
        /// <returns></returns>
        public List<string> getListMaDinhDanhBySoSoTamTru(string sosotamtru)
        {
            List<string> ID_list = new List<string>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.SOSOTAMTRU == sosotamtru select x;
            foreach (var tt in q)
            {
                ID_list.Add(tt.MADINHDANH);
            }         
            return ID_list;
        }

        public List<string> getListExperiedSoTamTru()
        {
            List<string> sosotamtru_list = new List<string>();
            var q = from x in qlhk.SOTAMTRUs where x.DENNGAY<DateTime.Today select x;
            foreach (var tt in q)
            {
                sosotamtru_list.Add(tt.SOSOTAMTRU);
            }
            return sosotamtru_list;
        }


        public bool XoaSoTamTru(string sosotamtru)
        {
            try
            {
                SOTAMTRU stt = qlhk.SOTAMTRUs.Single(x => x.SOSOTAMTRU == sosotamtru);
                qlhk.SOTAMTRUs.DeleteOnSubmit(stt);


                //Xóa nhân khẩu 
                NhanKhauTamTruDAO nhankhautamtruDao = new NhanKhauTamTruDAO();
                List<string> madinhdanh_list = getListMaDinhDanhBySoSoTamTru(sosotamtru);

                //Xóa nhân khẩu tạm trú trong sổ tạm trú
                for (int i = 0; i < madinhdanh_list.Count; i++)
                {
                    nhankhautamtruDao.XoaNKTT(madinhdanh_list[i]);
                }


                qlhk.SubmitChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }



        public bool DeleteExperiedSoTamTru()
        {
                try
                {
                     //Lấy list số sổ tạm trú quá hạn
                    List<string> sosotamtru_list = getListExperiedSoTamTru();

                    //Xóa list số tạm trú quá hạn
                    for (int i = 0; i < sosotamtru_list.Count; i++)
                    {
                            XoaSoTamTru(sosotamtru_list[i]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            return true;
        }

        public bool deleteSTT(string id)
        {
            var kq =
            from stt in qlhk.SOTAMTRUs
            where stt.SOSOTAMTRU == id
            select stt;

            foreach (var detail in kq)
            {
                qlhk.SOTAMTRUs.DeleteOnSubmit(detail);
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
                List<SOTAMTRU> kq = this.getAll();
                SOTAMTRU[] arr = kq.ToArray();
                qlhk.SOTAMTRUs.DeleteOnSubmit(arr[row]);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(SOTAMTRU sotamtru)
        {
            List<SOTAMTRU> query = qlhk.SOTAMTRUs.Where(x => x.SOSOTAMTRU == sotamtru.SOSOTAMTRU).Select(x => x).ToList();

            //Execute
            foreach (SOTAMTRU stt in query)
            {
                stt.MACHUHO = sotamtru.MACHUHO;
                stt.NOITAMTRU = sotamtru.NOITAMTRU;
                stt.NGAYCAP = sotamtru.NGAYCAP;
                stt.DENNGAY = sotamtru.DENNGAY;
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


        public List<SOTAMTRU> TimKiem(string query)
        {
            qlhk = new quanlyhokhauDataContext();

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM sotamtru" + query;
            var res = qlhk.ExecuteQuery<SOTAMTRU>(query).ToList();
            
            return res;
        }


        public List<SOTAMTRU> TimKiemSoTamTru(string sosotamtru)
        {
            qlhk = new quanlyhokhauDataContext();
            //string query = "SELECT * FROM sotamtru where sosotamtru=" + sosotamtru;
            var res = qlhk.SOTAMTRUs.Where(q=>q.SOSOTAMTRU==sosotamtru).ToList();

            return res;
        }
        



        public override bool insert_table(SOTAMTRU data)
        {
            qlhk.SOTAMTRUs.InsertOnSubmit(data);
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






        /// <summary>
        /// Lấy danh sách tên nhân khẩu trong sổ tạm trú
        /// </summary>
        /// <param name="sosotamtru"></param>
        /// <returns></returns>
        public List<string> ImportToComboboxMaChuHo(string sosotamtru)
        {
            List<string> list_tennhankhau = new List<string>();

            var q = from nhankhau in qlhk.NHANKHAUs join nhankhautamtru in qlhk.NHANKHAUTAMTRUs
                    on nhankhau.MADINHDANH equals nhankhautamtru.MADINHDANH
                    where nhankhautamtru.SOSOTAMTRU == sosotamtru select nhankhau;

            foreach (var tt in q)
            {
                list_tennhankhau.Add(tt.HOTEN);
            }         
            return list_tennhankhau;
        }


        public string convertTentoMaNhanKhauTamTru(string tennhankhau, string sosotamtru)
        {
            try
            {
                List<string> list_ID = new List<string>();

                var q = from nhankhautamtru in qlhk.NHANKHAUTAMTRUs
                        join nhankhau in qlhk.NHANKHAUs
                        on nhankhautamtru.MADINHDANH equals nhankhau.MADINHDANH
                        where nhankhautamtru.SOSOTAMTRU == sosotamtru && nhankhau.HOTEN == tennhankhau
                        select nhankhautamtru;

                foreach (var tt in q)
                {
                    list_ID.Add(tt.MANHANKHAUTAMTRU);
                }

                return list_ID.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        public string FindMaChuHo(string sosotamtru)
        {
            try
            {
                List<string> list_ID = new List<string>();

                var q = from sotamtru in qlhk.SOTAMTRUs
                        where sotamtru.SOSOTAMTRU == sosotamtru
                        select sotamtru;

                foreach (var tt in q)
                {
                    list_ID.Add(tt.MACHUHO);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        public string FindTenChuHoTamTru(string sosotamtru)
        {
            try
            {
                List<string> list_Ten = new List<string>();

                var p = from nhankhautamtru in qlhk.NHANKHAUTAMTRUs
                        join nhankhau in qlhk.NHANKHAUs
                        on nhankhautamtru.MADINHDANH equals nhankhau.MADINHDANH
                        join sotamtru in qlhk.SOTAMTRUs
                        on nhankhautamtru.MANHANKHAUTAMTRU equals sotamtru.MACHUHO
                        where sotamtru.SOSOTAMTRU == sosotamtru
                        select nhankhau;

                foreach (var tt in p)
                {
                    list_Ten.Add(tt.HOTEN);
                }

                return list_Ten.First();             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }


        //KIểm tra tồn tại
        public int Existed_SoTamTru(string sosotamtru)
        {
            List<string> lst = new List<string>();

            var query = from stt in qlhk.SOTAMTRUs where stt.SOSOTAMTRU == sosotamtru select stt;

            foreach(SOTAMTRU q in query)
            {
                lst.Add(q.SOSOTAMTRU.ToString());
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }

        public int Existed_NhanKhau(string madinhdanh)
        {
            List<String> lst = new List<String>();

            var query = from nk in qlhk.NHANKHAUs where nk.MADINHDANH == madinhdanh select nk;

            foreach (NHANKHAU q in query)
            {
                lst.Add(q.MADINHDANH);
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }

        public int Existed_NhanKhauTamTru(string manhankhautamtru)
        {
            List<String> lst = new List<String>();

            var query = from nk in qlhk.NHANKHAUTAMTRUs where nk.MANHANKHAUTAMTRU == manhankhautamtru select nk;

            foreach (NHANKHAUTAMTRU q in query)
            {
                lst.Add(q.MANHANKHAUTAMTRU);
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }


        public int Duplicated_NhanKhauTamTru(string manhankhautamtru, string sosotamtru)
        {
            List<String> lst = new List<String>();

            var query = from nhankhautamtru in qlhk.NHANKHAUTAMTRUs join sotamtru in qlhk.SOTAMTRUs 
                        on nhankhautamtru.SOSOTAMTRU equals sotamtru.SOSOTAMTRU
                        where nhankhautamtru.MANHANKHAUTAMTRU == manhankhautamtru && sotamtru.SOSOTAMTRU == sosotamtru
                        select nhankhautamtru;

            foreach (NHANKHAUTAMTRU q in query)
            {
                lst.Add(q.MANHANKHAUTAMTRU);
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }


        public int Existed_TieuSu(string matieusu)
        {
            List<String> lst = new List<String>();

            var query = from nk in qlhk.TIEUSUs where nk.MATIEUSU == matieusu select nk;

            foreach (TIEUSU q in query)
            {
                lst.Add(q.MATIEUSU);
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }

        public int Existed_TienAn(string matienan)
        {
            List<String> lst = new List<String>();

            var query = from nk in qlhk.TIENANTIENSUs where nk.MATIENANTIENSU == matienan select nk;

            foreach (TIENANTIENSU q in query)
            {
                lst.Add(q.MATIENANTIENSU);
            }

            if (lst.Count() > 0)
            {
                return lst.Count();
            }
            else return 0;
        }

        //GIA HẠN


        public DateTime ThoiHanSoTamTru(string sosotamtru)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.SOTAMTRUs where x.SOSOTAMTRU == sosotamtru select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.DENNGAY);
            }
            date = Date_list.First();
            return date;
        }


        public DateTime NgayDangKyTamTru(string sosotamtru)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.SOTAMTRUs where x.SOSOTAMTRU == sosotamtru select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.NGAYCAP);
            }
            date = Date_list.First();
            return date;
        }


        public DateTime getTuNgay(string manhankhautamtru)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.MANHANKHAUTAMTRU == manhankhautamtru select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.TUNGAY);
            }
            date = Date_list.First();
            return date;
        }

        public DateTime getDenNgay(string manhankhautamtru)
        {
            DateTime date = new DateTime(12 / 12 / 1800);
            List<DateTime> Date_list = new List<DateTime>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.MANHANKHAUTAMTRU == manhankhautamtru select x;
            foreach (var xp in q)
            {
                Date_list.Add(xp.DENNGAY);
            }
            date = Date_list.First();
            return date;
        }


        public String getNoiTamTru(string manhankhautamtru)
        {
            List<String> list = new List<String>();
            var q = from x in qlhk.NHANKHAUTAMTRUs where x.MANHANKHAUTAMTRU == manhankhautamtru select x;
            foreach (var xp in q)
            {
                list.Add(xp.NOITAMTRU);
            }
            return list.First();
        }


        public bool InsertGiaHan(string sosotamtru, DateTime thoigian)
        {
            //Query
            var query = qlhk.SOTAMTRUs.Where(x => x.SOSOTAMTRU == sosotamtru).Select(x => x);

            //Execute
            foreach (SOTAMTRU NKTT in query)
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
