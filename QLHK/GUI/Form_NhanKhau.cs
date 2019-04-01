using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Form_NhanKhau : Form
    {
        NhanKhau nk;
        NhanKhauBUS nhankhaubus = new NhanKhauBUS();

        public Form_NhanKhau()
        {
            InitializeComponent();
            dataGridView1.DataSource = nhankhaubus.GetAll();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_them_Click(object sender, EventArgs e)
        {
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string hoten = textBox_hoten.Text.ToString();
            string gioitinh = textBox_gioitinh.Text.ToString();
            string dantoc = textBox_dantoc.Text.ToString();
            string hochieu = textBox_hochieu.Text.ToString();
            DateTime ngaycap = DateTime.Parse(textBox_ngaycap.Text.ToString());
            DateTime ngaysinh = DateTime.Parse(textBox_ngaysinh.Text.ToString());
            string nguyenquan = textBox_nguyenquan.Text.ToString();
            string noicap = textBox_noicap.Text.ToString();
            string noisinh = textBox_noisinh.Text.ToString();
            string quoctich = textBox_quoctich.Text.ToString();
            string sdt = textBox_sodienthoai.Text.ToString();
            string tongiao = textBox_tongiao.Text.ToString();
            //nk = new NhanKhau(madinhdanh,hoten,gioitinh,dantoc,hochieu,ngaycap,ngaysinh,nguyenquan,noicap,noisinh,quoctich,sdt,tongiao);
            nhankhaubus.Add(nk);
            dataGridView1.DataSource = nhankhaubus.GetAll();
        }
    }
}
