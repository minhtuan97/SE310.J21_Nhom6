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
    public class XaPhuongThiTranDAO:DBConnection<XaPhuongThiTranDTO>
    {
        public XaPhuongThiTranDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM xaphuongthitran", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);

                dataset = new DataSet();
                sqlda.Fill(dataset, "xaphuongthitran");
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

        public override bool insert(XaPhuongThiTranDTO xaphuong)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["xaphuongthitran"].NewRow();
                dr["maxa"] = xaphuong.MaQH;
                dr["maqh"] = xaphuong.MaQH;
                dr["ten"] = xaphuong.Ten;
                dr["kieu"] = xaphuong.Kieu;

                dataset.Tables["xaphuongthitran"].Rows.Add(dr);
                dataset.Tables["v"].Rows.RemoveAt(dataset.Tables["xaphuongthitran"].Rows.Count - 1);
                sqlda.Update(dataset, "xaphuongthitran");
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
        public override bool insert_table(XaPhuongThiTranDTO data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["xaphuongthitran"].NewRow();
                dr["maxp"] = data.MaXP;
                dr["ten"] = data.Ten;
                dr["kieu"] = data.Kieu;
                dr["maqh"] = data.MaQH;

                dataset.Tables["xaphuongthitran"].Rows.Add(dr);
                dataset.Tables["xaphuongthitran"].Rows.RemoveAt(dataset.Tables["xaphuongthitran"].Rows.Count - 1);
                sqlda.Update(dataset, "xaphuongthitran");
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
                dataset.Tables["xaphuongthitran"].Rows[row].Delete();
                sqlda.Update(dataset, "xaphuongthitran");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(XaPhuongThiTranDTO xaphuong, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update xaphuongthitran set ten=@ten, kieu=@kieu, maqh =@mqah where maxp =@maxp";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maxp", xaphuong.MaQH.ToString());
                cmd.Parameters.AddWithValue("@maqh", xaphuong.MaQH.ToString());
                cmd.Parameters.AddWithValue("@ten", xaphuong.Ten.ToString());
                cmd.Parameters.AddWithValue("@kieu", xaphuong.Kieu.ToString());

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
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM xaphuongthitran" + query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "xaphuongthitran");
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
