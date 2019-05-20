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
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CANBO cb = new CANBO();
        public Home()
        {
            InitializeComponent();
            this.ForeColor = Color.Black;
        }
        public Home(CANBO cb)
        {
            InitializeComponent();
            this.ForeColor = Color.Black;
            this.cb = cb;
            if (cb.LOAICANBO == "1") ribbonPageGroup10.Visible = false;
        }
        private void Home_Load(object sender, EventArgs e)
        {
            imageSlider.AutoSlide = DevExpress.XtraEditors.Controls.AutoSlide.Forward;
        }
        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            //imageSlider.Visible = ribbonControl1.Minimized;
        }

        private void ribbonControl1_MinimizedChanged(object sender, EventArgs e)
        {
            imageSlider.Visible = ! imageSlider.Visible;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            NhanKhauThuongTruGUI nkthuongtru = new NhanKhauThuongTruGUI();
            int index = hamkiemtrtontai(tabControl1, nkthuongtru);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                
                TabPage mytabpage = new TabPage(Text = nkthuongtru.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                nkthuongtru.TopLevel = false;
                nkthuongtru.Parent = mytabpage;
                nkthuongtru.Show();
                nkthuongtru.Dock = DockStyle.Fill;
            }
        }

        private void Canbodulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            fr_CBDuLieu cbdulieu_gui = new fr_CBDuLieu();
            int index = hamkiemtrtontai(tabControl1, cbdulieu_gui);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = cbdulieu_gui.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                cbdulieu_gui.TopLevel = false;
                cbdulieu_gui.Parent = mytabpage;
                cbdulieu_gui.Show();
                cbdulieu_gui.Dock = DockStyle.Fill;
            }
        }

        int hamkiemtrtontai(TabControl tbc, Form frm)
        {
            for (int i = 0; i < tbc.TabCount; i++)
            {
                if (tbc.TabPages[i].Text.Trim() == frm.Text.Trim())
                    return i;
            }
            return -1;
        }

        private void barButton_hssv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            HocSinhSinhVienGUI hssv = new HocSinhSinhVienGUI();
            int index = hamkiemtrtontai(tabControl1, hssv);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = hssv.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                hssv.TopLevel = false;
                hssv.Parent = mytabpage;
                hssv.Show();
                hssv.Dock = DockStyle.Fill;
            }
        }

        private void barButton_hokhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            SoHoKhauGUI hokhau = new SoHoKhauGUI();
            int index = hamkiemtrtontai(tabControl1, hokhau);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = hokhau.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                hokhau.TopLevel = false;
                hokhau.Parent = mytabpage;
                hokhau.Show();
                hokhau.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem_tamtru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            SoTamTruGUI tamtru = new SoTamTruGUI();
            int index = hamkiemtrtontai(tabControl1, tamtru);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = tamtru.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                tamtru.TopLevel = false;
                tamtru.Parent = mytabpage;
                tamtru.Show();
                tamtru.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            NhanKhauTamVangGUI tamvang = new NhanKhauTamVangGUI();
            int index = hamkiemtrtontai(tabControl1, tamvang);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = tamvang.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                tamvang.TopLevel = false;
                tamvang.Parent = mytabpage;
                tamvang.Show();
                tamvang.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            ThongKeGUI thongke = new ThongKeGUI();
            int index = hamkiemtrtontai(tabControl1, thongke);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = thongke.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                thongke.TopLevel = false;
                thongke.Parent = mytabpage;
                thongke.Show();
                thongke.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            TimKiemGUI timkiem = new TimKiemGUI();
            int index = hamkiemtrtontai(tabControl1, timkiem);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = timkiem.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                timkiem.TopLevel = false;
                timkiem.Parent = mytabpage;
                timkiem.Show();
                timkiem.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem9_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(page);
            }
            ThongTinCaNhanGUI thongtin = new ThongTinCaNhanGUI(cb.TENTAIKHOAN);
            int index = hamkiemtrtontai(tabControl1, thongtin);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = thongtin.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                thongtin.TopLevel = false;
                thongtin.Parent = mytabpage;
                thongtin.Show();
                thongtin.Dock = DockStyle.Fill;
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangNhapGUI loginForm = new DangNhapGUI();
                this.Hide();
                loginForm.Closed += (s, args) => this.Close();
                loginForm.Show(); 
            }
            
        }

        
    }
}
