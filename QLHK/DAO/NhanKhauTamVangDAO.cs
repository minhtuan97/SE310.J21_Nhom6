using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanKhauTamVangDAO : DBConnection<NhanKhauTamVangDTO>
    {
        public NhanKhauTamVangDAO() : base() { }

        public override bool delete(int row)
        {
            try
            {
                List<NhanKhauTamVangDTO> kq = this.getAll();
                NhanKhauTamVangDTO[] arr = kq.ToArray();
                qlhk.NHANKHAUTAMVANGs.DeleteOnSubmit(arr[row].db);
                qlhk.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override List<NhanKhauTamVangDTO> getAll()
        {
            var kq = from nktt in qlhk.NHANKHAUTAMVANGs
                     select new NhanKhauTamVangDTO
                     {
                         db = nktt,
                     };
            List<NhanKhauTamVangDTO> lst_NK = kq.ToList();
            return lst_NK; 
        }

        public override bool insert(NhanKhauTamVangDTO data)
        {
            qlhk.NHANKHAUTAMVANGs.InsertOnSubmit(data.db);
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



        public override bool insert_table(NhanKhauTamVangDTO data)
        {
            qlhk.NHANKHAUTAMVANGs.InsertOnSubmit(data.db);
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

        public override bool update(NhanKhauTamVangDTO data)
        {
            //Query
            var query = qlhk.NHANKHAUTAMVANGs.Where(x => x.MANHANKHAUTAMVANG == data.db.MANHANKHAUTAMVANG).Select(x => x);

            //Execute
            foreach (NHANKHAUTAMVANG NKTV in query)
            {
                NKTV.NGAYBATDAUTAMVANG = data.db.NGAYBATDAUTAMVANG;
                NKTV.NGAYKETTHUCTAMVANG = data.db.NGAYKETTHUCTAMVANG;
                NKTV.LYDO = data.db.LYDO;
                NKTV.NOIDEN = data.db.NOIDEN;
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


        public DataSet TimKiemJoinNhanKhau(string query)
        {
            //try
            //{
            //    List < NhanKhauTamVangDTO >


            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Open();
            //    }
            //    sqlda = new MySqlDataAdapter("SELECT * FROM nhankhau left join nhankhautamvang " +
            //        "on nhankhau.madinhdanh=nhankhautamvang.madinhdanh" + query + " ORDER BY ngayketthuctamvang DESC", conn);
            //    cmdbuilder = new MySqlCommandBuilder(sqlda);
            //    dataset = new DataSet();
            //    sqlda.Fill(dataset, "timkiem");
            //    return dataset;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}
            return null;
        }


        public List<NhanKhauTamVangDTO> TimKiemNhanKhau(string query)
        {
            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT *, 'Delete' as 'Change' FROM nhankhautamvang" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTAMVANG>(query).ToList();
            List<NhanKhauTamVangDTO> lst = new List<NhanKhauTamVangDTO>();
            foreach (NHANKHAUTAMVANG i in res)
            {
                NhanKhauTamVangDTO ts = new NhanKhauTamVangDTO(i);
                lst.Add(ts);
            }

            return lst;
        }


        public int TimKiemThuongtru(string query)
        {

            if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
            query = "SELECT * FROM nhankhauthuongtru" + query;
            var res = qlhk.ExecuteQuery<NHANKHAUTHUONGTRU>(query).ToList();
            List<NhanKhauThuongTruDTO> lst = new List<NhanKhauThuongTruDTO>();
            foreach (NHANKHAUTHUONGTRU i in res)
            {
                //NhanKhauThuongTruDTO ts = new NhanKhauThuongTruDTO(i);
                //lst.Add(ts);
            }

            if (lst.Count() > 0)
                return 0;
            if (lst.Count() == 0)
                return 1;
            return -1;
        }




    }
}
