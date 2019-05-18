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
    public partial class NhanKhauTamVangGUI : Form
    {
        NhanKhauDTO nk = new NhanKhauDTO();
        NhanKhauTamVangDTO nktv;
        NhanKhauTamVangBUS nktvbus = new NhanKhauTamVangBUS();
        public NhanKhauTamVangGUI()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            //List<NhanKhauTamVangDTO> kq = nktvbus.TimKiem(" where nhankhautamvang.madinhdanh='" + textBox_madinhdanh.Text + "'");
            //if (kq.Count!=0)
            //{
            //    NhanKhauTamVangDTO a = kq[0];

            //    textBox_hoten.Text = a.db.NHANKHAU.HOTEN.ToString();
            //    tbNgaySinh.Text = a.db.NHANKHAU.NGAYSINH.ToString();
            //    tbdantoc.Text = a.db.NHANKHAU.DANTOC.ToString();
            //    tbNgheNghiep.Text = a.db.NHANKHAU.NGHENGHIEP.ToString();
            //    if (a.db.NHANKHAU.GIOITINH.ToString() == "nam")
            //    {
            //        rdNam.Checked = true;
            //    }
            //    if (a.db.NHANKHAU.GIOITINH.ToString() == "nu")
            //    {
            //        rdNu.Checked = true;
            //    }
            //    //tongiao
            //    textBox_tongiao.Text = a.db.NHANKHAU.TONGIAO.ToString();
            //    //nguyenquan
            //    tbnguyenquan.Text = a.db.NHANKHAU.NGUYENQUAN.ToString();
            //    //noisinh
            //    tbNoiSinh.Text = a.db.NHANKHAU.NOISINH.ToString();
            //    //quoctich
            //    tbquoctich.Text = a.db.NHANKHAU.QUOCTICH.ToString();
            //    //hochieu
            //    tbhochieu.Text = a.db.NHANKHAU.HOCHIEU.ToString();
            //    //sdt
            //    tbsodienthoai.Text = a.db.NHANKHAU.SDT.ToString();
            //    //ngaycap
            //    //tbNgayCap.Text = dt["ngaycap"].ToString();
            //    //noicap
            //    //tbNoiCap.Text = dt["noicap"].ToString();
            //    //noithuongtru
            //    tbDCThuongTru.Text = a.db.NHANKHAU.NOITHUONGTRU.ToString();
            //    //diachihientai
            //    tbDCHienTai.Text = a.db.NHANKHAU.DIACHIHIENNAY.ToString();

            //    if (nktvbus.TimKiemThuongtru(" madinhdanh='" + textBox_madinhdanh.Text + "'") == 1)
            //        rd_tamtru.Checked = true;
            //    if (nktvbus.TimKiemThuongtru(" madinhdanh='" + textBox_madinhdanh.Text + "'") == 0)
            //            rd_thuongtru.Checked = true;
            //    DateTime secondDateTime = DateTime.Now;

            //    if (a.db.NGAYKETTHUCTAMVANG.ToString() == "")

            //    {

            //        label_matamvang.Text = null;
            //        tbLyDo.Text = null;
            //        textBox_noiden.Text = null;
            //        dtpNgayBatDau.Value = secondDateTime;
            //        dtpNgayKetThuc.Value = secondDateTime;
            //        return;
            //    }
            //        DateTime ngayketthuc = DateTime.Parse(a.db.NGAYKETTHUCTAMVANG.ToString());
            //    //int compare = DateTime.Compare(ngayketthuc, secondDateTime);
            //    if (secondDateTime<ngayketthuc)
            //    {
            //        label_matamvang.Text = a.db.MANHANKHAUTAMVANG.ToString();
            //        tbLyDo.Text = a.db.LYDO.ToString();
            //        textBox_noiden.Text = a.db.NOIDEN.ToString();
            //        if (a.db.NGAYBATDAUTAMVANG.ToString() != "")
            //            dtpNgayBatDau.Value = DateTime.Parse(a.db.NGAYBATDAUTAMVANG.ToString());
            //        if (a.db.NGAYKETTHUCTAMVANG.ToString() != "")
            //            dtpNgayKetThuc.Value = DateTime.Parse(a.db.NGAYKETTHUCTAMVANG.ToString());
            //    }
            //    else
            //    {
            //        label_matamvang.Text = null;
            //        tbLyDo.Text = null;
            //        textBox_noiden.Text = null;
            //        dtpNgayBatDau.Value = secondDateTime;
            //        dtpNgayKetThuc.Value = secondDateTime;
            //    }



            //}
            //else
            //{
            //    textBox_hoten.Text = null;

            //    MessageBox.Show(this, "Nhân khẩu này không tồn tại!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}


        }

        private void tbnguyenquan_Enter(object sender, EventArgs e)
        {

        }

        private void tbDCHienTai_Enter(object sender, EventArgs e)
        {

        }

        private void tbDCThuongTru_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemTV_Click(object sender, EventArgs e)
        {
            //string madinhdanh = textBox_madinhdanh.Text.ToString();
            //string lydo = tbLyDo.Text.ToString();
            //string noiden = textBox_noiden.Text.ToString();
            //DateTime ngaybd = dtpNgayBatDau.Value.Date;
            //DateTime ngaykt = dtpNgayKetThuc.Value.Date;
            //if(madinhdanh==null||lydo==null||noiden==null || DateTime.Compare(ngaykt, ngaybd) <= 0)
            //{
            //    MessageBox.Show("Vui lòng nhập đủ, chính xác thông tin!");
            //    return;
            //}
            //else
            //{

            //    nktv = new NhanKhauTamVangDTO(TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_NhanKhauTamVang()), ngaybd, ngaykt, lydo, noiden, madinhdanh);
            //    if (nktvbus.Add(nktv) == true)
            //        MessageBox.Show("Thêm thành công");
            //    else
            //        MessageBox.Show("Thêm không thành công");
            //}









            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string lydo = tbLyDo.Text.ToString();
            string noiden = textBox_noiden.Text.ToString();
            DateTime ngaybd= dtpNgayBatDau.Value.Date;
            DateTime ngaykt = dtpNgayKetThuc.Value.Date;
            if(madinhdanh==null || lydo==null || noiden==null || ngaybd==null || ngaykt==null || DateTime.Compare(ngaykt,ngaybd) <=0)
            {
                MessageBox.Show("Vui long dien day du thong tin","canh bao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                nktv = new NhanKhauTamVangDTO(TrinhTaoMa.TangMa9kytu(TrinhTaoMa.getLastID_NhanKhauTamVang()),ngaybd, ngaykt, lydo,noiden, madinhdanh);
                if(nktvbus.Add(nktv)==true)
                {
                    MessageBox.Show("cap nhap thnah cong", "canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("khong the cap nhap", "canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }













        }

        private void btnSuaTV_Click(object sender, EventArgs e)
        {
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string lydo = tbLyDo.Text.ToString();
            string noiden = textBox_noiden.Text.ToString();
            DateTime ngaybd = dtpNgayBatDau.Value.Date;
            DateTime ngaykt = dtpNgayKetThuc.Value.Date;
            if (madinhdanh == null || lydo == null || noiden == null || DateTime.Compare(ngaykt,ngaybd)<=0)
            {
                MessageBox.Show("Vui lòng nhập đủ, chính xác thông tin!");
                return;
            }
            else
            {
                string matamvang = label_matamvang.Text.ToString();
                nktv = new NhanKhauTamVangDTO(matamvang, ngaybd, ngaykt, lydo, noiden, madinhdanh);
                if (nktvbus.Update(nktv) == true)
                    MessageBox.Show("Sửa thành công");
                else
                    MessageBox.Show("Sửa không thành công");
            }
        }

        private void label_matamvang_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            List<ReplacementGroup> rg = new List<ReplacementGroup>();

            DateTime today = DateTime.Today;
            rg.Add(new ReplacementGroup("<hoTen>", textBox_hoten.Text));
            rg.Add(new ReplacementGroup("<ngaySinh>", tbNgaySinh.Text));
            rg.Add(new ReplacementGroup("<gioiTinh>", rdNam.Checked?"Nam":"Nữ"));
            rg.Add(new ReplacementGroup("<quocTich>", tbquoctich.Text));
            rg.Add(new ReplacementGroup("<cmnd>", textBox_madinhdanh.Text));
            rg.Add(new ReplacementGroup("<hoChieu>", tbhochieu.Text));
            rg.Add(new ReplacementGroup("<noiThuongTruTamTru>", tbDCThuongTru.Text));
            rg.Add(new ReplacementGroup("<tuNgay>", dtpNgayBatDau.Value.ToShortDateString()));
            rg.Add(new ReplacementGroup("<denNgay>", dtpNgayKetThuc.Value.ToShortDateString()));
            rg.Add(new ReplacementGroup("<lyDo>", tbLyDo.Text));
            rg.Add(new ReplacementGroup("<noiDen>", textBox_noiden.Text));


            

            rg.Add(new ReplacementGroup("<d3>", today.Day.ToString()));
            rg.Add(new ReplacementGroup("<m3>", today.Month.ToString()));
            rg.Add(new ReplacementGroup("<y3>", today.Year.ToString()));


            string srcPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\Mau HK05.doc";
            string dstPath = System.Windows.Forms.Application.StartupPath + "\\MauIn\\KetQua\\Mau HK05_" + textBox_madinhdanh.Text + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".doc";
            CreateWordHelper.CreateWordDocument(srcPath, dstPath, rg);

            MessageBox.Show(this, "Đã tạo thành công file thông tin với tên: " + dstPath, "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_madinhdanh_TextChanged(object sender, EventArgs e)
        {
            //textBox_hoten = null;

        }
    }
}
