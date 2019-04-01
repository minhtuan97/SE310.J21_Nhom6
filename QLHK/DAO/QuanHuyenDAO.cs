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
    public class QuanHuyenDAO:DBConnection<QuanHuyenDTO>
    {
        public QuanHuyenDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM quanhuyen", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "quanhuyen");
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

        public override bool insert(QuanHuyenDTO quanHuyen)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["quanhuyen"].NewRow();
                dr["maqh"] = quanHuyen.MaQH;
                dr["matp"] = quanHuyen.MaTP;
                dr["ten"] = quanHuyen.Ten;
                dr["kieu"] = quanHuyen.Kieu;

                dataset.Tables["quanhuyen"].Rows.Add(dr);
                dataset.Tables["quanhuyen"].Rows.RemoveAt(dataset.Tables["quanhuyen"].Rows.Count - 1);
                sqlda.Update(dataset, "quanhuyen");
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
        public override bool insert_table(QuanHuyenDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["quanhuyen"].NewRow();
                dr["maqh"] = data.MaTP;
                dr["ten"] = data.Ten;
                dr["kieu"] = data.Kieu;
                dr["matp"] = data.MaTP;
                dataset.Tables["quanhuyen"].Rows.Add(dr);
                dataset.Tables["quanhuyen"].Rows.RemoveAt(dataset.Tables["quanhuyen"].Rows.Count - 1);
                sqlda.Update(dataset, "quanhuyen");
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

        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["quanhuyen"].Rows[row].Delete();
                sqlda.Update(dataset, "quanhuyen");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(QuanHuyenDTO quanHuyen, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update quanhuyen set ten=@ten, kieu=@kieu, matp =@matp where maqh =@maqh";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maqh", quanHuyen.MaQH.ToString());
                cmd.Parameters.AddWithValue("@matp", quanHuyen.MaTP.ToString());
                cmd.Parameters.AddWithValue("@ten", quanHuyen.Ten.ToString());
                cmd.Parameters.AddWithValue("@kieu", quanHuyen.Kieu.ToString());

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
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM quanhuyen"+query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);

                dataset = new DataSet();
                sqlda.Fill(dataset, "quanhuyen");
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
