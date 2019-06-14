using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DTO.DB
{
    public class qlhkDataSet
    {
        protected static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB\\quanlyhokhauDataContext.mdf;Integrated Security=True";
        protected static SqlConnection connection = new SqlConnection(connString);

        public DataTable CANBO = getData("SELECT * FROM CANBO");
        public DataTable HOCSINHSINHVIEN = getData("SELECT * FROM HOCSINHSINHVIEN");
        public DataTable NHANKHAU = getData("SELECT * FROM NHANKHAU");
        public DataTable NHANKHAUTAMTRU = getData("SELECT * FROM NHANKHAUTAMTRU");
        public DataTable NHANKHAUTAMVANG = getData("SELECT * FROM NHANKHAUTAMVANG");
        public DataTable NHANKHAUTHUONGTRU = getData("SELECT * FROM NHANKHAUTHUONGTRU");
        public DataTable QUANHUYEN = getData("SELECT * FROM QUANHUYEN");
        public DataTable SOHOKHAU = getData("SELECT * FROM SOHOKHAU");
        public DataTable SOTAMTRU = getData("SELECT * FROM SOTAMTRU");
        public DataTable THONGKE = getData("SELECT * FROM THONGKE");
        public DataTable TIENANTIENSU = getData("SELECT * FROM TIENANTIENSU");
        public DataTable TIEUSU = getData("SELECT * FROM TIEUSU");
        public DataTable TINHTHANHPHO = getData("SELECT * FROM TINHTHANHPHO");
        public DataTable XAPHUONGTHITRAN = getData("SELECT * FROM XAPHUONGTHITRAN");

        public DataSet dbDataSet = new DataSet("qlhk");
        

        public qlhkDataSet() {
            CANBO.TableName = "CANBO";
            HOCSINHSINHVIEN.TableName = "HOCSINHSINHVIEN";
            NHANKHAU.TableName = "NHANKHAU";
            NHANKHAUTAMTRU.TableName = "NHANKHAUTAMTRU";
            NHANKHAUTAMVANG.TableName = "NHANKHAUTAMVANG";
            NHANKHAUTHUONGTRU.TableName = "NHANKHAUTHUONGTRU";
            QUANHUYEN.TableName = "QUANHUYEN";
            SOHOKHAU.TableName = "SOHOKHAU";
            SOTAMTRU.TableName = "SOTAMTRU";
            THONGKE.TableName = "THONGKE";
            TIENANTIENSU.TableName = "TIENANTIENSU";
            TIEUSU.TableName = "TIEUSU";
            TINHTHANHPHO.TableName = "TINHTHANHPHO";
            XAPHUONGTHITRAN.TableName = "XAPHUONGTHITRAN";

            dbDataSet.Tables.Add(CANBO);
            dbDataSet.Tables.Add(HOCSINHSINHVIEN);
            dbDataSet.Tables.Add(NHANKHAU);
            dbDataSet.Tables.Add(NHANKHAUTAMTRU);
            dbDataSet.Tables.Add(NHANKHAUTAMVANG);
            dbDataSet.Tables.Add(NHANKHAUTHUONGTRU);
            dbDataSet.Tables.Add(QUANHUYEN);
            dbDataSet.Tables.Add(SOHOKHAU);
            dbDataSet.Tables.Add(SOTAMTRU);
            dbDataSet.Tables.Add(THONGKE);
            dbDataSet.Tables.Add(TIENANTIENSU);
            dbDataSet.Tables.Add(TIEUSU);
            dbDataSet.Tables.Add(TINHTHANHPHO);
            dbDataSet.Tables.Add(XAPHUONGTHITRAN);
        }

        private static string errorString = "";
        public static bool openConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                errorString += e.Message + "\n\n";
                return false;
            }
        }

        public static bool closeConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                return true;
            }
            catch (SqlException ex)
            {
                errorString += ex.Message + "\n\n";
                return false;
            }
        }

        protected static DataTable getData(string query)
        {
            SqlDataAdapter mDataAdapter = new SqlDataAdapter(query, connection);
            DataSet Ds = new DataSet();

            try
            {
                openConnection();

                mDataAdapter.Fill(Ds);
                return Ds.Tables[0].Copy();
            }
            catch (Exception e)
            {
                errorString += e.Message + "\n\n";
                return new DataTable();
            }
            finally
            {
                closeConnection();
            }
        }

    }
}
