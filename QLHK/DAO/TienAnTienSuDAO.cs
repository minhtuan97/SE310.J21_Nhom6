using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class TienAnTienSuDAO : DBConnection<TienAnTienSuDTO>
    {
        public TienAnTienSuDAO() : base() { }
        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["tienantiensu"].Rows[row].Delete();
                sqlda.Update(dataset, "tienantiensu");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM tienantiensu", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public override bool insert(TienAnTienSuDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into tienantiensu values(@matienantiensu, @madinhdanh, @toidanh,@hinhphat, @banan, @ngayphat)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matienantiensu", data.MaTienAnTienSu);
                cmd.Parameters.AddWithValue("@madinhdanh", data.MaDinhDanh);
                cmd.Parameters.AddWithValue("@banan", data.BanAn);
                cmd.Parameters.AddWithValue("@toidanh", data.ToiDanh);
                cmd.Parameters.AddWithValue("@hinhphat", data.HinhPhat);
                cmd.Parameters.AddWithValue("@ngayphat", data.NgayPhat.ToString("yyyy/MM/dd"));
                cmd.ExecuteNonQuery();
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

        public override bool insert_table(TienAnTienSuDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["tienantiensu"].NewRow();
                dr["matienantiensu"] = data.MaTienAnTienSu;
                dr["madinhdanh"] = data.MaDinhDanh;
                dr["toidanh"] = data.ToiDanh;
                dr["hinhphat"] = data.HinhPhat;
                dr["banan"] = data.BanAn;
                dr["ngayphat"] = data.NgayPhat;
                dataset.Tables["tienantiensu"].Rows.Add(dr);
                dataset.Tables["tienantiensu"].Rows.RemoveAt(dataset.Tables["tienantiensu"].Rows.Count - 1);
                sqlda.Update(dataset, "tienantiensu");
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

        public override bool update(TienAnTienSuDTO data, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update tienantiensu set banan=@banan, toidanh=@toidanh, hinhphat=@hinhphat, ngayphat=@ngayphat where matienantiensu=@matienantiensu";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@matienantiensu", data.MaTienAnTienSu);
                cmd.Parameters.AddWithValue("@madinhdanh", data.MaDinhDanh);
                cmd.Parameters.AddWithValue("@banan", data.BanAn);
                cmd.Parameters.AddWithValue("@toidanh", data.ToiDanh);
                cmd.Parameters.AddWithValue("@hinhphat", data.HinhPhat);
                cmd.Parameters.AddWithValue("@ngayphat", data.NgayPhat.ToString("yyyy/MM/dd"));

                cmd.ExecuteNonQuery();
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

        public DataSet TimKiem(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (!String.IsNullOrEmpty(query)) query = " where " + query;
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM tienantiensu" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "tienantiensu");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
