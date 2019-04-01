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
    public partial class ThongTinCaNhanGUI : Form
    {
        CanBoDTO canbo;
        CanBoBUS canboBus =  new CanBoBUS();
        string tentaikhoan = "1";

        public ThongTinCaNhanGUI()
        {
            InitializeComponent();
        }

        public ThongTinCaNhanGUI(string TenTaiKhoan)
        {
            InitializeComponent();
            this.tentaikhoan = TenTaiKhoan;
            lblTaiKhoan.Text = TenTaiKhoan;
        }

        private void ThongTinCaNhanGUI_Load(object sender, EventArgs e)
        {
            //Lấy mã nhân khẩu thường trú của cán bộ từ tên đăng nhập
            string manhankhauthuongtru = canboBus.GetMaNhanKhauThuongTruFromCanBo(tentaikhoan);

            lblTaiKhoan.Text = tentaikhoan;
             
            NhanKhauThuongTruDTO nktt = canboBus.getTTNhanKhauThuongTru(manhankhauthuongtru)[0];
            tbhoten.Text = nktt.HoTen;
            tbdantoc.Text = nktt.DanToc;
            tbNgheNghiep.Text = nktt.NgheNghiep;
            dtpNgaySinh.Value = nktt.NgaySinh;
            tbmadinhdanh.Text = nktt.MaDinhDanh;
            tbhochieu.Text = nktt.HoChieu;
            tbnguyenquan.Text = nktt.NguyenQuan;
            tbtongiao.Text = nktt.TonGiao;
            tbquoctich.Text = nktt.QuocTich;
            tbsodienthoai.Text = nktt.SDT;
            tbMaNKTT.Text = nktt.MaNhanKhauThuongTru;
            tbSoSHK.Text = nktt.SoSoHoKhau;
            tbDCThuongTru.Text = nktt.NoiThuongTru;
            tbDCHienTai.Text = nktt.DiaChiHienNay;
            tbTrinhDoHocVan.Text = nktt.TrinhDoHocVan;
            tbTrinhDoCM.Text = nktt.TrinhDoChuyenMon;
            tbBietTiengDanToc.Text = nktt.BietTiengDanToc;
            tbTrinhDoNN.Text = nktt.TrinhDoNgoaiNgu;
            tbQHVoiCH.Text = nktt.QuanHeVoiChuHo;
            txt_NoiSinh.Text = nktt.NoiSinh;
            

            string gt = nktt.GioiTinh;
            if (gt == "nu") rdNu.Checked = true;
            else rdNam.Checked = true;


            
        }

        #region Các hàm phụ hỗ trợ
        private void fillData()
        {
            
        }
        #endregion
        public ThongTinCaNhanGUI(CanBoDTO cb)
        {
            InitializeComponent();
            canbo = cb;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            lblMatKhau.Visible = lblMatKhau2.Visible = tbMatKhau.Visible = tbMatKhau2.Visible = btnOK.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbMatKhau.Text!=tbMatKhau2.Text||string.IsNullOrEmpty(tbMatKhau.Text))
            {
                MessageBox.Show(this, "Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*set mật khẩu bảng cán bộ*/
            if(canboBus.CapNhatMatKhau(tentaikhoan, tbMatKhau.Text.ToString()))
            {
                MessageBox.Show(this, "Thay đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMatKhau.Clear();
                tbMatKhau2.Clear();
                lblMatKhau.Visible = lblMatKhau2.Visible = tbMatKhau.Visible = tbMatKhau2.Visible = btnOK.Visible = false;
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại");

            }


        }


    }
}
