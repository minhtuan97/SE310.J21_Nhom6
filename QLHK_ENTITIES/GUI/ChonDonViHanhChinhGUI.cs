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
    public partial class ChonDonViHanhChinhGUI : Form
    {
        TinhThanhPhoBUS ttp;
        QuanHuyenBUS qh;
        XaPhuongThiTranBUS xp;
        public string diaChi;

        public ChonDonViHanhChinhGUI()
        {
            ttp = new TinhThanhPhoBUS();
            qh = new QuanHuyenBUS();
            xp = new XaPhuongThiTranBUS();
            InitializeComponent();

            cbbTinhThanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cbbTinhThanh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTinhThanh.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbbTinhThanh.DisplayMember = "ten";
            cbbTinhThanh.ValueMember = "matp";
            cbbTinhThanh.DataSource = ttp.GetAll().Select(r => r.db).ToList();
            cbbTinhThanh.SelectedValue = "74";
            cbbQuanHuyen.SelectedValue = "724";


        }

        private void cbbTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbQuanHuyen.DisplayMember = "ten";
            cbbQuanHuyen.ValueMember = "maqh";
            cbbQuanHuyen.DataSource = qh.TimKiem("matp='"+cbbTinhThanh.SelectedValue.ToString()+"'").Select(r => r.db).ToList();
        }

        private void cbbQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbXaPhuong.DisplayMember = "ten";
            cbbXaPhuong.ValueMember = "maxp";
            cbbXaPhuong.DataSource = xp.TimKiem("maqh='" + cbbQuanHuyen.SelectedValue.ToString() + "'").Select(r => r.db).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            diaChi = (String.IsNullOrEmpty(tbDiaChi.Text) ? "" : tbDiaChi.Text + ", ")
                + (String.IsNullOrEmpty(cbbXaPhuong.Text) ? "" : cbbXaPhuong.Text + ", ")
                + (String.IsNullOrEmpty(cbbQuanHuyen.Text) ? "" : cbbQuanHuyen.Text + ", ")
                + (String.IsNullOrEmpty(cbbTinhThanh.Text) ? "" : cbbTinhThanh.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            diaChi = "";
            this.Close();
        }
    }
}
