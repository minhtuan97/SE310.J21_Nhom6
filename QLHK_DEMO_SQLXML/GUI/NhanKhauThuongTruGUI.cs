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

namespace GUI
{
    public partial class NhanKhauThuongTruGUI : Form
    {
        NhanKhauBUS nk= new NhanKhauBUS();
        NhanKhauThuongTruBUS nktt;
        TieuSuBUS tieuSu;
        public TIEUSU tieusudto;
        TienAnTienSuBUS tienAn;
        public TIENANTIENSU tienanDTO;
        public NHANKHAUTHUONGTRU nkttDTO;
        SoHoKhauBUS shk;
        TinhThanhPhoBUS ttp;
        string tenChuHo ="", lyDo="", noiDen="";
        public NhanKhauThuongTruGUI()
        {
            InitializeComponent();
            nk = new NhanKhauBUS();
            nktt = new NhanKhauThuongTruBUS();
            tieuSu = new TieuSuBUS();
            tienAn = new TienAnTienSuBUS();
            shk = new SoHoKhauBUS();
            tbMaNKTT.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
            ttp = new TinhThanhPhoBUS();

            //dGVTieuSu.DataSource = null;
            //dGVTieuSu.Rows.Clear();
            //dGVTieuSu.DataSource = nktt.GetAll().Tables["nhankhauthuongtru"];
            LoadtieuSu();
            //dGVTienAnTienSu.DataSource = tienAn.GetAll().Tables[0];
            Loadtienantiensu();
            themMaDinhDanhBang(); 

            cbbNoiCap.DisplayMember = "ten";
            cbbNoiCap.ValueMember = "matp";
            cbbNoiCap.DataSource = ttp.GetAll().Select(r=>r.ten).ToList();
            cbbNoiSinh.DisplayMember = "ten";
            cbbNoiSinh.ValueMember = "matp";
            cbbNoiSinh.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
            cbbNoiCap.SelectedValue = cbbNoiSinh.SelectedValue = "74";
        }

        #region Các hàm phụ hỗ trợ
        private void themMaDinhDanhBang()
        {
            for (int i = 0; i < dGVTieuSu.RowCount; i++)
                dGVTieuSu.Rows[i].Cells[1].Value = tbMaDinhDanh.Text;
            for (int i = 0; i < dGVTienAnTienSu.RowCount; i++)
            {
                dGVTienAnTienSu.Rows[i].Cells[1].Value = tbMaDinhDanh.Text;

            }
        }
        private void LoadtieuSu()
        {
            if (string.IsNullOrEmpty(tbMaDinhDanh.Text)) return;
            try
            {
                dGVTieuSu.DataSource = null;
                dGVTieuSu.Rows.Clear();

                ////////Sửa dữ liệu vào DataGridView
                //var bList = new BindingList<TIEUSU>(tieuSu.TimKiem("madinhdanh='" + tbmadinhdanh.Text + "'").Select(r => r.db).ToList());
                //dGVTieuSu.DataSource = new BindingSource( bList, null);

                dGVTieuSu.DataSource = DataHelper.ListToDataTableWithChange<TIEUSU>(tieuSu.TimKiem("madinhdanh='" + tbMaDinhDanh.Text + "'").Select(r => r).ToList());
                //dGVTieuSu.DataSource = DataHelper.ListToDataTableWithChange<NHANKHAUTHUONGTRU>(nktt.TimKiemJoinNhanKhau("nhankhau.madinhdanh='" + tbmadinhdanh.Text + "'").Select(r => r.dbnktt).ToList());

                for (int i = 0; i < dGVTieuSu.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTieuSu[dGVTieuSu.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Loadtienantiensu()
        {
            if (string.IsNullOrEmpty(tbMaDinhDanh.Text)) return;

            try
            {
                dGVTienAnTienSu.DataSource = null;
                dGVTienAnTienSu.Rows.Clear();

                //var bList = new BindingList<TIENANTIENSU>(tienAn.TimKiem("madinhdanh='" + tbmadinhdanh.Text + "'").Select(r => r.db).ToList());
                //dGVTienAnTienSu.DataSource = new BindingSource(bList, null);
                dGVTienAnTienSu.DataSource = DataHelper.ListToDataTableWithChange<TIENANTIENSU>(tienAn.TimKiem("madinhdanh='" + tbMaDinhDanh.Text + "'").Select(r => r).ToList());

                for (int i = 0; i < dGVTienAnTienSu.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTienAnTienSu[dGVTienAnTienSu.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillData()
        {
            tbHoTen.Text = nkttDTO.NHANKHAU.HOTEN;
            tbTenKhac.Text = nkttDTO.NHANKHAU.TENKHAC;
            rdNam.Checked = (nkttDTO.NHANKHAU.GIOITINH == "nam"); rdNu.Checked = (nkttDTO.NHANKHAU.GIOITINH == "nu");
            dtpNgaySinh.Value = nkttDTO.NHANKHAU.NGAYSINH;
            tbDanToc.Text = nkttDTO.NHANKHAU.DANTOC;
            tbNgheNghiep.Text = nkttDTO.NHANKHAU.NGHENGHIEP;
            tbMaDinhDanh.Text = nkttDTO.NHANKHAU.MADINHDANH;
            tbHoChieu.Text = nkttDTO.NHANKHAU.HOCHIEU;
            dtpNgayCap.Value = DateTime.Now;
            cbbNoiCap.SelectedValue = "74";
            tbNguyenQuan.Text = nkttDTO.NHANKHAU.NGUYENQUAN;
            cbbNoiSinh.Text = nkttDTO.NHANKHAU.NOISINH;
            tbQuocTich.Text = nkttDTO.NHANKHAU.QUOCTICH;
            tbTonGiao.Text = nkttDTO.NHANKHAU.TONGIAO;
            tbSoDienThoai.Text = nkttDTO.NHANKHAU.SDT;

            tbMaNKTT.Text = string.IsNullOrEmpty(nkttDTO.MANHANKHAUTHUONGTRU)?tbMaNKTT.Text: nkttDTO.MANHANKHAUTHUONGTRU;
            tbSoSHK.Text = string.IsNullOrEmpty(nkttDTO.SOSOHOKHAU) ?tbSoSHK.Text:nkttDTO.SOSOHOKHAU;
            tbDCThuongTru.Text = string.IsNullOrEmpty(nkttDTO.DIACHITHUONGTRU) ?tbDCThuongTru.Text:nkttDTO.DIACHITHUONGTRU;
            tbDCHienTai.Text = nkttDTO.NHANKHAU.DIACHIHIENNAY;
            tbTrinhDoHocVan.Text = nkttDTO.NHANKHAU.TRINHDOHOCVAN;
            tbTrinhDoCM.Text = nkttDTO.NHANKHAU.TRINHDOCHUYENMON;
            tbBietTiengDanToc.Text = nkttDTO.NHANKHAU.BIETTIENGDANTOC;
            tbTrinhDoNN.Text = nkttDTO.NHANKHAU.TRINHDONGOAINGU;
            tbNoiLamViec.Text = "Tỉnh Bình Dương";
            tbQHVoiCH.Text = nkttDTO.QUANHEVOICHUHO;

            LoadtieuSu();
            Loadtienantiensu();
        }

        private void cleanData()
        {
            tbHoTen.Text = "";
            tbTenKhac.Text = "";
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            tbDanToc.Text = "";
            tbNgheNghiep.Text = "";
            tbMaDinhDanh.Text = "";
            tbHoChieu.Text = "";
            dtpNgayCap.Value = DateTime.Now;
            cbbNoiCap.SelectedValue = "74";
            tbNguyenQuan.Text = "";
            cbbNoiSinh.SelectedValue = "74";
            tbQuocTich.Text = "";
            tbTonGiao.Text = "";
            tbSoDienThoai.Text = "";

            tbMaNKTT.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
            tbSoSHK.Text = string.IsNullOrEmpty(nkttDTO.SOSOHOKHAU) ? tbSoSHK.Text : nkttDTO.SOSOHOKHAU;
            tbDCThuongTru.Text = "";
            tbDCHienTai.Text = "";
            tbTrinhDoHocVan.Text = "";
            tbTrinhDoCM.Text = "";
            tbBietTiengDanToc.Text = "";
            tbTrinhDoNN.Text = "";
            tbNoiLamViec.Text = "Tỉnh Bình Dương";
            tbQHVoiCH.Text = "";

            dGVTienAnTienSu.DataSource = dGVTieuSu.DataSource = null;
        }

        private void xuatFile()
        {
            List<ReplacementGroup> rg = new List<ReplacementGroup>();

            DateTime today = DateTime.Today;
            rg.Add(new ReplacementGroup("<hoTen>", tbHoTen.Text));
            rg.Add(new ReplacementGroup("<tenKhac>", tbTenKhac.Text));
            rg.Add(new ReplacementGroup("<ngaySinh>", dtpNgaySinh.Value.ToShortDateString()));
            rg.Add(new ReplacementGroup("<gioiTinh>", rdNam.Checked ? "Nam" : "Nữ"));
            rg.Add(new ReplacementGroup("<noiSinh>", cbbNoiSinh.Text));
            rg.Add(new ReplacementGroup("<nguyenQuan>", tbNguyenQuan.Text));
            rg.Add(new ReplacementGroup("<danToc>", tbDanToc.Text));
            rg.Add(new ReplacementGroup("<tonGiao>", tbTonGiao.Text));
            rg.Add(new ReplacementGroup("<quocTich>", tbQuocTich.Text));
            rg.Add(new ReplacementGroup("<noiThuongTru>", tbDCThuongTru.Text));
            rg.Add(new ReplacementGroup("<tenChuHo>", tenChuHo));
            rg.Add(new ReplacementGroup("<qhVoiChuHo>", tbQHVoiCH.Text));
            rg.Add(new ReplacementGroup("<lyDo>", lyDo));
            rg.Add(new ReplacementGroup("<noiDen>", noiDen));


            rg.Add(new ReplacementGroup("<ngay>", today.Day.ToString()));
            rg.Add(new ReplacementGroup("<thang>", today.Month.ToString()));
            rg.Add(new ReplacementGroup("<nam>", today.Year.ToString()));


            string srcPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\Mau HK07.doc";
            string dstPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\KetQua\\Mau HK07_" + tbMaDinhDanh.Text + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".doc";
            CreateWordHelper.CreateWordDocument(srcPath, dstPath, rg);

            MessageBox.Show(this, "Đã tạo thành công file thông tin với tên: " + dstPath, "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        public NhanKhauThuongTruGUI(string sosohokhau)
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            tieuSu = new TieuSuBUS();
            tienAn = new TienAnTienSuBUS();
            shk = new SoHoKhauBUS();
            ttp = new TinhThanhPhoBUS();

            tbSoSHK.Text = sosohokhau;
            tbSoSHK.Enabled = false;
            tbMaNKTT.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
            LoadtieuSu();
            Loadtienantiensu();

            cbbNoiCap.DisplayMember = "ten";
            cbbNoiCap.ValueMember = "matp";
            cbbNoiCap.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
            cbbNoiSinh.DisplayMember = "ten";
            cbbNoiSinh.ValueMember = "matp";
            cbbNoiSinh.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
        }
        public NhanKhauThuongTruGUI(string sosohokhau, string diachithuongtru)
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            tieuSu = new TieuSuBUS();
            tienAn = new TienAnTienSuBUS();
            shk = new SoHoKhauBUS();
            ttp = new TinhThanhPhoBUS();

            tbSoSHK.Text = sosohokhau;
            tbSoSHK.Enabled = false;
            tbDCThuongTru.Text = diachithuongtru;
            tbDCThuongTru.Enabled = false;

            tbMaNKTT.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
            LoadtieuSu();
            Loadtienantiensu();

            cbbNoiCap.DisplayMember = "ten";
            cbbNoiCap.ValueMember = "matp";
            cbbNoiCap.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
            cbbNoiSinh.DisplayMember = "ten";
            cbbNoiSinh.ValueMember = "matp";
            cbbNoiSinh.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
        }

        public NhanKhauThuongTruGUI(string madinhdanh, int i, string tenChuHo = "")
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            tieuSu = new TieuSuBUS();
            tienAn = new TienAnTienSuBUS();
            shk = new SoHoKhauBUS();
            ttp = new TinhThanhPhoBUS();
            this.tenChuHo = tenChuHo;

            tbMaDinhDanh.Text = madinhdanh;
            tbSoSHK.Enabled = false;
            btnThem.Enabled = false;

            cbbNoiCap.DisplayMember = "ten";
            cbbNoiCap.ValueMember = "matp";
            cbbNoiCap.DataSource = ttp.GetAll().Select(r => r.ten).ToList();
            cbbNoiSinh.DisplayMember = "ten";
            cbbNoiSinh.ValueMember = "matp";
            cbbNoiSinh.DataSource = ttp.GetAll().Select(r => r.ten).ToList();

            List<NHANKHAUTHUONGTRU> kq = nktt.TimKiemJoinNhanKhau("nhankhau.madinhdanh='" + tbMaDinhDanh.Text + "'");
            if (kq.Count > 0)
            {
                nkttDTO = kq[0];

                fillData();
            }

            //tbMaNKTT.Text = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
            //LoadtieuSu();
            //Loadtienantiensu();
        }

        private void NhanKhauThuongTruGUI_Load(object sender, EventArgs e)
        {


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //string gioiTinh = rdNam.Checked ? "nam" : "nu";
            //try
            //{
            nkttDTO = new NHANKHAUTHUONGTRU(tbMaNKTT.Text, tbDCThuongTru.Text, tbQHVoiCH.Text, null/*tbSoSHK.Text*/, tbMaDinhDanh.Text, tbHoTen.Text, tbTenKhac.Text, dtpNgaySinh.Value,
           rdNam.Checked ? "nam" : "nu", cbbNoiSinh.Text, tbNguyenQuan.Text, tbDanToc.Text, tbTonGiao.Text, tbQuocTich.Text, tbHoChieu.Text, tbDCThuongTru.Text,
           tbDCHienTai.Text, tbSoDienThoai.Text, tbTrinhDoHocVan.Text, tbTrinhDoCM.Text, tbBietTiengDanToc.Text, tbTrinhDoNN.Text, tbNgheNghiep.Text);

            if (nktt.Add(nkttDTO))
            {
                MessageBox.Show(this, "Thành công!");

            }
            else
            {
                MessageBox.Show(this, "Lỗi!\n" + nktt.getError().Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(this, "Lỗi!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                nkttDTO = new NHANKHAUTHUONGTRU(string.IsNullOrEmpty(tbMaNKTT.Text) ? null : tbMaNKTT.Text, tbDCThuongTru.Text, tbQHVoiCH.Text, string.IsNullOrEmpty(tbSoSHK.Text) ? null : tbSoSHK.Text,
                string.IsNullOrEmpty(tbMaDinhDanh.Text) ? null : tbMaDinhDanh.Text, tbHoTen.Text, tbTenKhac.Text, dtpNgaySinh.Value,
                rdNam.Checked ? "nam" : "nu", cbbNoiSinh.Text, tbNguyenQuan.Text, tbDanToc.Text, tbTonGiao.Text, tbQuocTich.Text, tbHoChieu.Text, tbDCThuongTru.Text,
                tbDCHienTai.Text, tbSoDienThoai.Text, tbTrinhDoHocVan.Text, tbTrinhDoCM.Text, tbBietTiengDanToc.Text, tbTrinhDoNN.Text, tbNgheNghiep.Text);

                if (nktt.Update(nkttDTO))
                {
                    MessageBox.Show(this, "Thành công!");

                }
                else
                {
                    MessageBox.Show(this, "Lỗi!\n" + nktt.getError().Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, "Lỗi!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbMaNKTT.Text))
                {
                    MessageBox.Show(this, "Thiếu!", "Vui Lòng nhập mã nhân khẩu hoặc mã thường trú", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (ChuyenKhauGUI ck = new ChuyenKhauGUI())
                {
                    ck.ShowDialog(this);
                    this.lyDo = ck.lyDo;
                    this.noiDen = ck.noiDen;
                    xuatFile();
                    if (nktt.XoaNKTT(nkttDTO))
                    {
                        MessageBox.Show(this, "Thành công!");
                        nkttDTO = new NHANKHAUTHUONGTRU();
                        cleanData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi!\n" + nktt.getError().Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Lỗi!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbDCThuongTru_Enter(object sender, EventArgs e)
        {

            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbDCThuongTru.Text = a.diaChi;
            }
        }

        private void tbDCHienTai_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbDCHienTai.Text = a.diaChi;
            }
        }

        private void tbnguyenquan_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbNguyenQuan.Text = a.diaChi;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if(nkttDTO != null) nktt.XoaNKTT(nkttDTO);
            nkttDTO = null;
            this.Close();
        }
       
        private void useradd(DataGridView data)
        {
            try
            {
                int lastRow = data.Rows.Count - 2;
                DataGridViewRow nRow = data.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                data[data.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Insert";
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void doubleclick(DataGridView data, int lastRow)
        {
            try
            {
                DataGridViewRow nRow = data.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                data[data.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dGVTieuSu_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            useradd(dGVTieuSu);
            int lastRow = dGVTieuSu.Rows.Count - 2;
            dGVTieuSu[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaTieuSu());
            dGVTieuSu[1, lastRow].Value = tbMaDinhDanh.Text.ToString();
        }

        private void dGVTieuSu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclick(dGVTieuSu, e.RowIndex);
        }

        private void dGVTienAnTienSu_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            useradd(dGVTienAnTienSu);
            int lastRow = dGVTienAnTienSu.Rows.Count - 2;
            dGVTienAnTienSu[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaTienAnTienSu());
            dGVTienAnTienSu[1, lastRow].Value = tbMaDinhDanh.Text.ToString();
        }

        private void dGVTienAnTienSu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclick(dGVTienAnTienSu, e.RowIndex);
        }

        private void dGVTieuSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dGVTieuSu.ColumnCount - 1)
                {
                    string Task = dGVTieuSu.Rows[e.RowIndex].Cells[dGVTieuSu.ColumnCount - 1].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            string matieusu = dGVTieuSu.Rows[rowIndex].Cells["matieusu"].Value.ToString();
                            tieuSu.DeleteTS(matieusu);
                            LoadtieuSu();
                        }
                    }
                    else if (Task == "Insert")
                    {
                        int row = dGVTieuSu.Rows.Count - 2;
                        string matieusu = dGVTieuSu.Rows[row].Cells["matieusu"].Value.ToString();
                        string madinhdanh = dGVTieuSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string thoigianbatdau = dGVTieuSu.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                        DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                        string thoigianketthuc = dGVTieuSu.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                        DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                        string choo = dGVTieuSu.Rows[row].Cells["choo"].Value.ToString();
                        string manghenghiep = dGVTieuSu.Rows[row].Cells["nghenghiep"].Value.ToString();
                        string noilamviec = dGVTieuSu.Rows[row].Cells["noilamviec"].Value.ToString();
                        tieusudto = new TIEUSU(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                        tieuSu.Add_Table(tieusudto);
                        dGVTieuSu.Rows.RemoveAt(dGVTieuSu.Rows.Count - 2);
                        dGVTieuSu.Rows[e.RowIndex].Cells[dGVTieuSu.ColumnCount - 1].Value = "Delete";

                        LoadtieuSu();
                    }
                    else if (Task == "Update")
                    {
                        int row = e.RowIndex;
                        string matieusu = dGVTieuSu.Rows[row].Cells["matieusu"].Value.ToString();
                        string madinhdanh = dGVTieuSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string thoigianbatdau = dGVTieuSu.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                        DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                        string thoigianketthuc = dGVTieuSu.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                        DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                        string choo = dGVTieuSu.Rows[row].Cells["choo"].Value.ToString();
                        string manghenghiep = dGVTieuSu.Rows[row].Cells["nghenghiep"].Value.ToString();
                        string noilamviec = dGVTieuSu.Rows[row].Cells["noilamviec"].Value.ToString();
                        tieusudto = new TIEUSU(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                        tieuSu.Update(tieusudto);
                        LoadtieuSu();
                    }
                }
            }
            catch(Exception ex)
                    {
                MessageBox.Show(ex.Message);
            }
        }

        private void dGVTienAnTienSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dGVTienAnTienSu.ColumnCount - 1)
                {
                    string Task = dGVTienAnTienSu.Rows[e.RowIndex].Cells[dGVTienAnTienSu.ColumnCount - 1].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            string matienantiensu = dGVTienAnTienSu.Rows[rowIndex].Cells["matienantiensu"].Value.ToString();
                            tienAn.DeleteTATS(matienantiensu);
                            Loadtienantiensu();
                        }
                    }
                    else if (Task == "Insert")
                    {
                        int row = dGVTienAnTienSu.Rows.Count - 2;
                        string matienantiensu = dGVTienAnTienSu.Rows[row].Cells["matienantiensu"].Value.ToString();
                        string madinhdanh = dGVTienAnTienSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string banan = dGVTienAnTienSu.Rows[row].Cells["banan"].Value.ToString();
                        string toidanh = dGVTienAnTienSu.Rows[row].Cells["toidanh"].Value.ToString();
                        string hinhphat = dGVTienAnTienSu.Rows[row].Cells["hinhphat"].Value.ToString();
                        string ngayphat = dGVTienAnTienSu.Rows[row].Cells["ngayphat"].Value.ToString();
                        DateTime date_ngayphat = DateTime.Parse(ngayphat);
                        //string ghichu = dGVTienAnTienSu.Rows[row].Cells["ghichu"].Value.ToString();
                        tienanDTO = new TIENANTIENSU(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat);
                        tienAn.Add_Table(tienanDTO);
                        dGVTienAnTienSu.Rows.RemoveAt(dGVTienAnTienSu.Rows.Count - 2);
                        dGVTienAnTienSu.Rows[e.RowIndex].Cells[dGVTienAnTienSu.ColumnCount - 1].Value = "Delete";

                        Loadtienantiensu();
                    }
                    else if (Task == "Update")
                    {
                        int row = e.RowIndex;
                        string matienantiensu = dGVTienAnTienSu.Rows[row].Cells["matienantiensu"].Value.ToString();
                        string madinhdanh = dGVTienAnTienSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string banan = dGVTienAnTienSu.Rows[row].Cells["banan"].Value.ToString();
                        string toidanh = dGVTienAnTienSu.Rows[row].Cells["toidanh"].Value.ToString();
                        string hinhphat = dGVTienAnTienSu.Rows[row].Cells["hinhphat"].Value.ToString();
                        string ngayphat = dGVTienAnTienSu.Rows[row].Cells["ngayphat"].Value.ToString();
                        DateTime date_ngayphat = DateTime.Parse(ngayphat);
                        //string ghichu = dGVTienAnTienSu.Rows[row].Cells["ghichu"].Value.ToString();
                        tienanDTO = new TIENANTIENSU(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat);
                        tienAn.Update(tienanDTO);
                        Loadtienantiensu(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbmadinhdanh_Enter(object sender, EventArgs e)
        {
            string gioiTinh = rdNam.Checked ? "nam" : "nu";
            try
            {
                tbMaDinhDanh.Text = string.IsNullOrEmpty(tbMaDinhDanh.Text) ?TrinhTaoMa.TangMa12Kytu(gioiTinh, dtpNgaySinh.Value.Year.ToString()): tbMaDinhDanh.Text;
                tbMaDinhDanh.SelectAll();
                //tbmadinhdanh.SelectionStart = 0;
                //tbmadinhdanh.SelectionLength = tbmadinhdanh.Text.Length;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbmadinhdanh_TextChanged(object sender, EventArgs e)
        {
            LoadtieuSu();
            Loadtienantiensu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<NHANKHAUTHUONGTRU> kq = nktt.TimKiemJoinNhanKhau("nhankhau.madinhdanh='" + tbMaDinhDanh.Text + "'");
            if (kq.Count > 0)
            {
                nkttDTO = kq[0];

                fillData();
            }
            else
            {
                List<NHANKHAU> kqnk = nk.TimKiem("madinhdanh='" + tbMaDinhDanh.Text + "'");
                if (kqnk.Count>0)
                {
                    nkttDTO = new NHANKHAUTHUONGTRU(kqnk[0]);
                    fillData();
                }
                else 
                    MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void btnTimKiemTT_Click(object sender, EventArgs e)
        {
            List<NHANKHAUTHUONGTRU> kq = nktt.TimKiemJoinNhanKhau("manhankhauthuongtru='" + tbMaNKTT.Text + "'");
            if (kq.Count > 0)
            {
                nkttDTO = kq[0];

                fillData();
            }
            else
            {
                MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NhanKhauThuongTruGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
