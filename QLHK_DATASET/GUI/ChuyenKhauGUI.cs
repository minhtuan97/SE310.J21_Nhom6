using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChuyenKhauGUI : Form
    {
        public string lyDo = "";
        public string noiDen = "";
        public ChuyenKhauGUI()
        {
            InitializeComponent();
        }

        private void ChuyenKhauGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLyDo.Text) || string.IsNullOrEmpty(tbNoiDen.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập lý do và nơi đến!", "Chuyển khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lyDo = tbLyDo.Text;
            noiDen = tbNoiDen.Text;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
