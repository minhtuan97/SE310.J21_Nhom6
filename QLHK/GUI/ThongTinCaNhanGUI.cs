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
            tbhoten.Text = nktt.db.HOTEN;
            tbdantoc.Text = nktt.db.DANTOC;
            tbNgheNghiep.Text = nktt.db.NGHENGHIEP;
            dtpNgaySinh.Value = nktt.db.NGAYSINH;
            tbmadinhdanh.Text = nktt.db.MADINHDANH;
            tbhochieu.Text = nktt.db.HOCHIEU;
            tbnguyenquan.Text = nktt.db.NGUYENQUAN;
            tbtongiao.Text = nktt.db.TONGIAO;
            tbquoctich.Text = nktt.db.QUOCTICH;
            tbsodienthoai.Text = nktt.db.SDT;
            tbMaNKTT.Text = nktt.dbnktt.MANHANKHAUTHUONGTRU;
            tbSoSHK.Text = nktt.dbnktt.SOSOHOKHAU;
            tbDCThuongTru.Text = nktt.db.NOITHUONGTRU;
            tbDCHienTai.Text = nktt.db.DIACHIHIENNAY;
            tbTrinhDoHocVan.Text = nktt.db.TRINHDOHOCVAN;
            tbTrinhDoCM.Text = nktt.db.TRINHDOCHUYENMON;
            tbBietTiengDanToc.Text = nktt.db.BIETTIENGDANTOC;
            tbTrinhDoNN.Text = nktt.db.TRINHDONGOAINGU;
            tbQHVoiCH.Text = nktt.dbnktt.QUANHEVOICHUHO;
            txt_NoiSinh.Text = nktt.db.NOISINH;
            

            string gt = nktt.db.GIOITINH;
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
