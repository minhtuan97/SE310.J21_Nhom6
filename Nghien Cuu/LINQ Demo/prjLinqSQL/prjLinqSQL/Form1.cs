using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLinqSQL
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LINQSQL_Click(object sender, EventArgs e)
        {
            //Data Source
            string connString = @"Data Source=DESKTOP-0L5NRCB;AttachDbFilename=D:\QLHS.mdf;
Integrated Security=True; Connect Timeout=30";//C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QLHS.mdf;
            //c 1

            QLHS conn1 = new QLHS(connString);

            //c 2

            SqlConnection qlhsConn = new SqlConnection(connString);
            qlhsConn.Open();

            QLHS conn2 = new QLHS(qlhsConn);
            SqlTransaction qlhsTxn = qlhsConn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from HocSinh");
                cmd.Connection = qlhsConn;
                cmd.Transaction = qlhsTxn;
                cmd.ExecuteNonQuery();

                conn2.Transaction = qlhsTxn;
            }
            catch (Exception ex) { }
            qlhsConn.Close();

            //c 3

            QLHocSinhDataContext conn3 = new QLHocSinhDataContext();



            //Query creation
            var ten = from hocsinh in conn3.HocSinhs
                      select new
                      {
                          Ten = hocsinh.Ten
                      };


            //Query Execution
            dataGridView.DataSource = ten.ToList();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Data Source
            QLHocSinhDataContext conn = new QLHocSinhDataContext();

            //Create object
            HocSinh hs = new HocSinh();
            hs.MaSo = (int.Parse(conn.HocSinhs.OrderByDescending(u => u.MaSo).FirstOrDefault().MaSo)+1).ToString();
            hs.Ten = "Them moi";

            MessageBox.Show(hs.MaSo+":"+hs.Ten);

            //Insert Data
            conn.HocSinhs.InsertOnSubmit(hs);
            conn.SubmitChanges();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Data Source
            QLHocSinhDataContext conn = new QLHocSinhDataContext();

            //Query
            var hs = from hocsinh in conn.HocSinhs select hocsinh;

            //Update Data
            foreach (var item in hs)
            {
                if (item.Ten == "Them moi")
                    item.Ten = "Them moi sua";
            }
            conn.SubmitChanges();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Data Source
            QLHocSinhDataContext conn = new QLHocSinhDataContext();

            //Query
            var hs = from hocsinh in conn.HocSinhs select hocsinh;

            //Update Data
            foreach (var item in hs)
            {
                if (item.Ten == "Them moi sua")
                    conn.HocSinhs.DeleteOnSubmit(item);
            }
            conn.SubmitChanges();
        }
    }

    public class QLHS : DataContext
    {
        public Table<HocSinh> hocSinhs;
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
        public QLHS(string connection) : base(connection) { }
        public QLHS(System.Data.IDbConnection connection) :
                base(connection, mappingSource)
        {
        }
    }
}
