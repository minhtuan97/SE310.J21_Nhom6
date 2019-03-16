using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLinqMysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //data source
        qlhsEntities entities = new qlhsEntities();



        private void LinqSql_Click(object sender, EventArgs e)
        {
            //query creation
            var query = from hocsinh in entities.hocsinhs
                        select new
                        {
                            Ten = hocsinh.Ten
                        };


            //query execution
            dataGridView1.DataSource = query.ToList();



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
