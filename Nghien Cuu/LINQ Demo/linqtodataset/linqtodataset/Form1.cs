using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linqtodataset
{
    public partial class Form1 : Form
    {
        DataSet data_set = new DataSet("linqtodataset");
        DataTable tb_hocsinh = new DataTable("HocSinh");
            
        public Form1()
        {
            InitializeComponent();
            tb_hocsinh.Columns.Add("MaSo", typeof(string));
            tb_hocsinh.Columns.Add("Ten", typeof(string));
            tb_hocsinh.Columns.Add("NamSinh", typeof(int));
            tb_hocsinh.Columns.Add("MaLop", typeof(string));
            tb_hocsinh.Rows.Add("123", "Nguyen Van A", 1995, "A111");
            tb_hocsinh.Rows.Add("124", "Tran Thi B", 1993, "A113");
            tb_hocsinh.Rows.Add("125", "Huynh Thu C", 1995, "A111");
            tb_hocsinh.Rows.Add("126", "Hoang Nam", 1997, "A114");
            data_set.Tables.Add(tb_hocsinh);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var lstTen = from hs in data_set.Tables["HocSinh"].AsEnumerable()
                         select new
                         {
                             Ten = hs["Ten"]
                         };

            //Query Execution       
            dataGridView1.DataSource = lstTen.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
