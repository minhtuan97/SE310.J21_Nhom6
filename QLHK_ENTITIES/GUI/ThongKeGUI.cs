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
    public partial class ThongKeGUI : Form
    {
        public ThongKeGUI()
        {
            InitializeComponent();

            cbbThoiGian.DisplayMember = "Text";
            cbbThoiGian.ValueMember = "Value";
            var months = new[]
            {
                new{Text="1 Tháng", Value=1},
                new{Text="6 Tháng", Value=6},
                new{Text="1 Năm", Value=12},
            };

            cbbThoiGian.DataSource = months;


        }

        private void ThongKeGUI_Load(object sender, EventArgs e)
        {

        }

        private void cbbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbHoTH.Text = ThongKeBUS.DemSoHoKhau("sohokhau.sosohokhau", cbbThoiGian.SelectedValue.ToString());
            //tbNhanKhauTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString());
            //tbNKThanhThiTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "noithuongtru not like '%xã%'");
            //tbNKNuTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "gioitinh='nu'");
            //tbNK14TH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "YEAR(GETDATE())-YEAR(ngaysinh)>=14");

            //tbHoKoTH.Text = ThongKeBUS.DemSoHoKhau("sohokhau.sosohokhau", cbbThoiGian.SelectedValue.ToString(), false);
            //tbNhanKhauKoTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "", false);
            //tbNKThanhThiKoTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "noithuongtru not like '%xã%'", false);
            //tbNKNuKoTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "gioitinh='nu'", false);
            //tbNK14KoTH.Text = ThongKeBUS.DemNhanKhauThuongTru("nhankhauthuongtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "YEAR(GETDATE())-YEAR(ngaysinh)>=14", false);

            //tbHoTT.Text = ThongKeBUS.DemSoTamTru("sotamtru.sosotamtru", cbbThoiGian.SelectedValue.ToString());
            //tbNhanKhauTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString());
            //tbNKThanhThiTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "noithuongtru not like '%xã%'");
            //tbNKNuTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "gioitinh='nu'");
            //tbNK14TT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "YEAR(GETDATE())-YEAR(ngaysinh)>=14");

            //tbHoKoTT.Text = ThongKeBUS.DemSoTamTru("sotamtru.sosotamtru", cbbThoiGian.SelectedValue.ToString(), false);
            //tbNhanKhauKoTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "", false);
            //tbNKThanhThiKoTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "noithuongtru not like '%xã%'", false);
            //tbNKNuKoTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "gioitinh='nu'", false);
            //tbNK14KoTT.Text = ThongKeBUS.DemNhanKhauTamTru("nhankhautamtru.madinhdanh", cbbThoiGian.SelectedValue.ToString(), "YEAR(GETDATE())-YEAR(ngaysinh)>=14", false);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            List<ReplacementGroup> rg = new List<ReplacementGroup>();

            DateTime today = DateTime.Today;
            DateTime tuNgay = today.AddMonths(-int.Parse(cbbThoiGian.SelectedValue.ToString()));
            rg.Add(new ReplacementGroup("<tuNgay>", tuNgay.ToShortDateString()));
            rg.Add(new ReplacementGroup("<denNgay>", today.ToShortDateString()));

            rg.Add(new ReplacementGroup("<tongSoHo>", (int.Parse(tbHoTH.Text) + int.Parse(tbHoTH.Text)).ToString()));
            rg.Add(new ReplacementGroup("<tongSo>", (int.Parse(tbNhanKhauTH.Text) + int.Parse(tbNhanKhauTT.Text)).ToString()));
            rg.Add(new ReplacementGroup("<nkThanhThi>", (int.Parse(tbNKThanhThiTH.Text) + int.Parse(tbNKThanhThiTT.Text)).ToString()));
            rg.Add(new ReplacementGroup("<nkNu>", (int.Parse(tbNKNuTH.Text) + int.Parse(tbNKNuTT.Text)).ToString()));
            rg.Add(new ReplacementGroup("<nk14>", (int.Parse(tbNK14TH.Text) + int.Parse(tbNK14TT.Text)).ToString()));

            rg.Add(new ReplacementGroup("<hoTH>", tbHoTH.Text));
            rg.Add(new ReplacementGroup("<NhanKhauTH>", tbNhanKhauTH.Text));
            rg.Add(new ReplacementGroup("<NKThanhThiTH>", tbNKThanhThiTH.Text));
            rg.Add(new ReplacementGroup("<NKNuTH>", tbNKNuTH.Text));
            rg.Add(new ReplacementGroup("<NK14TH>", tbNK14TH.Text));

            rg.Add(new ReplacementGroup("<hoKoTH>", tbHoKoTH.Text));
            rg.Add(new ReplacementGroup("<NhanKhauKoTH>", tbNhanKhauKoTH.Text));
            rg.Add(new ReplacementGroup("<NKThanhThiKoTH>", tbNKThanhThiKoTH.Text));
            rg.Add(new ReplacementGroup("<NKNuKoTH>", tbNKNuKoTH.Text));
            rg.Add(new ReplacementGroup("<NK14KoTH>", tbNK14KoTH.Text));

            rg.Add(new ReplacementGroup("<hoTT>", tbHoTT.Text));
            rg.Add(new ReplacementGroup("<NhanKhauTT>", tbNhanKhauTT.Text));
            rg.Add(new ReplacementGroup("<NKThanhThiTT>", tbNKThanhThiTT.Text));
            rg.Add(new ReplacementGroup("<NKNuTT>", tbNKNuTT.Text));
            rg.Add(new ReplacementGroup("<NK14TT>", tbNK14TT.Text));

            rg.Add(new ReplacementGroup("<hoKoTT>", tbHoKoTT.Text));
            rg.Add(new ReplacementGroup("<NhanKhauKoTT>", tbNhanKhauKoTT.Text));
            rg.Add(new ReplacementGroup("<NKThanhThiKoTT>", tbNKThanhThiKoTT.Text));
            rg.Add(new ReplacementGroup("<NKNuKoTT>", tbNKNuKoTT.Text));
            rg.Add(new ReplacementGroup("<NK14KoTT>", tbNK14KoTT.Text));


            rg.Add(new ReplacementGroup("<ngay>", today.Day.ToString()));
            rg.Add(new ReplacementGroup("<thang>", today.Month.ToString()));
            rg.Add(new ReplacementGroup("<nam>", today.Year.ToString()));


            string srcPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\Mau HK15.doc";
            string dstPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\KetQua\\Mau HK15_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + cbbThoiGian.SelectedValue.ToString() + ".doc";
            CreateWordHelper.CreateWordDocument(srcPath, dstPath, rg);

            MessageBox.Show(this, "Đã tạo thành công file thông tin với tên: " + dstPath, "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNhapThuCong_Click(object sender, EventArgs e)
        {
            tbHoTH.Enabled = tbNhanKhauTH.Enabled = tbNKThanhThiTH.Enabled = tbNKNuTH.Enabled = tbNK14TH.Enabled =

            tbHoKoTH.Enabled = tbNhanKhauKoTH.Enabled = tbNKThanhThiKoTH.Enabled = tbNKNuKoTH.Enabled = tbNK14KoTH.Enabled =

            tbHoTT.Enabled = tbNhanKhauTT.Enabled = tbNKThanhThiTT.Enabled = tbNKNuTT.Enabled = tbNK14TT.Enabled =

            tbHoKoTT.Enabled = tbNhanKhauKoTT.Enabled = tbNKThanhThiKoTT.Enabled = tbNKNuKoTT.Enabled = tbNK14KoTT.Enabled = !tbHoTH.Enabled;
            btnNhapThuCong.Text = tbHoTH.Enabled ? "Khóa lại" : "Nhập thủ công";
        }
    }
}
