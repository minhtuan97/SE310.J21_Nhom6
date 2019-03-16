using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLinqEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LINQENTITY_Click(object sender, EventArgs e)
        {
            //Data source
            QLHSEntities qLHSEntities = new QLHSEntities();


            //Query Creation
            var ten = from hocsinh in qLHSEntities.HocSinhs
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
    }
}
