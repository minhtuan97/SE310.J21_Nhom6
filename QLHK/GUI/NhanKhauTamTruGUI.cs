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
            TaoMaDinhDanh();
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            TaoMaDinhDanh();
        }

        private void dt_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            TaoMaDinhDanh();
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
                DataGridViewCellEventArgs arg = new DataGridViewCellEventArgs(0, 0);
                dataGridView1_CellClick(sender, arg);
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
                    MessageBox.Show("Them so tam tru thanh cong");
                }
                else
                {
                    MessageBox.Show("Them so tam tru khong thanh cong");
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
                MessageBox.Show("Thêm nhân khẩu tạm trú "+hoten+" thành công");
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

            madinhdanh = madinhdanhForInsert;

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + hoten + " không tồn tại !");
                return;
            }

            NhanKhauTamTruBUS nktt = new NhanKhauTamTruBUS();

            DateTime DN_temp = Convert.ToDateTime(nktt.GetTuNgay(madinhdanh));
            DateTime TN_temp = Convert.ToDateTime(nktt.GetDenNgay(madinhdanh));
            if(DN_temp!=dt_DenNgay.Value.Date || TN_temp != dt_TuNgay.Value.Date)
            {
                MessageBox.Show("Bạn không được thay đổi thời gian tạm trú");
                return;
            }


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

            madinhdanh = madinhdanhForInsert;

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú "+hoten+" không tồn tại !");
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

        //Lấy thông tin từ datagridview vào input
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string madinhdanh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string manhankhautamtru = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string hoten = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string tenkhac = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime ngaysinh = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            string gioitinh = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string noisinh = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string nguyenquan = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            string dantoc = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            string tongiao = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            string quoctich = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            string hochieu = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            string noithuongtru = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            string diachihiennay = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            string sdt = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            string trinhdohocvan = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            string trinhdochuyenmon = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            string biettiengdantoc = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            string trinhdongoaingu = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            string nghenghiep = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            string sosotamtru = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
            string noitamtru = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
            DateTime tungay = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[22].Value);
            DateTime denngay = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[23].Value);
            string lydo = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();


            madinhdanhForInsert = madinhdanh;

            NhanKhauTamTruDTO nhankhautamtru = new NhanKhauTamTruDTO(manhankhautamtru, noitamtru, tungay,denngay,lydo, 
                sosotamtru, madinhdanh, hoten, tenkhac, ngaysinh, gioitinh, noisinh, nguyenquan, dantoc, tongiao, 
                quoctich, hochieu, noithuongtru, diachihiennay, sdt,trinhdohocvan, trinhdochuyenmon, 
                biettiengdantoc,trinhdongoaingu, nghenghiep);

            //txtMaDinhDanh1.Text = nhankhautamtru.db.MaDinhDanh;
            //txtMaNhanKhauTamTru1.Text = nhankhautamtru.MaNhanKhauTamTru;
            //txt_HoTen.Text = nhankhautamtru.HoTen;

            //string gt = nhankhautamtru.GioiTinh;
            //if ( gt == "nam")
            //    this.rdNam.Checked = true;
            //else
            //    this.rdNu.Checked = true;


            //txtSoSoTamTru1.Text = nhankhautamtru.SoSoTamTru;
            //dt_NgaySinh.Value = nhankhautamtru.NgaySinh;
            //txt_DanToc.Text = nhankhautamtru.DanToc;
            //txt_QuocTich.Text = nhankhautamtru.QuocTich;
            //txt_TonGiao.Text = nhankhautamtru.TonGiao;
            //txt_NgheNghiep.Text = nhankhautamtru.NgheNghiep;
            //txt_SoDienThoai.Text = nhankhautamtru.SDT;
            //txt_HoChieu.Text = nhankhautamtru.HoChieu;
            //txtMaDinhDanh1.Text = nhankhautamtru.MaDinhDanh;

            //txt_TenKhac.Text = nhankhautamtru.TenKhac;
            //txt_TrinhDoHocVan.Text = nhankhautamtru.TrinhDoHocVan;
            //txt_TrinhDoChuyenMon.Text = nhankhautamtru.TrinhDoChuyenMon;
            //txt_BietTiengDanToc.Text = nhankhautamtru.BietTiengDanToc;
            //txt_TrinhDoNgoaiNgu.Text = nhankhautamtru.TrinhDoNgoaiNgu;
            //txt_LyDo.Text = nhankhautamtru.LyDo;

            //dt_TuNgay.Value = nhankhautamtru.TuNgay;
            //dt_DenNgay.Value = nhankhautamtru.DenNgay;

            //txt_NguyenQuan.Text = nhankhautamtru.NguyenQuan;
            //txtNoiSinh.Text = nhankhautamtru.NoiSinh;
            //txtDiaChiHienNay.Text = nhankhautamtru.DiaChiHienNay;
            //txtNoiThuongTru.Text = nhankhautamtru.NoiThuongTru;
            //txtNoiTamTru.Text = nhankhautamtru.NoiTamTru;


            //Hiễn thị tiền án tiền sự
            LoadDataGridViewTienAN();
            LoadDataGridViewTieuSu();
            ResetInputTienAn();
            ResetInputTieuSu();
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
            txt_MaTieuSu.Text = GenerateMaTieuSu(); 
        }




        /// <summary>
        /// XỬ LÍ VỚI GROUP TIỀN ÁN TIỀN SỰ
        /// </summary>
        

        private void LoadDataGridViewTienAN()
        {
            dtGV_TienAnTienSu.DataSource = null;
            dtGV_TienAnTienSu.Rows.Clear();
            dtGV_TienAnTienSu.DataSource = nkttBus.GetTienAnTienSu(txtMaDinhDanh1.Text.ToString());
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

            TienAnTienSuBUS tienanbus = new TienAnTienSuBUS();
            if (tienanbus.Add(tienan))
            {
                MessageBox.Show("Thêm tiền án tiền sự " + matienan + " cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                ResetInputTienAn();
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
                    ResetInputTienAn();
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


                TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh, toidanh, hinhphat, banan, ngayphat);

                TienAnTienSuBUS tienanbus = new TienAnTienSuBUS();
                if (tienanbus.Update(tienan))
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
            dtGV_TieuSu.DataSource = nkttBus.GetTieuSu(txtMaDinhDanh1.Text.ToString());
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

            TieuSuBUS tieusuBus = new TieuSuBUS();

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
            string madinhdanh = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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

                TieuSuBUS tieusuBus = new TieuSuBUS();

                if (tieusuBus.Update(tieusu))
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thành công !");
                    LoadDataGridViewTieuSu();
                    ResetInputTieuSu();
                }
                else
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thất bại !");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
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

            if (kq.Count > 0)
            {
                NhanKhauTamTruDTO dt = kq[0];
                nkttDto = new NhanKhauTamTruDTO(dt);

                fillData();
            }
            else
            {
                MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            MessageBox.Show("Tim Thanh COng");
        }


        private void fillData()
        {
            txt_HoTen.Text = nkttDto.db.HOTEN;
            txt_TenKhac.Text = nkttDto.db.TENKHAC;
            rdNam.Checked = (nkttDto.db.GIOITINH == "Nam"); rdNu.Checked = (nkttDto.db.GIOITINH == "Nữ");
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

            txtMaNhanKhauTamTru1.Text = nkttDto.dbnktamtru.MANHANKHAUTAMTRU;
           // tbSoSHK.Text = string.IsNullOrEmpty(nkttDto.dbnktamtru.SOSOTAMTRU) ? tbSoSHK.Text : nkttDTO.dbnktt.SOSOHOKHAU;
            txtDiaChiHienNay.Text = nkttDto.db.DIACHIHIENNAY;

            txt_TrinhDoHocVan.Text = nkttDto.db.TRINHDOHOCVAN;
            txt_TrinhDoChuyenMon.Text = nkttDto.db.TRINHDOCHUYENMON;
            txt_BietTiengDanToc.Text = nkttDto.db.BIETTIENGDANTOC;
            txt_TrinhDoNgoaiNgu.Text = nkttDto.db.TRINHDONGOAINGU;
            //txt_NoiLamViec.Text = nkttDto.db.NOI
            //tbQHVoiCH.Text = nkttDto.dbnktt.QUANHEVOICHUHO;

            //LoadtieuSu();
            //Loadtienantiensu();
        }

    }
}
