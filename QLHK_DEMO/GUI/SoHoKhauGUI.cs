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
    public partial class SoHoKhauGUI : Form
    {
        SoHoKhauBUS shk;
        NhanKhauThuongTruBUS nktt;
        public SOHOKHAU shkDTO;
        public NHANKHAUTHUONGTRU nkDuocChon;

        public SoHoKhauGUI()
        {
            shk = new SoHoKhauBUS();
            nktt = new NhanKhauThuongTruBUS();
            shkDTO = new SOHOKHAU();
            InitializeComponent();

            tbSoSoHoKhau.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
            tbSoDangKy.Text = TrinhTaoMa.random7();
            taoDanhSachNhanKhau();
        }
        #region Các hàm hỗ trợ
        private void reloadSHK()
        {
            if (shkDTO == null)
                return;

            shkDTO = shk.TimKiem("sosohokhau='" + shkDTO.SOSOHOKHAU + "'")[0];
        }
        private void taoDanhSachNhanKhau()
        {
            if (shkDTO == null || shkDTO.NhanKhau == null)
                return;
            DataTable tbnk = DataHelper.ListToDatatable<NHANKHAU>(shkDTO.NhanKhau.Select(r => r.NHANKHAU).ToList());
            DataTable tbnktt = DataHelper.ListToDatatable<NHANKHAUTHUONGTRU>(shkDTO.NhanKhau.Select(r => r).ToList());
            DataTable tb = DataHelper.mergeTwoTables(tbnk, tbnktt, "MADINHDANH");

            //var bindingList = new BindingList<NHANKHAUTHUONGTRU>(shkDTO.NhanKhau.Select(r=>r.dbnktt).ToList());
            //var source = new BindingSource(bindingList, null);
            cbbChuHo.DisplayMember = "HOTEN";
            cbbChuHo.ValueMember = "MANHANKHAUTHUONGTRU";

            dataGridView1.DataSource = tb;

            cbbChuHo.DataSource = tb;
        }

        private void fillData()
        {
            tbSoSoHoKhau.Text = shkDTO.SOSOHOKHAU;
            cbbChuHo.SelectedValue = shkDTO.MACHUHO;
            dtpNgayCap.Value = shkDTO.NGAYCAP;
            tbDiaChi.Text = shkDTO.DIACHI;
            tbSoDangKy.Text = shkDTO.SODANGKY;
            taoDanhSachNhanKhau();

        }

        private void cleanData()
        {
            tbSoSoHoKhau.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
            cbbChuHo.DataSource = null;
            cbbChuHo.SelectedValue = null;
            dtpNgayCap.Value = DateTime.Today;
            tbDiaChi.Text = "";
            tbSoDangKy.Text = TrinhTaoMa.random7();
            dataGridView1.DataSource = null;
        }
        #endregion

        public SoHoKhauGUI(string sosohokhau)
        {

            shk = new SoHoKhauBUS();
            nktt = new NhanKhauThuongTruBUS();
            //shkDTO = new SOHOKHAU();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;


            tbSoSoHoKhau.Text = sosohokhau;
            List<SOHOKHAU> ds = shk.TimKiem("sosohokhau='"+sosohokhau+"'");
            shkDTO = ds[0];

            taoDanhSachNhanKhau();


            cbbChuHo.SelectedValue = shkDTO.MACHUHO;
            dtpNgayCap.Value = shkDTO.NGAYCAP;
            tbDiaChi.Text = shkDTO.DIACHI;
            tbSoDangKy.Text = shkDTO.SODANGKY;
        }

        private void SoHoKhauGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSoSoHoKhau.Text)|| string.IsNullOrEmpty(tbDiaChi.Text))
            {
                MessageBox.Show(this, "Vui lòng tạo mã hộ khẩu, và thông tin thường trú!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI(tbSoSoHoKhau.Text, tbDiaChi.Text))
            {
                a.ShowDialog(this);
                if (a.nkttDTO != null && !String.IsNullOrEmpty(a.nkttDTO.MANHANKHAUTHUONGTRU))
                {
                    if (shkDTO.NhanKhau.Any(i => i.MANHANKHAUTHUONGTRU == a.nkttDTO.MANHANKHAUTHUONGTRU))
                        return;
                    shkDTO.NhanKhau.Add(a.nkttDTO);

                    cbbChuHo.DataSource = null;
                    cbbChuHo.Items.Clear();

                    taoDanhSachNhanKhau();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSoSoHoKhau.Text) ||cbbChuHo.SelectedValue==null || shkDTO.NhanKhau.Count==0
                || string.IsNullOrEmpty(tbDiaChi.Text)|| string.IsNullOrEmpty(tbSoDangKy.Text))
            {
                MessageBox.Show(this, "Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool updateOK = true;
            if (shkDTO==null||string.IsNullOrEmpty(shkDTO.SOSOHOKHAU))
            {
                shkDTO = new SOHOKHAU(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text, shkDTO.NhanKhau);
                updateOK = shk.Add(shkDTO);
                foreach(NHANKHAUTHUONGTRU item in shkDTO.NhanKhau)
                {
                    //item.dbnktt.SOHOKHAU = shkDTO.db;
                    //item.dbnktt.SOSOHOKHAU = shkDTO.db.SOSOHOKHAU;
                    //item.dbnktt.DIACHITHUONGTRU = shkDTO.db.DIACHI;
                    updateOK = nktt.updateTTThuongTru(item.MANHANKHAUTHUONGTRU, shkDTO);
                }
                //nktt.DoiChuHo(shkDTO.NhanKhau, cbbChuHo.SelectedValue.ToString());
                if (updateOK)
                {
                    MessageBox.Show(this, "Tạo sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Tạo sổ hộ khẩu Thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                shkDTO = new SOHOKHAU(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text, shkDTO.NhanKhau);

                updateOK = shk.Update(shkDTO);
                foreach (NHANKHAUTHUONGTRU item in shkDTO.NhanKhau)
                {
                    if(item.SOSOHOKHAU != shkDTO.SOSOHOKHAU|| item.DIACHITHUONGTRU != shkDTO.DIACHI)
                    {
                        //item.dbnktt.SOHOKHAU = shkDTO.db;
                        //item.dbnktt.SOSOHOKHAU = shkDTO.db.SOSOHOKHAU;
                        //item.dbnktt.DIACHITHUONGTRU = shkDTO.db.DIACHI;
                        updateOK = nktt.updateTTThuongTru(item.MANHANKHAUTHUONGTRU, shkDTO);
                    }
                }
                //nktt.DoiChuHo(shkDTO.NhanKhau, cbbChuHo.SelectedValue.ToString());
                if (updateOK)
                {
                    MessageBox.Show(this, "Cập nhật sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Cập nhật sổ hộ khẩu Thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnXoa.Enabled = true;

        }

        private void tbDiaChi_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbDiaChi.Text = a.diaChi;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<SOHOKHAU> kq = shk.TimKiem("sosohokhau='" + tbSoSoHoKhau.Text + "'");
            if (kq.Count > 0)
            {

                shkDTO = kq[0];
                //foreach (NHANKHAUTHUONGTRU item in shkDTO.NhanKhau)
                //{
                //    shkDTO.NhanKhau.Add(new NHANKHAUTHUONGTRU(item));
                //}
                fillData();
                btnXoa.Enabled = true;

            }
            else
            {
                MessageBox.Show(this, "Hộ khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;

            //DataTable table = (DataTable)dataGridView1.DataSource;
            //DataRow data = table.NewRow();
            //DataRow data = ((DataRowView)dataGridView1.Rows[index].DataBoundItem).Row;
            //DataRow data = table.Rows[index];
            nkDuocChon = shkDTO.NhanKhau[index];

            btnSuaNhanKhau.Visible = btnXoaNhanKhau.Visible = true;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaNhanKhau_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbSoSoHoKhau.Text) || string.IsNullOrEmpty(tbDiaChi.Text))
            {
                MessageBox.Show(this, "Vui lòng tạo mã hộ khẩu, và thông tin thường trú!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI(nkDuocChon.MADINHDANH, -1,cbbChuHo.Text))
            {
                a.ShowDialog(this);
                if (a.nkttDTO != null && !String.IsNullOrEmpty(a.nkttDTO.MADINHDANH))
                {
                    if (shkDTO.NhanKhau.Any(i => i.MANHANKHAUTHUONGTRU == a.nkttDTO.MANHANKHAUTHUONGTRU))
                        return;
                    reloadSHK();

                    cbbChuHo.DataSource = null;
                    cbbChuHo.Items.Clear();

                    taoDanhSachNhanKhau();
                }
            }
        }

        private void btnXoaNhanKhau_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbSoSoHoKhau.Text) || string.IsNullOrEmpty(tbDiaChi.Text))
            {
                MessageBox.Show(this, "Vui lòng tạo mã hộ khẩu, và thông tin thường trú!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nkDuocChon.SOHOKHAU = null;
            nkDuocChon.SOSOHOKHAU = null;

            //nktt.XoaNKTT(nkDuocChon.MaNhanKhauThuongTru);
            if(nktt.Update(nkDuocChon))
                MessageBox.Show(this, "Đã xóa nhân khẩu thành công!", "Xóa Nhân khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, "Đã xóa nhân khẩu thất bại!", "Xóa Nhân khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            reloadSHK();
            taoDanhSachNhanKhau();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(shkDTO.SOSOHOKHAU))
            {
                MessageBox.Show(this, "Không có sổ hộ khẩu nào được chọn!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show(this, "Bạn có chắc chắn muốn xóa sổ này?", "Xóa sổ hộ khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool condition = false;
                //if (MessageBox.Show(this, "Bạn có muốn xóa thông tin các nhân khẩu bên trong sổ này?", "Xóa sổ hộ khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{

                //}
                //else
                //{
                    foreach (NHANKHAUTHUONGTRU item in shkDTO.NhanKhau)
                    {
                        item.SOHOKHAU = null;
                        item.SOSOHOKHAU = null;
                        item.DIACHITHUONGTRU = null;
                        condition = nktt.Update(item);
                    }
                //}
                
                condition = shk.XoaSoHK(shkDTO.SOSOHOKHAU);
                shkDTO = new SOHOKHAU();
                MessageBox.Show(this, "Xóa sổ hộ khẩu thành công!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanData();
            }
        }
    }
}
