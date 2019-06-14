﻿using System;
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
using DTO.DB;
using System.Xml.Linq;
using System.IO;

namespace GUI
{
    public partial class DangNhapGUI : DevExpress.XtraEditors.XtraForm
    {
        CANBO cb = new CANBO();
        public DangNhapGUI()
        {
            InitializeComponent();
            //qlhkDataSet ds = new qlhkDataSet();
            //var data = from d in ds.dbDataSet.Tables["CANBO"].AsEnumerable()
            //           select new 
            //           {
            //               id = d["MACANBO"]
            //           };

            //tbTaiKhoan.Text = data.ToList().First().id.ToString();
            //XElement qlhk = XElement.Parse(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\DTO\\DB\\qlhk.xml"));

            //var data = from c in qlhk.Descendants("table").Where(e=>(string)e.Attribute("name")== "canbo")
            //           select new
            //           {
            //               id = c.Descendants("column").Where(e => (string)e.Attribute("name") == "MACANBO").FirstOrDefault().Value
            //           };

            //CanBoBUS cb = new CanBoBUS();
            //var data = cb.GetAll().Select(e=>new { id= e.dbcb.MACANBO});

            //tbTaiKhoan.Text = data.ToList().First().id.ToString();

            //tbTaiKhoan.Text = DAO.ViDu.TruyVanXML.layDatabase();
        }

        private void DangNhap()
        {



            List<CANBO> dt = DangNhapBUS.TimKiem(tbTaiKhoan.Text, tbMatKhau.Text);
            
            if (dt != null)
            {
                Home home = new Home(dt.FirstOrDefault());

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