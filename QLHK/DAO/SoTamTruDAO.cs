using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SoTamTruDAO:DBConnection<SoTamTruDTO>
    {
        public SoTamTruDAO() : base() { }

        public override List<SoTamTruDTO> getAll()
        {
            var kq = from stt in qlhk.SOTAMTRUs
                     select new SoTamTruDTO
                     {
                         db = stt,
                     };
                List<SoTamTruDTO> lst = kq.ToList();
                return lst;
        }


        public List<SoTamTruDTO> getAllSoTamTru()
        {
            var kq = from stt in qlhk.SOTAMTRUs
                     select new SoTamTruDTO
                     {
                         db = stt,
                     };
            List<SoTamTruDTO> lst = kq.ToList();
            return lst;
        }


        public override bool insert(SoTamTruDTO sotamtru)
        {

            qlhk.SOTAMTRUs.InsertOnSubmit(sotamtru.db);
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
                SoTamTruDTO stt = new SoTamTruDTO(qlhk.SOTAMTRUs.Single(x => x.SOSOTAMTRU == sosotamtru));
                qlhk.SOTAMTRUs.DeleteOnSubmit(stt.db);


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

        public override bool delete(int row)
        {
            try
            {
                List<SoTamTruDTO> kq = this.getAll();
                SoTamTruDTO[] arr = kq.ToArray();
                qlhk.SOTAMTRUs.DeleteOnSubmit(arr[row].db);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(SoTamTruDTO sotamtru)
        {
            List<SOTAMTRU> query = qlhk.SOTAMTRUs.Where(x => x.SOSOTAMTRU == sotamtru.db.SOSOTAMTRU).Select(x => x).ToList();

            //Execute
            foreach (SOTAMTRU stt in query)
            {
                stt.MACHUHO = sotamtru.db.MACHUHO;
                stt.NOITAMTRU = sotamtru.db.NOITAMTRU;
                stt.NGAYCAP = sotamtru.db.NGAYCAP;
                stt.DENNGAY = sotamtru.db.DENNGAY;
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


        public List<SoTamTruDTO> TimKiem(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM sotamtru" + query;
            var res = qlhk.ExecuteQuery<SOTAMTRU>(query).ToList();
            List<SoTamTruDTO> lst = new List<SoTamTruDTO>();
            foreach (SOTAMTRU i in res)
            {
                SoTamTruDTO ts = new SoTamTruDTO(i);
                lst.Add(ts);
            }

            return lst;
         
        }




        public override bool insert_table(SoTamTruDTO data)
        {
            qlhk.SOTAMTRUs.InsertOnSubmit(data.db);
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


        //Lấy thông tin của Chỗ ở trong bảng thành phố, quận huyện, xã phường thị trấn

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

                var q = from nhankhautamtru in qlhk.NHANKHAUTAMTRUs
                        join nhankhau in qlhk.NHANKHAUs
                        on nhankhautamtru.MADINHDANH equals nhankhau.MADINHDANH
                        where nhankhautamtru.SOSOTAMTRU == sosotamtru
                        select nhankhau;

                foreach (var tt in q)
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
