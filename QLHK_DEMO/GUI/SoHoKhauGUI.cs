using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
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
        List<NHANKHAUTHUONGTRU> listNKMoi = new List<NHANKHAUTHUONGTRU>();
        public int page = 0;

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

            if (shkDTO == null || (shkDTO.NHANKHAUTHUONGTRUs.Count==0&&listNKMoi.Count==0))
                return;

            var lstNhanKhau = shkDTO.NHANKHAUTHUONGTRUs.ToList();
            if (listNKMoi.Count > 0)
            {
                lstNhanKhau.AddRange(listNKMoi);
            }

            checkPage();
            var lstNK = lstNhanKhau.Skip(5*page).Take(5);

            DataTable tbnk = DataHelper.ListToDatatable<NHANKHAU>(lstNK.Select(r => r.NHANKHAU).ToList());
            DataTable tbnktt = DataHelper.ListToDatatable<NHANKHAUTHUONGTRU>(lstNK.Select(r => r).ToList());
            DataTable tb = DataHelper.mergeTwoTables(tbnk, tbnktt, "MADINHDANH");
          

            //var bindingList = new BindingList<NHANKHAUTHUONGTRU>(shkDTO.NHANKHAUTHUONGTRUs.Select(r=>r.dbnktt).ToList());
            //var source = new BindingSource(bindingList, null);
            cbbChuHo.DisplayMember = "HOTEN";
            cbbChuHo.ValueMember = "MANHANKHAUTHUONGTRU";

            dGVNhanKhau.DataSource = tb;

            cbbChuHo.DataSource = tb;
        }

        private void fillData()
        {
            taoDanhSachNhanKhau();
            tbSoSoHoKhau.Text = shkDTO.SOSOHOKHAU;
            cbbChuHo.SelectedValue = shkDTO.MACHUHO;
            dtpNgayCap.Value = shkDTO.NGAYCAP;
            tbDiaChi.Text = shkDTO.DIACHI;
            tbSoDangKy.Text = shkDTO.SODANGKY;
            

        }

        private void cleanData()
        {
            shkDTO = new SOHOKHAU();
            listNKMoi.Clear();
            listNKMoi = new List<NHANKHAUTHUONGTRU>();
            tbSoSoHoKhau.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
            cbbChuHo.DataSource = null;
            cbbChuHo.SelectedValue = null;
            dtpNgayCap.Value = DateTime.Today;
            tbDiaChi.Text = "";
            tbSoDangKy.Text = TrinhTaoMa.random7();
            dGVNhanKhau.DataSource = null;
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
                    if (shkDTO.NHANKHAUTHUONGTRUs.Any(i => i.MANHANKHAUTHUONGTRU == a.nkttDTO.MANHANKHAUTHUONGTRU))
                        return;
                    //shkDTO.NHANKHAUTHUONGTRUs.Add(a.nkttDTO);
                    if (!listNKMoi.Any(q=>q.MADINHDANH==a.nkttDTO.MADINHDANH))
                    {
                        listNKMoi.Add(a.nkttDTO);
                    }

                    cbbChuHo.DataSource = null;
                    cbbChuHo.Items.Clear();

                    taoDanhSachNhanKhau();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSoSoHoKhau.Text) ||cbbChuHo.SelectedValue==null || (shkDTO.NHANKHAUTHUONGTRUs.Count==0 && listNKMoi.Count==0)
                || string.IsNullOrEmpty(tbDiaChi.Text)|| string.IsNullOrEmpty(tbSoDangKy.Text))
            {
                MessageBox.Show(this, "Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool updateOK = true;
            if (shkDTO==null||string.IsNullOrEmpty(shkDTO.SOSOHOKHAU))
            {
                var lstNK = shkDTO.NHANKHAUTHUONGTRUs.ToList();
                lstNK.AddRange(listNKMoi);

                shkDTO = new SOHOKHAU(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text);

                updateOK = updateOK && shk.Add(shkDTO);
                foreach (NHANKHAUTHUONGTRU item in lstNK)
                {
                    //item.SOHOKHAU = shkDTO;
                    //item.SOSOHOKHAU = shkDTO.SOSOHOKHAU;
                    //item.DIACHITHUONGTRU = shkDTO.DIACHI;
                    updateOK = updateOK && nktt.updateTTThuongTru(item.MANHANKHAUTHUONGTRU, shkDTO.SOSOHOKHAU);
                }

                //nktt.DoiChuHo(shkDTO.NHANKHAUTHUONGTRUs, cbbChuHo.SelectedValue.ToString());
                if (updateOK)
                {
                    MessageBox.Show(this, "Tạo sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Tạo sổ hộ khẩu Thất bại!\n" + shk.getError().Message + "\n" + nktt.getError().Message,
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //var lstNK = shkDTO.NHANKHAUTHUONGTRUs;
                //shkDTO = new SOHOKHAU(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text);
                //updateOK = updateOK && shk.Update(shkDTO);

                //foreach (NHANKHAUTHUONGTRU item in lstNK)
                //{
                //    if(item.SOSOHOKHAU != shkDTO.SOSOHOKHAU|| item.DIACHITHUONGTRU != shkDTO.DIACHI)
                //    {
                //        //item.dbnktt.SOHOKHAU = shkDTO.db;
                //        //item.dbnktt.SOSOHOKHAU = shkDTO.db.SOSOHOKHAU;
                //        //item.dbnktt.DIACHITHUONGTRU = shkDTO.db.DIACHI;
                //        updateOK = updateOK && nktt.updateTTThuongTru(item.MANHANKHAUTHUONGTRU, shkDTO);
                //    }
                //}

                List<NHANKHAUTHUONGTRU> lstNK = shkDTO.NHANKHAUTHUONGTRUs.ToList();
                lstNK.AddRange(listNKMoi);

                shkDTO = new SOHOKHAU(tbSoSoHoKhau.Text, cbbChuHo.SelectedValue.ToString(), tbDiaChi.Text, dtpNgayCap.Value, tbSoDangKy.Text);
                updateOK = updateOK && shk.Update(shkDTO);

                foreach (NHANKHAUTHUONGTRU item in lstNK)
                {
                    if (item.SOSOHOKHAU != shkDTO.SOSOHOKHAU || item.DIACHITHUONGTRU != shkDTO.DIACHI)
                    {
                        updateOK = updateOK && nktt.updateTTThuongTru(item.MANHANKHAUTHUONGTRU, shkDTO.SOSOHOKHAU);
                    }
                }

                //nktt.DoiChuHo(shkDTO.NHANKHAUTHUONGTRUs, cbbChuHo.SelectedValue.ToString());
                if (updateOK)
                {
                    MessageBox.Show(this, "Cập nhật sổ hộ khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Cập nhật sổ hộ khẩu Thất bại\n" + shk.getError().Message + "\n" + nktt.getError().Message,
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            listNKMoi.Clear();
            listNKMoi = new List<NHANKHAUTHUONGTRU>();
            reloadSHK();
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
                //foreach (NHANKHAUTHUONGTRU item in shkDTO.NHANKHAUTHUONGTRUs)
                //{
                //    shkDTO.NHANKHAUTHUONGTRUs.Add(new NHANKHAUTHUONGTRU(item));
                //}
                fillData();
                btnXoa.Enabled = true;

            }
            else
            {
                MessageBox.Show(this, "Hộ khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanData();
            }
        }

        private void dGVNhanKhau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dGVNhanKhau.SelectedCells[0].RowIndex;
            nkDuocChon = shkDTO.NHANKHAUTHUONGTRUs[index];

            btnSuaNhanKhau.Visible = btnXoaNhanKhau.Visible = true;
        }

        private void dGVNhanKhau_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                reloadSHK();

                cbbChuHo.DataSource = null;
                cbbChuHo.Items.Clear();

                taoDanhSachNhanKhau();
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
                MessageBox.Show(this, "Đã xóa nhân khẩu thất bại!\n" + shk.getError().Message + "\n" + nktt.getError().Message,
                    "Xóa Nhân khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            listNKMoi.Clear();
            listNKMoi = new List<NHANKHAUTHUONGTRU>();
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
                bool condition = true;
                //if (MessageBox.Show(this, "Bạn có muốn xóa thông tin các nhân khẩu bên trong sổ này?", "Xóa sổ hộ khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{

                //}
                //else
                //{
                    foreach (NHANKHAUTHUONGTRU item in shkDTO.NHANKHAUTHUONGTRUs.ToList())
                    {
                        item.SOHOKHAU = null;
                        item.SOSOHOKHAU = null;
                        //item.DIACHITHUONGTRU = null;
                        condition = condition&& nktt.Update(item);
                    }
                //}
                
                condition = condition && shk.XoaSoHK(shkDTO.SOSOHOKHAU);
                shkDTO = new SOHOKHAU();
                if (condition)
                {
                    MessageBox.Show(this, "Xóa sổ hộ khẩu thành công!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanData();
                }
                else
                {
                    MessageBox.Show(this, "Xóa sổ hộ khẩu thất bại!", "Xóa sổ hộ khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void checkPage()
        {
            if (shkDTO == null || shkDTO.NHANKHAUTHUONGTRUs == null)
                return;

            int total = shkDTO.NHANKHAUTHUONGTRUs.Count + listNKMoi.Count - 1;
            btnBack.Enabled = total > 5 && page > 0;
            btnNext.Enabled = total > 5 && page * 5 < total;

            page = page < 0 ? 0 : page;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            page--;
            taoDanhSachNhanKhau();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            taoDanhSachNhanKhau();
        }
    }
}
