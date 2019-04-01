using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;


namespace GUI
{
    public partial class fr_CBDuLieu : DevExpress.XtraEditors.XtraForm
    {
        CanBoBUS canbobus;
        CanBoDTO canbo;
        HocSinhSinhVienDTO hssv;
        HocSinhSinhVienBUS hssvbus;
        NhanKhauBUS nhankhaubus;
        NhanKhau nhankhau;
        TienAnTienSuDTO tienantiensu;
        TienAnTienSuBUS tienantiensubus;
        TieuSuDTO tieusu;
        TieuSuBUS tieusubus;
        QuanHuyenDTO quanhuyen;
        QuanHuyenBUS quanhuyenbus;
        TinhThanhPhoDTO tinhthanhpho;
        TinhThanhPhoBUS tinhthanhphobus;
        XaPhuongThiTranDTO xaphuongthitran;
        XaPhuongThiTranBUS xaphuongthitranbus;
        NhanKhauTamTruDTO nktamtru;
        NhanKhauTamTruBUS nktamtrubus;
        NhanKhauThuongTruDTO nkthuongtru;
        NhanKhauThuongTruBUS nkthuongtrubus;
        SoHoKhauDTO sohokhau;
        SoHoKhauBUS sohokhaubus;
        SoTamTruDTO sotamtru;
        SoTamTruBUS sotamtrubus;
        NhanKhauTamVangDTO nhankhautamvang;
        NhanKhauTamVangBUS nhankhautamvangbus;


        public fr_CBDuLieu()
        {
            InitializeComponent();
            canbobus = new CanBoBUS();
            hssvbus = new HocSinhSinhVienBUS();
            nhankhaubus = new NhanKhauBUS();
            tienantiensubus = new TienAnTienSuBUS();
            tieusubus = new TieuSuBUS();
            quanhuyenbus = new QuanHuyenBUS();
            tinhthanhphobus = new TinhThanhPhoBUS();
            xaphuongthitranbus = new XaPhuongThiTranBUS();
            nktamtrubus = new NhanKhauTamTruBUS();
            nkthuongtrubus = new NhanKhauThuongTruBUS();
            sohokhaubus = new SoHoKhauBUS();
            sotamtrubus = new SoTamTruBUS();
            canbobus = new CanBoBUS();
            nhankhautamvangbus = new NhanKhauTamVangBUS();


            DataSet tables = DBConnection<int>.getData("show tables from qlhk");
            try
            {
                foreach (DataRow item in tables.Tables[0].Rows)
                {
                    comboBox1.Items.Add(item[0].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadData()
        {
            switch (comboBox1.Text)
            {
                case "canbo":
                    try
                    {
                        dataGridView1.DataSource = canbobus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "hocsinhsinhvien":
                    try
                    {
                        dataGridView1.DataSource = hssvbus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "nhankhau":
                    try
                    {
                        dataGridView1.DataSource = nhankhaubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "nhankhautamvang":
                    try
                    {
                        dataGridView1.DataSource = nhankhautamvangbus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhautamtru":
                    try
                    {
                        dataGridView1.DataSource = nktamtrubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhauthuongtru":
                    try
                    {
                        dataGridView1.DataSource = nkthuongtrubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "quanhuyen":
                    try
                    {
                        dataGridView1.DataSource = quanhuyenbus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sohokhau":
                    try
                    {
                        dataGridView1.DataSource = sohokhaubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sotamtru":
                    try
                    {
                        dataGridView1.DataSource = sotamtrubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tienantiensu":
                    try
                    {
                        dataGridView1.DataSource = tienantiensubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tieusu":
                    try
                    {
                        dataGridView1.DataSource = tieusubus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tinhthanhpho":
                    try
                    {
                        dataGridView1.DataSource = tinhthanhphobus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "xaphuongthitran":
                    try
                    {
                        dataGridView1.DataSource = xaphuongthitranbus.GetAll();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           switch (comboBox1.Text)
            {
                case "canbo":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    canbobus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string macanbo = dataGridView1.Rows[row].Cells["macanbo"].Value.ToString();
                                string manhankhauthuongtru = dataGridView1.Rows[row].Cells["manhankhauthuongtru"].Value.ToString();
                                string tentaikhoan = dataGridView1.Rows[row].Cells["tentaikhoan"].Value.ToString();
                                string matkhau = dataGridView1.Rows[row].Cells["matkhau"].Value.ToString();
                                string loaicanbo = dataGridView1.Rows[row].Cells["loaicanbo"].Value.ToString();
                                canbo = new CanBoDTO(macanbo, tentaikhoan, matkhau, loaicanbo, manhankhauthuongtru);
                                canbobus.Add_Table(canbo);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";



                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string macanbo = dataGridView1.Rows[row].Cells["macanbo"].Value.ToString();
                                string manhankhauthuongtru = dataGridView1.Rows[row].Cells["manhankhauthuongtru"].Value.ToString();
                                string tentaikhoan = dataGridView1.Rows[row].Cells["tentaikhoan"].Value.ToString();
                                string matkhau = dataGridView1.Rows[row].Cells["matkhau"].Value.ToString();
                                string loaicanbo = dataGridView1.Rows[row].Cells["loaicanbo"].Value.ToString();
                                canbo = new CanBoDTO(macanbo, tentaikhoan, matkhau, loaicanbo, manhankhauthuongtru);
                                canbobus.Update(canbo);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "hocsinhsinhvien":
                        try
                        {
                            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                            {
                                string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                if (Task == "Delete")
                                {
                                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        int rowIndex = e.RowIndex;
                                        hssvbus.Delete(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                    string str_mahssv = dataGridView1.Rows[row].Cells["mahssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham = dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVienDTO(str_mahssv, str_madinhdanh, str_truong, str_diachithuongtru, date_tgbdtt, date_tgkttt, str_vipham);
                                    hssvbus.Add_Table(hssv);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int row = e.RowIndex;
                                    string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                    string str_mahssv = dataGridView1.Rows[row].Cells["mahssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham = dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVienDTO(str_mahssv, str_madinhdanh, str_truong, str_diachithuongtru, date_tgbdtt, date_tgkttt, str_vipham);
                                    hssvbus.Update(hssv);
                                    LoadData();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }          
                    break;
                
                case "nhankhau":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nhankhaubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                //string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string str_hoten = dataGridView1.Rows[row].Cells["hoten"].Value.ToString();
                                string str_tenkhac = dataGridView1.Rows[row].Cells["tenkhac"].Value.ToString();
                                string str_ngaysinh = dataGridView1.Rows[row].Cells["ngaysinh"].Value.ToString();
                                DateTime date_ngaysinh = DateTime.Parse(str_ngaysinh);
                                string str_gioitinh = dataGridView1.Rows[row].Cells["gioitinh"].Value.ToString();
                                string str_noisinh = dataGridView1.Rows[row].Cells["noisinh"].Value.ToString();
                                string str_nguyenquan = dataGridView1.Rows[row].Cells["nguyenquan"].Value.ToString();
                                string str_dantoc = dataGridView1.Rows[row].Cells["dantoc"].Value.ToString();
                                string str_tongiao = dataGridView1.Rows[row].Cells["tongiao"].Value.ToString();
                                string str_quoctich = dataGridView1.Rows[row].Cells["quoctich"].Value.ToString();
                                string str_hochieu = dataGridView1.Rows[row].Cells["hochieu"].Value.ToString();
                                string str_noithuongtru = dataGridView1.Rows[row].Cells["noithuongtru"].Value.ToString();
                                string str_diachihiennay = dataGridView1.Rows[row].Cells["diachihiennay"].Value.ToString();
                                string str_sdt = dataGridView1.Rows[row].Cells["sdt"].Value.ToString();
                                string str_trinhdohocvan = dataGridView1.Rows[row].Cells["trinhdohocvan"].Value.ToString();
                                string str_trinhdochuyenmon = dataGridView1.Rows[row].Cells["trinhdochuyenmon"].Value.ToString();
                                string str_biettiengdantoc = dataGridView1.Rows[row].Cells["biettiengdantoc"].Value.ToString();
                                string str_trinhdongoaingu = dataGridView1.Rows[row].Cells["trinhdongoaingu"].Value.ToString();
                                string str_nghenghiep = dataGridView1.Rows[row].Cells["nghenghiep"].Value.ToString();
                                string str_madinhdanh = TrinhTaoMa.TangMa12Kytu(str_gioitinh, date_ngaysinh.Year.ToString());
                                dataGridView1.Rows[row].Cells["madinhdanh"].Value = str_madinhdanh;

                                nhankhau = new NhanKhau(str_madinhdanh, str_hoten, str_tenkhac, date_ngaysinh, str_gioitinh, 
                                    str_noisinh, str_nguyenquan, str_dantoc, str_tongiao, str_quoctich, str_hochieu, 
                                    str_noithuongtru, str_diachihiennay, str_sdt, str_trinhdohocvan, str_trinhdochuyenmon, 
                                    str_biettiengdantoc, str_trinhdongoaingu, str_nghenghiep);
                                nhankhaubus.Add_Table(nhankhau);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string str_hoten = dataGridView1.Rows[row].Cells["hoten"].Value.ToString();
                                string str_tenkhac = dataGridView1.Rows[row].Cells["tenkhac"].Value.ToString();
                                string str_ngaysinh = dataGridView1.Rows[row].Cells["ngaysinh"].Value.ToString();
                                DateTime date_ngaysinh = DateTime.Parse(str_ngaysinh);
                                string str_gioitinh = dataGridView1.Rows[row].Cells["gioitinh"].Value.ToString();
                                string str_noisinh = dataGridView1.Rows[row].Cells["noisinh"].Value.ToString();
                                string str_nguyenquan = dataGridView1.Rows[row].Cells["nguyenquan"].Value.ToString();
                                string str_dantoc = dataGridView1.Rows[row].Cells["dantoc"].Value.ToString();
                                string str_tongiao = dataGridView1.Rows[row].Cells["tongiao"].Value.ToString();
                                string str_quoctich = dataGridView1.Rows[row].Cells["quoctich"].Value.ToString();
                                string str_hochieu = dataGridView1.Rows[row].Cells["hochieu"].Value.ToString();
                                string str_noithuongtru = dataGridView1.Rows[row].Cells["noithuongtru"].Value.ToString();
                                string str_diachihiennay = dataGridView1.Rows[row].Cells["diachihiennay"].Value.ToString();
                                string str_sdt = dataGridView1.Rows[row].Cells["sdt"].Value.ToString();
                                string str_trinhdohocvan = dataGridView1.Rows[row].Cells["trinhdohocvan"].Value.ToString();
                                string str_trinhdochuyenmon = dataGridView1.Rows[row].Cells["trinhdochuyenmon"].Value.ToString();
                                string str_biettiengdantoc = dataGridView1.Rows[row].Cells["biettiengdantoc"].Value.ToString();
                                string str_trinhdongoaingu = dataGridView1.Rows[row].Cells["trinhdongoaingu"].Value.ToString();
                                string str_nghenghiep = dataGridView1.Rows[row].Cells["nghenghiep"].Value.ToString();

                                nhankhau = new NhanKhau(str_madinhdanh, str_hoten, str_tenkhac, date_ngaysinh, str_gioitinh,
                                    str_noisinh, str_nguyenquan, str_dantoc, str_tongiao, str_quoctich, str_hochieu,
                                    str_noithuongtru, str_diachihiennay, str_sdt, str_trinhdohocvan, str_trinhdochuyenmon,
                                    str_biettiengdantoc, str_trinhdongoaingu, str_nghenghiep);
                                nhankhaubus.Update(nhankhau);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhautamtru":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nktamtrubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                try
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    string manhankhautamtru = dataGridView1.Rows[row].Cells["manhankhautamtru"].Value.ToString();
                                    string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                    string noitamtru = dataGridView1.Rows[row].Cells["noitamtru"].Value.ToString();
                                    string tungay = dataGridView1.Rows[row].Cells["tungay"].Value.ToString();
                                    DateTime date_tungay = DateTime.Parse(tungay);
                                    string denngay = dataGridView1.Rows[row].Cells["denngay"].Value.ToString();
                                    DateTime date_denngay = DateTime.Parse(denngay);
                                    string lydo = dataGridView1.Rows[row].Cells["lydo"].Value.ToString();
                                    string sosotamtru = dataGridView1.Rows[row].Cells["sosotamtru"].Value.ToString();

                                    nktamtru = new NhanKhauTamTruDTO(manhankhautamtru, noitamtru, date_tungay, date_denngay, lydo, sosotamtru, madinhdanh);
                                    nktamtrubus.Add_Table(nktamtru);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }



                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string macanbo = dataGridView1.Rows[row].Cells["macanbo"].Value.ToString();
                                string manhankhauthuongtru = dataGridView1.Rows[row].Cells["manhankhauthuongtru"].Value.ToString();
                                string tentaikhoan = dataGridView1.Rows[row].Cells["tentaikhoan"].Value.ToString();
                                string matkhau = dataGridView1.Rows[row].Cells["matkhau"].Value.ToString();
                                string loaicanbo = dataGridView1.Rows[row].Cells["loaicanbo"].Value.ToString();
                                canbo = new CanBoDTO(macanbo, tentaikhoan, matkhau, loaicanbo, manhankhauthuongtru);
                                canbobus.Update(canbo);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhautamvang":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nhankhautamvangbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string manhankhautamvang = dataGridView1.Rows[row].Cells["manhankhautamvang"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string ngaybdtv = dataGridView1.Rows[row].Cells["ngaybatdautamvang"].Value.ToString();
                                DateTime date_ngaybd = DateTime.Parse(ngaybdtv);
                                string ngaykttv = dataGridView1.Rows[row].Cells["ngayketthuctamvang"].Value.ToString();
                                DateTime date_ngaykt = DateTime.Parse(ngaykttv);
                                string lydo = dataGridView1.Rows[row].Cells["lydo"].Value.ToString();
                                string noiden = dataGridView1.Rows[row].Cells["noiden"].Value.ToString();

                                nhankhautamvang = new NhanKhauTamVangDTO(manhankhautamvang, date_ngaybd, date_ngaykt, lydo, noiden, madinhdanh);
                                nhankhautamvangbus.Add_Table(nhankhautamvang);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";



                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string manhankhautamvang = dataGridView1.Rows[row].Cells["manhankhautamvang"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string ngaybdtv = dataGridView1.Rows[row].Cells["ngaybatdautamvang"].Value.ToString();
                                DateTime date_ngaybd = DateTime.Parse(ngaybdtv);
                                string ngaykttv = dataGridView1.Rows[row].Cells["ngayketthuctamvang"].Value.ToString();
                                DateTime date_ngaykt = DateTime.Parse(ngaykttv);
                                string lydo = dataGridView1.Rows[row].Cells["lydo"].Value.ToString();
                                string noiden = dataGridView1.Rows[row].Cells["noiden"].Value.ToString();

                                nhankhautamvang = new NhanKhauTamVangDTO(manhankhautamvang, date_ngaybd, date_ngaykt, lydo, noiden, madinhdanh);
                                nhankhautamvangbus.Update(nhankhautamvang);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhauthuongtru":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nkthuongtrubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string manhankhauthuongtru = dataGridView1.Rows[row].Cells["manhankhauthuongtru"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                string quanhevoichuho = dataGridView1.Rows[row].Cells["quanhevoichuho"].Value.ToString();
                                string sosohokhau = dataGridView1.Rows[row].Cells["sosohokhau"].Value.ToString();
                                nkthuongtru = new NhanKhauThuongTruDTO(manhankhauthuongtru, diachithuongtru, quanhevoichuho, sosohokhau, madinhdanh);
                                nkthuongtrubus.Add_Table(nkthuongtru);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";

                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string manhankhauthuongtru = dataGridView1.Rows[row].Cells["manhankhauthuongtru"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                string quanhevoichuho = dataGridView1.Rows[row].Cells["quanhevoichuho"].Value.ToString();
                                string sosohokhau = dataGridView1.Rows[row].Cells["sosohokhau"].Value.ToString();
                                nkthuongtru = new NhanKhauThuongTruDTO(manhankhauthuongtru, diachithuongtru, quanhevoichuho, sosohokhau, madinhdanh);
                                nkthuongtrubus.Update(nkthuongtru);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sohokhau":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    sohokhaubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string sosohokhau = dataGridView1.Rows[row].Cells["sosohokhau"].Value.ToString();
                                string chuho = dataGridView1.Rows[row].Cells["machuho"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachi"].Value.ToString();
                                string ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(ngaycap);
                                string sodangky = dataGridView1.Rows[row].Cells["sodangky"].Value.ToString();

                                sohokhau = new SoHoKhauDTO(sosohokhau, chuho, diachithuongtru, date_ngaycap, sodangky);
                                sohokhaubus.Add_Table(sohokhau);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                

                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string sosohokhau = dataGridView1.Rows[row].Cells["sosohokhau"].Value.ToString();
                                string chuho = dataGridView1.Rows[row].Cells["machuho"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachi"].Value.ToString();
                                string ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(ngaycap);
                                string sodangky = dataGridView1.Rows[row].Cells["sodangky"].Value.ToString();

                                sohokhau = new SoHoKhauDTO(sosohokhau, chuho, diachithuongtru, date_ngaycap, sodangky);
                                sohokhaubus.Update(sohokhau);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sotamtru":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    sotamtrubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string sosotamtru = dataGridView1.Rows[row].Cells["sosotamtru"].Value.ToString();
                                string chuho = dataGridView1.Rows[row].Cells["chuho"].Value.ToString();
                                string noitamtru = dataGridView1.Rows[row].Cells["noitamtru"].Value.ToString();
                                string ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(ngaycap);
                                string denngay = dataGridView1.Rows[row].Cells["denngay"].Value.ToString();
                                DateTime date_denngay = DateTime.Parse(denngay);

                                sotamtru = new SoTamTruDTO(sosotamtru, chuho, noitamtru, date_ngaycap, date_denngay);
                                sotamtrubus.Add_Table(sotamtru);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string sosotamtru = dataGridView1.Rows[row].Cells["sosotamtru"].Value.ToString();
                                string chuho = dataGridView1.Rows[row].Cells["chuho"].Value.ToString();
                                string noitamtru = dataGridView1.Rows[row].Cells["noitamtru"].Value.ToString();
                                string ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(ngaycap);
                                string denngay = dataGridView1.Rows[row].Cells["denngay"].Value.ToString();
                                DateTime date_denngay = DateTime.Parse(denngay);

                                sotamtru = new SoTamTruDTO(sosotamtru, chuho, noitamtru, date_ngaycap, date_denngay);
                                sotamtrubus.Update(sotamtru);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "tienantiensu":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tienantiensubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matienantiensu = dataGridView1.Rows[row].Cells["matienantiensu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string toidanh = dataGridView1.Rows[row].Cells["toidanh"].Value.ToString();
                                string hinhphat = dataGridView1.Rows[row].Cells["hinhphat"].Value.ToString();
                                string banan = dataGridView1.Rows[row].Cells["banan"].Value.ToString();

                                string ngayphat = dataGridView1.Rows[row].Cells["ngayphat"].Value.ToString();
                                DateTime date_ngayphat = DateTime.Parse(ngayphat);
                                tienantiensu = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan,toidanh,hinhphat,date_ngayphat);
                                tienantiensubus.Add_Table(tienantiensu);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matienantiensu = dataGridView1.Rows[row].Cells["matienantiensu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string toidanh = dataGridView1.Rows[row].Cells["toidanh"].Value.ToString();
                                string hinhphat = dataGridView1.Rows[row].Cells["hinhphat"].Value.ToString();
                                string banan = dataGridView1.Rows[row].Cells["banan"].Value.ToString();
                                string ngayphat = dataGridView1.Rows[row].Cells["ngayphat"].Value.ToString();
                                DateTime date_ngayphat = DateTime.Parse(ngayphat);
                                tienantiensu = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat); ;
                                tienantiensubus.Update(tienantiensu);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tieusu":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tieusubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matieusu = dataGridView1.Rows[row].Cells["matieusu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string thoigianbatdau = dataGridView1.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                                DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                                string thoigianketthuc = dataGridView1.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                                DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                                string choo = dataGridView1.Rows[row].Cells["choo"].Value.ToString();
                                string nghenghiep = dataGridView1.Rows[row].Cells["nghenghiep"].Value.ToString();
                                string noilamviec = dataGridView1.Rows[row].Cells["noilamviec"].Value.ToString();
                                tieusu = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, nghenghiep, noilamviec);
                                tieusubus.Add_Table(tieusu);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matieusu = dataGridView1.Rows[row].Cells["matieusu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string thoigianbatdau = dataGridView1.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                                DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                                string thoigianketthuc = dataGridView1.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                                DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                                string choo = dataGridView1.Rows[row].Cells["choo"].Value.ToString();
                                string nghenghiep = dataGridView1.Rows[row].Cells["nghenghiep"].Value.ToString();
                                string noilamviec = dataGridView1.Rows[row].Cells["noilamviec"].Value.ToString();
                                tieusu = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, nghenghiep, noilamviec);
                                tieusubus.Update(tieusu);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tinhthanhpho":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tinhthanhphobus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                tinhthanhpho = new TinhThanhPhoDTO(matp, ten, kieu);
                                tinhthanhphobus.Add_Table(tinhthanhpho);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                tinhthanhpho = new TinhThanhPhoDTO(matp, ten, kieu);
                                tinhthanhphobus.Update(tinhthanhpho);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "quanhuyen":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    quanhuyenbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();

                                quanhuyen = new QuanHuyenDTO(maqh, ten, kieu, matp);
                                quanhuyenbus.Add_Table(quanhuyen);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();

                                quanhuyen = new QuanHuyenDTO(maqh, ten, kieu, matp);
                                quanhuyenbus.Update(quanhuyen);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "xaphuongthitran":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    xaphuongthitranbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string maxp = dataGridView1.Rows[row].Cells["maxp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string maqh= dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                xaphuongthitran = new XaPhuongThiTranDTO(maxp, ten, kieu, maqh);
                                xaphuongthitranbus.Add_Table(xaphuongthitran);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string maxp = dataGridView1.Rows[row].Cells["maxp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                xaphuongthitran = new XaPhuongThiTranDTO(maxp, ten, kieu, maqh);
                                xaphuongthitranbus.Update(xaphuongthitran);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            } 
        }


        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                int lastRow = dataGridView1.Rows.Count - 2;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Insert";
                //dataGridView1[0,lastRow].Value= TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaTieuSu());
                switch(comboBox1.Text)
                {
                    case "canbo":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_CanBo());
                        break;
                    case "nhankhautamtru":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauTamTru());
                        break;
                    case "nhankhautamvang":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_NhanKhauTamVang());
                        break;
                    case "nhankhauthuongtru":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaNhanKhauThuongTru());
                        break;
                    case "sohokhau":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
                        break;
                    case "sotamtru":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_SoHoKhauSoTamTru());
                        break;
                    case "tienantiensu":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaTienAnTienSu());
                        break;
                    case "tieusu":
                        dataGridView1[0, lastRow].Value = TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_MaTieuSu());
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int lastRow = e.RowIndex;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void fr_CBDuLieu_Load(object sender, EventArgs e)
        {

        }
    }
}
