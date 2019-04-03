using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
//using MySql.Data.MySqlClient;

namespace DAO
{
    public class TinhThanhPhoDAO:DBConnection<TinhThanhPhoDTO>
    {
        public TinhThanhPhoDAO() : base() { }

        public override List<TinhThanhPhoDTO> getAll()
        {
            TinhThanhPhoDTO nk = new TinhThanhPhoDTO();
            var kq = from quanhuyendto in qlhk.QUANHUYENs
                     select new QuanHuyenDTO
                     {
                         db = quanhuyendto
                     };
            List<QuanHuyenDTO> x = kq.ToList();
            return x;
        }
        public override bool insert_table(TinhThanhPhoDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["tinhthanhpho"].NewRow();
                dr["matp"] = data.MaTP;
                dr["ten"] = data.Ten;
                dr["kieu"] = data.Kieu;
                dataset.Tables["tinhthanhpho"].Rows.Add(dr);
                dataset.Tables["tinhthanhpho"].Rows.RemoveAt(dataset.Tables["tinhthanhpho"].Rows.Count - 1);
                sqlda.Update(dataset, "tinhthanhpho");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public override bool insert(TinhThanhPhoDTO tinhThanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["tinhthanhpho"].NewRow();
                dr["matp"] = tinhThanh.MaTP;
                dr["ten"] = tinhThanh.Ten;
                dr["kieu"] = tinhThanh.Kieu;

                dataset.Tables["tinhthanhpho"].Rows.Add(dr);
                dataset.Tables["v"].Rows.RemoveAt(dataset.Tables["tinhthanhpho"].Rows.Count - 1);
                sqlda.Update(dataset, "tinhthanhpho");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["tinhthanhpho"].Rows[row].Delete();
                sqlda.Update(dataset, "tinhthanhpho");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(TinhThanhPhoDTO tinhThanh, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update tinhthanhpho set ten=@ten, kieu=@kieu where matp =@matp";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matp", tinhThanh.MaTP.ToString());
                cmd.Parameters.AddWithValue("@ten", tinhThanh.Ten.ToString());
                cmd.Parameters.AddWithValue("@kieu", tinhThanh.Kieu.ToString());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataSet TimKiem(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (!String.IsNullOrEmpty(query)) query = " WHERE " + query;
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM tinhthanhpho" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tinhthanhpho");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
