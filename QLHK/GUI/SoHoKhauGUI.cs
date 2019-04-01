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
        public SoHoKhauDTO shkDTO;
        public NhanKhauThuongTruDTO nkDuocChon;

        public SoHoKhauGUI()
        {
            shk = new SoHoKhauBUS();
            nktt = new NhanKhauThuongTruBUS();
            shkDTO = new SoHoKhauDTO();
            InitializeComponent();

            tbSoSoHoKhau.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
            tbSoDangKy.Text = TrinhTaoMa.random7();
            taoDanhSachNhanKhau();
        }
        #region Các hàm hỗ trợ
        private void taoDanhSachNhanKhau()
        {
            var bindingList = new BindingList<NhanKhauThuongTruDTO>(shkDTO.NhanKhau);
            var source = new BindingSource(bindingList, null);
            cbbChuHo.DisplayMember = "HoTen";
            cbbChuHo.ValueMember = "MaNhanKhauThuongTru";

            dataGridView1.DataSource = source;

            cbbChuHo.DataSource = bindingList;
        }

        private void fillData()
        {
            tbSoSoHoKhau.Text = shkDTO.SoSoHoKhau;
            cbbChuHo.SelectedValue = shkDTO.MaChuHoThuongTru;
            dtpNgayCap.Value = shkDTO.NgayCap;
            tbDiaChi.Text = shkDTO.DiaChi;
            tbSoDangKy.Text = shkDTO.SoDangKy;
            taoDanhSachNhanKhau();

        }
        #endregion

        public SoHoKhauGUI(string sosohokhau)
        {

            shk = new SoHoKhauBUS();
            nktt = new NhanKhauThuongTruBUS();
            shkDTO = new SoHoKhauDTO();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;


            tbSoSoHoKhau.Text = sosohokhau;
            DataSet ds = shk.TimKiem("sosohokhau='"+sosohokhau+"'");
            DataRow dt = ds.Tables["sohokhau"].Rows[0];

            shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString()
                ,(DateTime) dt["ngaycap"], dt["sodangky"].ToString());
            taoDanhSachNhanKhau();


            cbbChuHo.SelectedValue = shkDTO.MaChuHoThuongTru;
            dtpNgayCap.Value = shkDTO.NgayCap;
            tbDiaChi.Text = shkDTO.DiaChi;
            tbSoDangKy.Text = shkDTO.SoDangKy;
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
                if (a.nkttDTO != null && !String.IsNullOrEmpty(a.nkttDTO.MaNhanKhauThuongTru))
                {
                    if (shkDTO.NhanKhau.Any(i => i.MaNhanKhauThuongTru == a.nkttDTO.MaNhanKhauThuongTru))
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
            if (string.IsNullOrEmpty(shkDTO.SoSoHoKhau))
            {
                shkDTO = new SoHoKhauDTO(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text, shkDTO.NhanKhau);
                shk.Add(shkDTO);
                foreach(NhanKhauThuongTruDTO item in shkDTO.NhanKhau)
                {
                    item.SoSoHoKhau = shkDTO.SoSoHoKhau;
                    nktt.Update(item);
                }
                //nktt.DoiChuHo(shkDTO.NhanKhau, cbbChuHo.SelectedValue.ToString());
                MessageBox.Show(this, "Tạo sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                shkDTO = new SoHoKhauDTO(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text, shkDTO.NhanKhau);

                shk.Update(shkDTO);
                foreach (NhanKhauThuongTruDTO item in shkDTO.NhanKhau)
                {
                    item.SoSoHoKhau = shkDTO.SoSoHoKhau;
                    nktt.Update(item);
                }
                //nktt.DoiChuHo(shkDTO.NhanKhau, cbbChuHo.SelectedValue.ToString());
                MessageBox.Show(this, "Cập nhật sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tbSoSoHoKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable kq = shk.TimKiem("sosohokhau='" + tbSoSoHoKhau.Text + "'").Tables[0];
            if (kq.Rows.Count > 0)
            {
                DataRow dt = kq.Rows[0];
                shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString(), DateTime.Parse(dt["ngaycap"].ToString()), dt["sodangky"].ToString());
                DataTable nk = nktt.TimKiemJoinNhanKhau("sosohokhau='" + tbSoSoHoKhau.Text + "'").Tables[0];
                foreach(DataRow item in nk.Rows)
                {
                    shkDTO.NhanKhau.Add(new NhanKhauThuongTruDTO(item));

                }
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

            using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI(nkDuocChon.MaDinhDanh, -1,cbbChuHo.Text))
            {
                a.ShowDialog(this);
                if (a.nkttDTO != null && !String.IsNullOrEmpty(a.nkttDTO.MaNhanKhauThuongTru))
                {
                    if (shkDTO.NhanKhau.Any(i => i.MaNhanKhauThuongTru == a.nkttDTO.MaNhanKhauThuongTru))
                        return;
                    shkDTO.NhanKhau.Add(a.nkttDTO);

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

            nkDuocChon.SoSoHoKhau = null;
            nktt.Update(nkDuocChon, 0);

            //nktt.XoaNKTT(nkDuocChon.MaNhanKhauThuongTru);
            MessageBox.Show(this, "Đã xóa nhân khẩu thành công!", "Xóa Nhân khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(shkDTO.SoSoHoKhau))
            {
                MessageBox.Show(this, "Không có sổ hộ khẩu nào được chọn!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show(this, "Bạn có chắc chắn muốn xóa sổ này?", "Xóa sổ hộ khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                shk.XoaSoHK(shkDTO.SoSoHoKhau);
                foreach (NhanKhauThuongTruDTO item in shkDTO.NhanKhau)
                {
                    item.SoSoHoKhau = null;
                    nktt.Update(item);
                }
                shkDTO = new SoHoKhauDTO();
                MessageBox.Show(this, "Xóa sổ hộ khẩu thành công!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
