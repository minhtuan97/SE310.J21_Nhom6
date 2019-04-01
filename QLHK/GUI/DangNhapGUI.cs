using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class DangNhapGUI : DevExpress.XtraEditors.XtraForm
    {
        CanBoDTO cb = new CanBoDTO();
        public DangNhapGUI()
        {
            InitializeComponent();
        }

        private void DangNhap()
        {
            DataRow dt = DangNhapBUS.TimKiem(tbTaiKhoan.Text, tbMatKhau.Text);
            if (dt != null)
            {
                cb = new CanBoDTO(dt);
                Home home = new Home(cb);

                this.Hide();
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
            else
            {
                MessageBox.Show(this, "Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();

        }

        private void tbTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void tbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }
    }
}
