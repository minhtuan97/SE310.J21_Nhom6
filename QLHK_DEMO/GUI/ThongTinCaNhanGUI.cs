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
        CANBO canbo;
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
             
            NHANKHAUTHUONGTRU nktt = canboBus.getTTNhanKhauThuongTru(manhankhauthuongtru)[0];
            tbhoten.Text = nktt.NHANKHAU.HOTEN;
            tbdantoc.Text = nktt.NHANKHAU.DANTOC;
            tbNgheNghiep.Text = nktt.NHANKHAU.NGHENGHIEP;
            dtpNgaySinh.Value = nktt.NHANKHAU.NGAYSINH;
            tbmadinhdanh.Text = nktt.NHANKHAU.MADINHDANH;
            tbhochieu.Text = nktt.NHANKHAU.HOCHIEU;
            tbnguyenquan.Text = nktt.NHANKHAU.NGUYENQUAN;
            tbtongiao.Text = nktt.NHANKHAU.TONGIAO;
            tbquoctich.Text = nktt.NHANKHAU.QUOCTICH;
            tbsodienthoai.Text = nktt.NHANKHAU.SDT;
            tbMaNKTT.Text = nktt.MANHANKHAUTHUONGTRU;
            tbSoSHK.Text = nktt.SOSOHOKHAU;
            tbDCThuongTru.Text = nktt.NHANKHAU.NOITHUONGTRU;
            tbDCHienTai.Text = nktt.NHANKHAU.DIACHIHIENNAY;
            tbTrinhDoHocVan.Text = nktt.NHANKHAU.TRINHDOHOCVAN;
            tbTrinhDoCM.Text = nktt.NHANKHAU.TRINHDOCHUYENMON;
            tbBietTiengDanToc.Text = nktt.NHANKHAU.BIETTIENGDANTOC;
            tbTrinhDoNN.Text = nktt.NHANKHAU.TRINHDONGOAINGU;
            tbQHVoiCH.Text = nktt.QUANHEVOICHUHO;
            txt_NoiSinh.Text = nktt.NHANKHAU.NOISINH;
            

            string gt = nktt.NHANKHAU.GIOITINH;
            if (gt == "nu") rdNu.Checked = true;
            else rdNam.Checked = true;


            
        }

        #region Các hàm phụ hỗ trợ
        private void fillData()
        {
            
        }
        #endregion
        public ThongTinCaNhanGUI(CANBO cb)
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
