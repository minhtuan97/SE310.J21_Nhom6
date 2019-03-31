﻿using System;
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
        HocSinhSinhVienDTO hssvdto;
        TienAnTienSuBUS tienAn;

        public HocSinhSinhVienGUI()
        {

            InitializeComponent();
            hssvbus = new HocSinhSinhVienBUS();
            tienAn = new TienAnTienSuBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh=''").Tables["tienantiensu"];

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
            //string query = null;
            //string mssv = textBox_mssv.Text.ToString();
            //string madinhdanh = textBox_madinhdanh.Text.ToString();
            //string truong = textBox_truong.Text.ToString();
            //string diachi = textBox_diachithuongtru.Text.ToString();
            //string vipham = textBox_vipham.Text.ToString();
            //if (mssv != "") query = query + " mssv='"+mssv+"'";
            //if (madinhdanh != "")
            //{
            //    if (query != null) query = query + " and madinhdanh='" + madinhdanh + "'";
            //    else query =" madinhdanh='" + madinhdanh + "'";
            //}

            //if ( truong!= "")
            //{
            //    if(query!=null) query = query + " and truong='" + truong + "'";
            //    else query =" truong='" + truong + "'";
            //}
            //if ( diachi!= "")
            //{
            //    if (query != null) query = query + " and diachi='" + diachi + "'";
            //    else query =" diachi='" + diachi + "'";
            //}
            //if (query != null) query = " where" + query;
            //dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = tienAn.TimKiem("madinhdanh='"+ madinhdanh + "'").Tables["tienantiensu"];
            //textBox_mssv.Clear();
            //textBox_madinhdanh.Clear();
            //textBox_truong.Clear();
            //textBox_diachithuongtru.Clear();
            //textBox_vipham.Clear();

            //DataTable source = hssvbus.TimKiemJoinNhanKhau(" AND nhankhau.madinhdanh LIKE '%" + textBox_madinhdanh.Text + "%'").Tables[0];
            DataTable source = hssvbus.TimKiemJoinNhanKhau(" AND mahssv='" + textBox_mssv.Text + "'").Tables[0];
            if (source.Rows.Count > 0)
            {
                DataRow data = source.Rows[0];
                if (data.ItemArray.Length > 0)
                {
                    textBox_madinhdanh.Text = data["madinhdanh"].ToString();
                    textBox_truong.Text = data["truong"].ToString();
                    textBox_diachithuongtru.Text = data["diachithuongtru"].ToString();
                    date_batdau.Text = data["thoigianbatdautamtruthuongtru"].ToString();
                    date_ketthuc.Text = data["thoigianketthuctamtruthuongtru"].ToString();
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = tienAn.TimKiem("madinhdanh='" + textBox_madinhdanh.Text + "'").Tables["tienantiensu"];
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
            hssvdto = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
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
            //textBox_mssv.Clear();
            //textBox_madinhdanh.Clear();
            //textBox_truong.Clear();
            //textBox_diachithuongtru.Clear();
            //textBox_vipham.Clear();
            //int r = e.RowIndex;
            //if (r >= dataGridView1.RowCount - 1||r<0) return;
            //string mssv = dataGridView1.Rows[r].Cells["mssv"].Value.ToString();
            //string madinhdanh = dataGridView1.Rows[r].Cells["madinhdanh"].Value.ToString();
            //string truong = dataGridView1.Rows[r].Cells["truong"].Value.ToString();
            //string diachi = dataGridView1.Rows[r].Cells["diachithuongtru"].Value.ToString();
            //DateTime tgbd = DateTime.Parse(dataGridView1.Rows[r].Cells["thoigianbatdautamtruthuongtru"].Value.ToString());
            //DateTime tgkt = DateTime.Parse(dataGridView1.Rows[r].Cells["thoigianketthuctamtruthuongtru"].Value.ToString());
            //string vipham = dataGridView1.Rows[r].Cells["vipham"].Value.ToString();
            //HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            //textBox_mssv.Text = hssv.MSSV;
            //textBox_madinhdanh.Text = hssv.MaDinhDanh;
            //textBox_truong.Text = hssv.Truong;
            //textBox_diachithuongtru.Text = hssv.DiaChiThuongTru;
            //date_batdau.Value = hssv.TGBDTTTT;
            //date_ketthuc.Value = hssv.TGKTTTTT;
            //textBox_vipham.Text = hssv.ViPham;
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
            hssvdto = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Update(hssvdto,-1))
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
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh LIKE'%" + textBox_madinhdanh.Text + "%'").Tables["tienantiensu"];
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
            DataTable source = hssvbus.TimKiemJoinNhanKhau(" AND nhankhau.madinhdanh ='" + textBox_madinhdanh.Text + "'").Tables[0];
            if (source.Rows.Count > 0)
            {
                DataRow data = source.Rows[0];
                if (data.ItemArray.Length > 0)
                {
                    textBox_mssv.Text = data["mahssv"].ToString();
                    textBox_truong.Text = data["truong"].ToString();
                    textBox_diachithuongtru.Text = data["diachithuongtru"].ToString();
                    date_batdau.Text = data["thoigianbatdautamtruthuongtru"].ToString();
                    date_ketthuc.Text = data["thoigianketthuctamtruthuongtru"].ToString();
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = tienAn.TimKiem("madinhdanh = '" + textBox_madinhdanh.Text + "'").Tables["tienantiensu"];
            }
            else
            {
                MessageBox.Show(this, "Không tìm thấy học sinh sinh viên", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }
    }
}
