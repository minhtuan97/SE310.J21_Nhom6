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
    public partial class HocSinhSinhVienGUI : Form
    {
        NhanKhauThuongTruBUS thuongTru;
        NhanKhauTamTruBUS tamTru;
        HocSinhSinhVienBUS hssvbus;
        HOCSINHSINHVIEN hssvdto;
        TienAnTienSuBUS tienAn;

        public HocSinhSinhVienGUI()
        {

            InitializeComponent();
            hssvbus = new HocSinhSinhVienBUS();
            tienAn = new TienAnTienSuBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh=''");

        }
        private void clearData()
        {
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void HocSinhSinhVienGUI_Load(object sender, EventArgs e)
        {

        }

        
        private void button_timkiem_Click(object sender, EventArgs e)
        {
            List<HOCSINHSINHVIEN> source = hssvbus.TimKiemJoinNhanKhau(" mahssv='" + textBox_mssv.Text + "'");
            if (source.Count > 0)
            {
                List<HOCSINHSINHVIEN> data = source;
                if (data.Count > 0)
                {
                    foreach (HOCSINHSINHVIEN a in data)
                    {
                        textBox_madinhdanh.Text = a.MADINHDANH;
                        textBox_truong.Text = a.TRUONG;
                        textBox_diachithuongtru.Text = a.DIACHITHUONGTRU;
                        date_batdau.Text = a.THOIGIANBATDAUTAMTRUTHUONGTRU.ToString();
                        date_ketthuc.Text = a.THOIGIANKETTHUCTAMTRUTHUONGTRU.ToString();
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                

                //dataGridView1.DataSource = tienAn.TimKiem("madinhdanh = '" + textBox_madinhdanh.Text + "'");
                try
                {
                    var bList = new BindingList<TIENANTIENSU>(tienAn.TimKiem("madinhdanh = '" + textBox_madinhdanh.Text + "'").Select(r => r).ToList());
                    dataGridView1.DataSource = new BindingSource(bList, null);
                    //for (int i = 0; i < dGVTienAnTienSu.Rows.Count; i++)
                    //{
                    //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    //    dGVTienAnTienSu[dGVTienAnTienSu.ColumnCount - 1, i] = linkCell;
                    //}
                    button_xoa.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Không tìm thấy học sinh sinh viên", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }


        private void button_Them_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            DateTime tgbd = date_batdau.Value.Date;
            DateTime tgkt = date_ketthuc.Value.Date;
            string vipham = textBox_vipham.Text.ToString();
    
            hssvdto = new HOCSINHSINHVIEN(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Add(hssvdto))
            {
                MessageBox.Show("Thêm thành công");
                
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
            //clearData();
            
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            if (hssvbus.XoaHSSV(mssv))
            {
                MessageBox.Show("Xóa thành công");

            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
            //clearData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            DateTime tgbd = date_batdau.Value.Date;
            DateTime tgkt = date_ketthuc.Value.Date;
            string vipham = textBox_vipham.Text.ToString();
            hssvdto = new HOCSINHSINHVIEN(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Update(hssvdto))
            {
                MessageBox.Show("Sửa thành công");
                
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
            //clearData();
        }

        private void textBox_madinhdanh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh LIKE'%" + textBox_madinhdanh.Text + "%'");
        }
        private void textBox_diachithuongtru_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    textBox_diachithuongtru.Text = a.diaChi;
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            List<ReplacementGroup> rg = new List<ReplacementGroup>();
            //DataTable source = hssvbus.TimKiemJoinNhanKhau("AND mssv='" + textBox_mssv.Text + "'").Tables[0];
            DataTable source = hssvbus.TimKiemtheoCuTru(textBox_madinhdanh.Text);


            DataRow data = source.Rows[0];
            List<string> listViPham = new List<string>();
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                if(item.Cells["toidanh"].Value!=null)
                    listViPham.Add(item.Cells["toidanh"].Value.ToString());
            }
            string vipham = string.Join(", ",listViPham.ToArray());
            vipham = string.IsNullOrEmpty(textBox_vipham.Text) ? vipham : textBox_vipham.Text + ", " + vipham;

            if (data.ItemArray.Length > 0)
            {
                rg.Add(new ReplacementGroup("<ten>", data["hoten"].ToString()));
                rg.Add(new ReplacementGroup("<ngaySinh>", data["ngaysinh"].ToString().Split(' ')[0]));
                rg.Add(new ReplacementGroup("<mssv>", data["mahssv"].ToString()));
                rg.Add(new ReplacementGroup("<truong>", data["truong"].ToString()));
                rg.Add(new ReplacementGroup("<maDinhDanh>", data["madinhdanh"].ToString()));
                //rg.Add(new ReplacementGroup("<ngayCap>", data["ngaycap"].ToString().Split(' ')[0]));
                //rg.Add(new ReplacementGroup("<diaChiThuongTru>", data["diachithuongtru"].ToString()));
                rg.Add(new ReplacementGroup("<diaChiThuongTru>", data["diachithuongtru"].ToString()));
                rg.Add(new ReplacementGroup("<diaChiTamTru>", ""));
                int vtkhupho = data["noithuongtru"].ToString().IndexOf(",");
                int thlen = data["noithuongtru"].ToString().Length;
                rg.Add(new ReplacementGroup("<khupho>", data["noithuongtru"].ToString().Substring(vtkhupho    ,thlen-vtkhupho)));


                rg.Add(new ReplacementGroup("<tuNgay>", data["thoigianbatdautamtruthuongtru"].ToString().Split(' ')[0]));
                rg.Add(new ReplacementGroup("<denNgay>", data["thoigianketthuctamtruthuongtru"].ToString().Split(' ')[0]));

                rg.Add(new ReplacementGroup("<viPham>", vipham));
                rg.Add(new ReplacementGroup("<checkKhong>", vipham == "" ? "" : ""));
                rg.Add(new ReplacementGroup("<checkCo>", vipham == "" ? "" : ""));

                DateTime today = DateTime.Now;
                rg.Add(new ReplacementGroup("<ngay>", today.Day.ToString()));
                rg.Add(new ReplacementGroup("<thang>", today.Month.ToString()));
                rg.Add(new ReplacementGroup("<nam>", today.Year.ToString()));


                string srcPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\Mau HSSV01.doc";
                string dstPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\KetQua\\Mau HSSV01_" + textBox_mssv.Text + ".doc";
                CreateWordHelper.CreateWordDocument(srcPath,dstPath, rg);

                MessageBox.Show(this, "Đã tạo thành công file thông tin với tên: " + dstPath, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "lỗi", "Không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            List<HOCSINHSINHVIEN> source = hssvbus.TimKiemJoinNhanKhau("nhankhau.madinhdanh ='" + textBox_madinhdanh.Text + "'");
            if (source.Count > 0)
            {
                List<HOCSINHSINHVIEN> data = source;
                if (data.Count > 0)
                {
                    foreach (HOCSINHSINHVIEN a in data)
                    {
                        textBox_mssv.Text = a.MAHSSV;
                        textBox_truong.Text = a.TRUONG;
                        textBox_diachithuongtru.Text = a.DIACHITHUONGTRU;
                        date_batdau.Text = a.THOIGIANBATDAUTAMTRUTHUONGTRU.ToString();
                        date_ketthuc.Text = a.THOIGIANKETTHUCTAMTRUTHUONGTRU.ToString();
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                //dataGridView1.DataSource = tienAn.TimKiem("madinhdanh = '" + textBox_madinhdanh.Text + "'");
                try
                {
                    DataTable bList = DataHelper.ListToDatatable( tienAn.TimKiem("madinhdanh = '" + textBox_madinhdanh.Text + "'").Select(r => r).ToList());
                    dataGridView1.DataSource = bList;//new BindingSource(bList, null);
                    //for (int i = 0; i < dGVTienAnTienSu.Rows.Count; i++)
                    //{
                    //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    //    dGVTienAnTienSu[dGVTienAnTienSu.ColumnCount - 1, i] = linkCell;
                    //}
                    button_xoa.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Không tìm thấy học sinh sinh viên", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }

        private void textBox_mssv_TextChanged(object sender, EventArgs e)
        {

        }

        private void HocSinhSinhVienGUI_Load_1(object sender, EventArgs e)
        {

        }
    }
}
