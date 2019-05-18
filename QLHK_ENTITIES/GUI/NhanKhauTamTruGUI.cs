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
    public partial class NhanKhauTamTruGUI : Form
    {
        NhanKhauTamTruBUS nkttBus;
        NhanKhauTamTruDTO nkttDto;
        NhanKhauBUS nk = new NhanKhauBUS();
        TieuSuBUS tieusuBus = new TieuSuBUS();
        TienAnTienSuBUS tienantiensuBus = new TienAnTienSuBUS();
        
        SoTamTruBUS soTamTruBUS;

        string madinhdanhForInsert = "";
        string madinhdanhForSearch = "";

        private List<string> nhankhautamtru_list = new List<string>(); //Gửi list tên nhân khẩu về màn hình sổ tạm trú để chọn chủ hộ


        private string sosotamtru = "";
        public List<string> Nhankhautamtru_list
        {
            get { return nhankhautamtru_list; }
            set { nhankhautamtru_list = value; }
        }

        ///
        ///TẠO MÃ TỰ ĐỘNG
        SoTamTruBUS sotamtru;
        //Tạo mã tiền án tiền sự
        public string GenerateMaTienAnTienSu()
        {
            sotamtru = new SoTamTruBUS();
            string last_ID = TrinhTaoMa.getLastID_MaTienAnTienSu();
            return TrinhTaoMa.TangMa9kytu(last_ID);
        }


        //Tạo mã tiểu sử
        public string GenerateMaTieuSu()
        {
            string last_ID = TrinhTaoMa.getLastID_MaTieuSu();
            return TrinhTaoMa.TangMa9kytu(last_ID);
        }

        //Tạo mã nhân khẩu tạm trú
        public string GenerateMaNhanKhauTamTru()
        {
            string last_ID = TrinhTaoMa.getLastID_MaNhanKhauTamTru();
            return TrinhTaoMa.TangMa9kytu(last_ID);
        }

        /// <summary>
        /// Phát sinh mã định danh ở đây
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public string GioiTinh()
        {
            if (rdNam.Checked) return "nam";
            else return "nu";
        }

        public void TaoMaDinhDanh()
        {
            string gt = GioiTinh();
            string year = dt_NgaySinh.Value.Year.ToString();
            txtMaDinhDanh1.Text = TrinhTaoMa.TangMa12Kytu(gt, year);
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dt_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            GenerateAllID();
        }




        public void GenerateAllID()
        {
            ResetValueInput();
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
            txt_MaTieuSu.Text = GenerateMaTieuSu();
            txtMaNhanKhauTamTru1.Text = GenerateMaNhanKhauTamTru();
            TaoMaDinhDanh();
            LoadDataGridView();
        }

        ///KẾT THÚC TẠO MÃ TỰ ĐỘNG
        ///


        ///Kiểm tra null input
        public bool isInputTrueThongTinTamTru()
        {
            if (txt_HoTen.Text.ToString() == "" || txt_DanToc.Text.ToString()=="" 
                || txt_NgheNghiep.Text.ToString()=="" || txt_QuocTich.Text.ToString() == "" 
                || txt_NguyenQuan.Text.ToString()=="" || txtNoiSinh.Text.ToString() == "" 
                ||txtDiaChiHienNay.Text.ToString()=="" ||txtNoiThuongTru.Text.ToString()=="" 
                ||txtNoiTamTru.Text.ToString()=="")
            {
                return false;
            }
            return true;
        }

        public bool isInputTrueTieuSu()
        {
            if (txt_TieuSu_NgheNghiep.Text.ToString() == "") return false;
            return true;
        }

        public bool isInputTrueTienAn()
        {
            if(txt_HinhPhat.Text.ToString()=="" || txt_BanAn.Text.ToString()=="" || txtToiDanh.Text.ToString() == "")
            {
                return false;
            }
            return true;
        }


        ///Kết thúc Kiểm tra null input


        //Xóa các trường Input
        public void ResetValueInput()
        {
            txtMaDinhDanh1.Clear();
            txtMaNhanKhauTamTru1.Clear();
            txt_DanToc.Clear();
            txt_HoChieu.Clear();
            txt_HoTen.Clear();
            txt_QuocTich.Clear();
            txt_SoDienThoai.Clear();
            txt_NgheNghiep.Clear();
            txt_TonGiao.Clear();
            txt_TrinhDoHocVan.Clear();
            txt_TrinhDoChuyenMon.Clear();
            txt_BietTiengDanToc.Clear();
            txt_TrinhDoNgoaiNgu.Clear();
            txt_LyDo.Clear();
            txt_TenKhac.Clear();
            txt_NguyenQuan.Clear();
            txtNoiSinh.Clear();
            txtDiaChiHienNay.Clear();
            txtNoiThuongTru.Clear();
            txtNoiTamTru.Clear();
            dt_DenNgay.ResetText();
            dt_TuNgay.ResetText();
            dt_NgaySinh.ResetText();
            ResetInputTienAn();
            ResetInputTieuSu();
            TaoMaDinhDanh();
           
        }

        //Cập nhật datagridview
        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.GetAllNhanKhauTamTru(txtSoSoTamTru1.Text.ToString());

            LoadDataGridViewTienAN();
            LoadDataGridViewTieuSu();
        }

        //constructor for create a citizen
        public NhanKhauTamTruGUI(string Sosotamtru)
        {
            InitializeComponent();
            this.sosotamtru = Sosotamtru;
            dtGV_TienAnTienSu.DataSource = DataHelper.ListToDatatable<TIENANTIENSU>(tienantiensuBus.GetAll().Select(r=>r.db).ToList());

        }

        //constructor for search a ciziten
        public NhanKhauTamTruGUI(string madinhdanh, string type)
        {
            InitializeComponent();
            madinhdanhForSearch = madinhdanh;
        }

        //constructor for search
        public NhanKhauTamTruGUI()
        {
            InitializeComponent();
        }


        private void NhanKhauTamTruGUI_Load(object sender, EventArgs e)
        {
            nkttBus = new NhanKhauTamTruBUS();

            if (madinhdanhForSearch != "")
            {
                txtMaDinhDanh1.Text = madinhdanhForSearch;
                btnTim1_Click(sender, e);
            }
            else
            {            
                txtSoSoTamTru1.Text = sosotamtru;
                LoadDataGridView();
                GenerateAllID();
            }
        }

        //Thêm một nhân khẩu tạm trú
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Thêm sổ tạm trú nếu chưa có
            soTamTruBUS = new SoTamTruBUS();
            string sosotamtru = txtSoSoTamTru1.Text.ToString();

            //Chua co so tam tru nay
            if (!soTamTruBUS.ExistedSoTamTru(sosotamtru))
            {
                SoTamTruDTO stt = new SoTamTruDTO(sosotamtru, "", "", DateTime.Now, DateTime.Now);
                if (soTamTruBUS.Add(stt))
                {

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }



            string manhankhautamtru = txtMaNhanKhauTamTru1.Text.ToString();
            string madinhdanh = txtMaDinhDanh1.Text.ToString();

            if (manhankhautamtru == "" || madinhdanh == "")
            {
                MessageBox.Show("Cần có mã nhân khẩu tạm trú và mã định danh để thực hiện chức năng này");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueThongTinTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            string hoten = txt_HoTen.Text.ToString();


            //Kiểm tra tổng ngày tạm trú không quá 2 năm
            DateTime ngaycap = dt_TuNgay.Value.Date;
            DateTime denngay = dt_DenNgay.Value.Date;

            double ngay = (denngay - ngaycap).TotalDays;
            double sum = 730;
            if (ngay > 730)
            {
                MessageBox.Show("Thời gian tạm trú tối đa không quá 2 năm");
                return;
            }


            string diachihiennay =txtDiaChiHienNay.Text.ToString();
            
            

            string nghenghiep = txt_NgheNghiep.Text.ToString();


            string gioitinh = "";
            if (rdNam.Checked) gioitinh = "nam";
            else gioitinh = "nu";


            string dantoc = txt_DanToc.Text.ToString();
            string hochieu = txt_HoChieu.Text.ToString();
            DateTime ngaysinh = dt_NgaySinh.Value.Date;
            string nguyenquan = txt_NguyenQuan.Text.ToString();
            string noisinh = txtNoiSinh.Text.ToString();
            string quoctich = txt_QuocTich.Text.ToString();
            string sdt = txt_SoDienThoai.Text.ToString();
            string tongiao = txt_TonGiao.Text.ToString();

            //Thêm
            string tenkhac = txt_TenKhac.Text.ToString();
            string trinhdohocvan = txt_TrinhDoHocVan.Text.ToString();
            string trinhdochuyenmon = txt_TrinhDoChuyenMon.Text.ToString();
            string biettiengdantoc = txt_BietTiengDanToc.Text.ToString();
            string trinhdongoaingu = txt_TrinhDoNgoaiNgu.Text.ToString();



            string noithuongtru = txtNoiThuongTru.Text.ToString();
            string noitamtru =txtNoiTamTru.Text.ToString();

            string lydo = txt_LyDo.Text.ToString();
            //THêm
            


            nkttDto = new NhanKhauTamTruDTO(manhankhautamtru, noitamtru, ngaycap, denngay, lydo, 
                sosotamtru, madinhdanh, hoten, tenkhac, ngaysinh, gioitinh, noisinh, nguyenquan, 
                dantoc, tongiao, quoctich, hochieu, noithuongtru, diachihiennay, sdt, trinhdohocvan, 
                trinhdochuyenmon, biettiengdantoc, trinhdongoaingu, nghenghiep);


            if (nkttBus.Add(nkttDto))
            {
                MessageBox.Show("Thêm nhân khẩu tạm trú " + hoten + " thành công");
                nhankhautamtru_list.Add(txt_HoTen.Text.ToString());
                ResetValueInput();
                LoadDataGridView();

                //Tạo mã tự động
                GenerateAllID();
            }
            else
            {
                MessageBox.Show("Thêm nhân khẩu tạm trú " + hoten + "thất bại");
            }
        }


        //Sửa thông tin nhân khẩu tạm trú
        private void btnSua_Click(object sender, EventArgs e)
        {

            string manhankhautamtru = txtMaNhanKhauTamTru1.Text.ToString(); //Lấy mã nhân khẩu tạm trú
            string madinhdanh = txtMaDinhDanh1.Text.ToString(); //Lấy mã định danh
            string hoten = txt_HoTen.Text.ToString();

            if (manhankhautamtru == "" || madinhdanh == "" || hoten=="")
            {
                MessageBox.Show("Cần có mã định danh và họ tên để thực hiện chức năng này");
                return;
            }

          //  madinhdanh = madinhdanhForInsert;

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + hoten + " không tồn tại !");
                return;
            }

            NhanKhauTamTruBUS nktt = new NhanKhauTamTruBUS();

            //Nhập không đầy đủ
            if (!isInputTrueThongTinTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật thông tin nhân khẩu: "+hoten+" không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string diachihiennay = txtDiaChiHienNay.Text.ToString();
                string sosotamtru = txtSoSoTamTru1.Text.ToString();
                string nghenghiep = txt_NgheNghiep.Text.ToString();

                string gioitinh = "";
                if (rdNam.Checked) gioitinh = "Nam";
                else gioitinh = "Nữ";

                string dantoc = txt_DanToc.Text.ToString();
                string hochieu = txt_HoChieu.Text.ToString();
                DateTime ngaysinh = dt_NgaySinh.Value.Date;
                string nguyenquan = txt_NguyenQuan.Text.ToString();
                string noisinh = txtNoiSinh.Text.ToString();
                string quoctich = txt_QuocTich.Text.ToString();
                string sdt = txt_SoDienThoai.Text.ToString();
                string tongiao = txt_TonGiao.Text.ToString();

                //Thêm
                string tenkhac = txt_TenKhac.Text.ToString();
                string trinhdohocvan = txt_TrinhDoHocVan.Text.ToString();
                string trinhdochuyenmon = txt_TrinhDoChuyenMon.Text.ToString();
                string biettiengdantoc = txt_BietTiengDanToc.Text.ToString();
                string trinhdongoaingu = txt_TrinhDoNgoaiNgu.Text.ToString();

                SoTamTruBUS sotamtrubus = new SoTamTruBUS();

                DateTime tungay = dt_TuNgay.Value.Date;

                DateTime denngay = dt_DenNgay.Value.Date;

                string noithuongtru = txtNoiThuongTru.Text.ToString();
                string noitamtru = txtNoiTamTru.Text.ToString();

                string lydo = txt_LyDo.Text.ToString();
                //THêm


                nkttDto = new NhanKhauTamTruDTO(manhankhautamtru, noitamtru, tungay, denngay, lydo,
                sosotamtru, madinhdanh, hoten, tenkhac, ngaysinh, gioitinh, noisinh, nguyenquan,
                dantoc, tongiao, quoctich, hochieu, noithuongtru, diachihiennay, sdt, trinhdohocvan,
                trinhdochuyenmon, biettiengdantoc, trinhdongoaingu, nghenghiep);
                if (nkttBus.Update(nkttDto))
                {
                    MessageBox.Show("Cập nhật thông tin nhân khẩu "+hoten+" thành công");
                    LoadDataGridView();
                    ResetValueInput();
                    GenerateAllID();
                    dataGridView1.DataSource = nkttBus.GetAllNhanKhauTamTru(sosotamtru);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân khẩu "+hoten+" thất bại");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            } 
           
        }


        //Xóa một nhân khẩu tạm trú
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string madinhdanh = txtMaDinhDanh1.Text.ToString();
            string hoten = txt_HoTen.Text.ToString();

            if (madinhdanh == "")
            {
                MessageBox.Show("Cần mã định danh để thực hiện chức năng này");
                return;
            }


            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + hoten + " không tồn tại !");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn hủy tạm trú cho nhân khẩu: "+hoten+" ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.XoaNKTT(madinhdanh))
                {
                    MessageBox.Show("Hủy tạm trú nhân khẩu : "+hoten+" thành công!");
                    ResetValueInput();
                    LoadDataGridView();
                    GenerateAllID();
                }
                else
                {
                    MessageBox.Show("Hủy tạm trú nhân khẩu : " + hoten + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }

        }




        /// <summary>
        /// XỬ LÍ VỚI GROUP TIỀN ÁN TIỀN SỰ
        /// </summary>
        

        private void LoadDataGridViewTienAN()
        {
            dtGV_TienAnTienSu.DataSource = null;
            dtGV_TienAnTienSu.Rows.Clear();

            if (string.IsNullOrEmpty(txtMaDinhDanh1.Text)) return;
            try
            {

                //DataTable tb = DataHelper.ListToDatatable<TIENANTIENSU>(tienantiensuBus.TimKiem("madinhdanh='" + txtMaDinhDanh1.Text + "'").Select(r => r.db).ToList());
                //tb.Columns.RemoveAt(tb.Columns.Count - 1);

                //dtGV_TienAnTienSu.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetInputTienAn()
        {
            txt_MaTienAn.Clear();
            txt_BanAn.Clear();
            txtToiDanh.Clear();
            txt_HinhPhat.Clear();
            dtNgayPhat.ResetText();
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
        }


        private void btnThemTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();
            string madinhdanh = txtMaDinhDanh1.Text.ToString();

            if (matienan == "" || madinhdanh == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự, mã định danh để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Cần tạo thông tin tạm trú cho nhân khẩu có mã định danh:" + madinhdanh + " trước khi thêm tiền án tiền sự");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTienAn())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }


            string banan = txt_BanAn.Text.ToString();
            string toidanh = txtToiDanh.Text.ToString();
            string hinhphat = txt_HinhPhat.Text.ToString();
            DateTime ngayphat = dtNgayPhat.Value.Date;

            TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh,toidanh,hinhphat, banan,ngayphat);
            if (tienantiensuBus.Add(tienan))
            {
                MessageBox.Show("Thêm tiền án tiền sự " + matienan + " cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                LoadDataGridViewTienAN();
            }
            else
            {
                MessageBox.Show("Thêm tiền án tiền sự " + matienan + " cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
            }

        }

        //Click cell datagridview Tiền án
        private void dtGV_TienAnTienSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matienan = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[0].Value.ToString();
            string madinhdanh = txtMaDinhDanh1.Text.ToString();
            string toidanh = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[2].Value.ToString();
            string hinhphat = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[3].Value.ToString();
            string banan = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[4].Value.ToString();


            DateTime ngayphat = Convert.ToDateTime(dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[5].Value.ToString());


            TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan,madinhdanh,banan,toidanh,hinhphat,ngayphat);

            txt_MaTienAn.Text = tienan.db.MATIENANTIENSU;
            txt_BanAn.Text = tienan.db.BANAN;
            txtToiDanh.Text = tienan.db.TOIDANH;
            txt_HinhPhat.Text = tienan.db.HINHPHAT;
            dtNgayPhat.Value = tienan.db.NGAYPHAT; 


        }



        private void btnXoaTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();

            if (matienan == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự để thực hiện chức năng này");
                return;
            }

      
            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TienAn(matienan))
            {
                MessageBox.Show("Mã tiền án " + matienan + "không tồn tại trong hệ thống!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa tiền án tiền sự "+matienan+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.DeleteTienAnTienSu(matienan))
                {
                    MessageBox.Show("Xóa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    LoadDataGridViewTienAN();
                    
                }
                else
                {
                    MessageBox.Show("Xóa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }


        }
        
  
        private void btnSuaTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();

            if (matienan == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TienAn(matienan))
            {
                MessageBox.Show("Mã tiền án " + matienan + "không tồn tại trong hệ thống!");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTienAn())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa tiền án tiền sự "+matienan+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string madinhdanh = txtMaDinhDanh1.Text.ToString();
                string banan = txt_BanAn.Text.ToString();
                string toidanh = txtToiDanh.Text.ToString();
                string hinhphat = txt_HinhPhat.Text.ToString();
                DateTime ngayphat = dtNgayPhat.Value.Date;


                TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh, banan, toidanh, hinhphat, ngayphat);

                if (tienantiensuBus.Update(tienan))
                {
                    MessageBox.Show("Sửa tiền án tiền sự " + matienan + " cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    ResetInputTienAn();
                    LoadDataGridViewTienAN();
                }
                else
                {
                    MessageBox.Show("Sửa tiền án tiền sự " + matienan + " cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }



        /// <summary>
        /// XỬ LÍ VỚI TIỂU SỬ
        /// </summary>
        /// 
        public void LoadDataGridViewTieuSu()
        {
            dtGV_TieuSu.DataSource = null;
            dtGV_TieuSu.Rows.Clear();

            if (string.IsNullOrEmpty(txtMaDinhDanh1.Text)) return;
            try
            {

                DataTable tb = DataHelper.ListToDataTableWithChange<TIEUSU>(tieusuBus.TimKiem("madinhdanh='" + txtMaDinhDanh1.Text + "'").Select(r => r.db).ToList());
                tb.Columns.RemoveAt(tb.Columns.Count - 1);

                dtGV_TieuSu.DataSource = tb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ResetInputTieuSu()
        {
            txt_MaTieuSu.Clear();
            dtThoiGianBatDau.ResetText();
            dtThoiGianKetThuc.ResetText();
            txt_NoiLamViec.Clear();
            txt_MaTieuSu.Text = GenerateMaTieuSu();
            txt_TieuSu_NgheNghiep.Clear();
            txtChoO.Clear();
        }



        private void btnThemTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();
            string madinhdanh = txtMaDinhDanh1.Text.ToString();
            DateTime thoigianbatdau = dtThoiGianBatDau.Value.Date;
            DateTime thoigianketthuc = dtThoiGianKetThuc.Value.Date;
            string choo = txtChoO.Text.ToString();
            string nghenghiep = txt_TieuSu_NgheNghiep.Text.ToString();
            string noilamviec = txt_NoiLamViec.Text.ToString();

            if(matieusu=="")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Cần tạo thông tin tạm trú cho nhân khẩu có mã định danh:" + madinhdanh + " trước khi thêm tiểu sử");
                return;
            }


            //Nhập không đầy đủ
            if (!isInputTrueTieuSu())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, nghenghiep, noilamviec);


            if (tieusuBus.Add(tieusu))
            {
                MessageBox.Show("Thêm tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công !");
                LoadDataGridViewTieuSu();
                ResetInputTieuSu();
            }
            else
            {
                MessageBox.Show("Thêm tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại !");
            }

        }

        private void dtGV_TieuSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matieusu = dtGV_TieuSu.Rows[e.RowIndex].Cells[0].Value.ToString();
            string madinhdanh = txtMaDinhDanh1.Text;
            DateTime thoigianbatdau = Convert.ToDateTime(dtGV_TieuSu.Rows[e.RowIndex].Cells[2].Value.ToString());
            DateTime thoigianketthuc = Convert.ToDateTime(dtGV_TieuSu.Rows[e.RowIndex].Cells[3].Value.ToString());
            string choo = dtGV_TieuSu.Rows[e.RowIndex].Cells[4].Value.ToString();
            string nghenghiep = dtGV_TieuSu.Rows[e.RowIndex].Cells[5].Value.ToString();
            string noilamviec = dtGV_TieuSu.Rows[e.RowIndex].Cells[6].Value.ToString();


            TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, nghenghiep, noilamviec);

            txt_MaTieuSu.Text = tieusu.db.MATIEUSU;
            dtThoiGianBatDau.Value = tieusu.db.THOIGIANBATDAU;
            dtThoiGianKetThuc.Value = tieusu.db.THOIGIANKETTHUC;
            txt_NoiLamViec.Text = tieusu.db.NOILAMVIEC;
            txt_TieuSu_NgheNghiep.Text = tieusu.db.NGHENGHIEP;
            txtChoO.Text = choo;
        }


        private void btnXoaTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();
            if (matieusu == "")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }
            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TieuSu(matieusu))
            {
                MessageBox.Show("Tiểu sử có mã " + matieusu + "chưa có trong hệ thống");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.DeleteTieuSu(matieusu))
                {
                    MessageBox.Show("Xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    LoadDataGridViewTieuSu();
                    ResetInputTieuSu();
                }
                else
                {
                    MessageBox.Show("Xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void btnSuaTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();

            if (matieusu == "")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TieuSu(matieusu))
            {
                MessageBox.Show("Tiểu sử có mã " + matieusu + "chưa có trong hệ thống");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTieuSu())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa tiểu sử "+matieusu+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string madinhdanh = txtMaDinhDanh1.Text.ToString();
                DateTime thoigianbatdau = dtThoiGianBatDau.Value.Date;
                DateTime thoigianketthuc = dtThoiGianKetThuc.Value.Date;
                string choo = txtChoO.Text.ToString();
                string nghenghiep = txt_TieuSu_NgheNghiep.Text.ToString();
                string noilamviec = txt_NoiLamViec.Text.ToString();
                

                TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, nghenghiep, noilamviec);


                if (tieusuBus.Update(tieusu))
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thành công !");
                }
                else
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thất bại !");
                }

                
            }

            LoadDataGridViewTieuSu();
            ResetInputTieuSu();

        }


        //Gia hạn tạm trú
        private void btnGiaHan_Click(object sender, EventArgs e)
        {

            string sosotamtru = txtSoSoTamTru1.Text.ToString();
            string madinhdanh = txtMaDinhDanh1.Text.ToString();


            //Kiểm tra sự tồn tại của mã định danh
            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + txt_HoTen.Text.ToString() + " không tồn tại !");
                return;
            }

            //Không cho phép sửa ngày bắt đầu tạm trú
            DateTime TuNgay = nkttBus.TimNgayDangKyTamTru(madinhdanh);
            if (TuNgay != dt_TuNgay.Value.Date)
            {
                MessageBox.Show("Không cho phép sửa ngày bắt đầu tạm trú");
                return;
            }

            DateTime denngay = dt_DenNgay.Value.Date;


            double songaygiahan = nkttBus.CheckGiaHan(denngay, madinhdanh);
            DateTime today = DateTime.Today;
            DateTime ngaytoida = today.AddDays(songaygiahan);
            if (songaygiahan != 0)
            {
                MessageBox.Show("Số ngày có thể gia hạn thêm là:" + songaygiahan + "!" + Environment.NewLine + "Ngày có thể gia hạn đến:" + ngaytoida);
                return;
            }


            DialogResult dialogResult = MessageBox.Show("Bạn có muốn gia hạn cho nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (nkttBus.InsertGiaHan(madinhdanh, denngay))
                {
                    MessageBox.Show("Gia hạn cho nhân khẩu" + txt_HoTen.Text.ToString() + " thành công!");
                    LoadDataGridView();
                    ResetValueInput();
                }
                else
                {
                    MessageBox.Show("Gia hạn cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void txt_NguyenQuan_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txt_NguyenQuan.Text = a.diaChi;
            }
        }

        private void txtNoiSinh_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txtNoiSinh.Text = a.diaChi;
            }
        }

        private void txtDiaChiHienNay_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txtDiaChiHienNay.Text = a.diaChi;
            }
        }

        private void txtNoiThuongTru_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txtNoiThuongTru.Text = a.diaChi;
            }
        }

        private void txtNoiTamTru_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txtNoiTamTru.Text = a.diaChi;
            }
        }

        private void txtChoO_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    txtChoO.Text = a.diaChi;
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            GenerateAllID();

        }

        private void btnXong1_Click(object sender, EventArgs e)
        {
            Nhankhautamtru_list = nhankhautamtru_list;
        }

        private void btnTim1_Click(object sender, EventArgs e)
        {
            string madinhdanh = txtMaDinhDanh1.Text.ToString();
            if (madinhdanh == "")
            {
                MessageBox.Show("Cần mã định danh để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú có mã định danh: " + madinhdanh + " không tồn tại!");
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            List<NhanKhauTamTruDTO> kq = nkttBus.TimKiemNKTT(madinhdanh);
            List<NhanKhauDTO> kqnk = nk.TimKiem("madinhdanh='" + madinhdanh + "'");
            if (kq.Count > 0)
            {
                NhanKhauTamTruDTO nktt = kq[0];
                nkttDto = new NhanKhauTamTruDTO(nktt);
            }
            else
            {
                kqnk = nk.TimKiem("madinhdanh='" + madinhdanh + "'");
                if (kqnk.Count > 0)
                {
                    nkttDto = new NhanKhauTamTruDTO(kqnk[0].db);
                    //fillData();
                }
                else
                    MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataTable t1 = DataHelper.ListToDataTableWithChange<NHANKHAU>(kqnk.Select(r => r.db).ToList());
            DataTable t2 = DataHelper.ListToDataTableWithChange<NHANKHAUTAMTRU>(kq.Select(r => r.dbnktamtru).ToList());

            dataGridView1.DataSource = DataHelper.mergeTwoTables(t1, t2, "MADINHDANH");

            if (kq.Count > 0)
            {
                NhanKhauTamTruDTO dt = kq[0];
                nkttDto = new NhanKhauTamTruDTO(dt);

                //fillData();
            }
            else
            {
                MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void fillData()
        {
            txt_HoTen.Text = nkttDto.db.HOTEN;
            txt_TenKhac.Text = nkttDto.db.TENKHAC;
            rdNam.Checked = (nkttDto.db.GIOITINH == "Nam");
            rdNu.Checked = (nkttDto.db.GIOITINH == "Nữ");
            dt_NgaySinh.Value = nkttDto.db.NGAYSINH;
            txt_DanToc.Text = nkttDto.db.DANTOC;
            txt_NgheNghiep.Text = nkttDto.db.NGHENGHIEP;
            txtMaDinhDanh1.Text = nkttDto.db.MADINHDANH;
            txt_HoChieu.Text = nkttDto.db.HOCHIEU;

            txt_NguyenQuan.Text = nkttDto.db.NGUYENQUAN;
            txtNoiSinh.Text = nkttDto.db.NOISINH;
            txt_QuocTich.Text = nkttDto.db.QUOCTICH;
            txt_TonGiao.Text = nkttDto.db.TONGIAO;
            txt_SoDienThoai.Text = nkttDto.db.SDT;

            txtMaNhanKhauTamTru1.Text = nkttDto.dbnktamtru.MANHAKHAUTAMTRU;
            
            txtDiaChiHienNay.Text = nkttDto.db.DIACHIHIENNAY;

            txt_TrinhDoHocVan.Text = nkttDto.db.TRINHDOHOCVAN;
            txt_TrinhDoChuyenMon.Text = nkttDto.db.TRINHDOCHUYENMON;
            txt_BietTiengDanToc.Text = nkttDto.db.BIETTIENGDANTOC;
            txt_TrinhDoNgoaiNgu.Text = nkttDto.db.TRINHDONGOAINGU;

            txtNoiThuongTru.Text = nkttDto.db.NOITHUONGTRU;
            txtNoiTamTru.Text = nkttDto.dbnktamtru.NOITAMTRU;

            dt_TuNgay.Value = nkttDto.dbnktamtru.TUNGAY;
            dt_DenNgay.Value = nkttDto.dbnktamtru.DENNGAY;

            txtMaNhanKhauTamTru1.Text = nkttDto.dbnktamtru.MANHAKHAUTAMTRU;
            txt_LyDo.Text = nkttDto.dbnktamtru.LYDO;
            txtSoSoTamTru1.Text = nkttDto.dbnktamtru.SOSOTAMTRU;

            LoadDataGridViewTienAN();
            LoadDataGridViewTieuSu();
        }
    }
}
