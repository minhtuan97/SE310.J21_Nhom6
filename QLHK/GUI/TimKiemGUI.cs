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
    public partial class TimKiemGUI : Form
    {
        NhanKhauBUS nk;
        SoHoKhauBUS shk;
        SoTamTruBUS stt;
        NhanKhauThuongTruBUS nkthuongtru;
        NhanKhauTamTruBUS nktamtru;

        NhanKhau nkDTO;
        NhanKhauThuongTruDTO nkthDTO;
        NhanKhauTamTruDTO nkttDTO;
        SoHoKhauDTO shkDTO;
        SoTamTruDTO sttDTO;

        public TimKiemGUI()
        {
            InitializeComponent();
            nk = new NhanKhauBUS();
            shk = new SoHoKhauBUS();
            stt = new SoTamTruBUS();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string value = tbTimKiem.Text.ToString();
            if (value== "")
            {
                MessageBox.Show("Vui lòng nhập một giá trị!");
                return;
            }

            //if (rdHoKhau.Checked)
            //{
            //    if(/*3 tầng tìm kiếm hộ khẩu, sổ tạm trú*/ false)

            //    {
            //        MessageBox.Show(this, "Không thể tìm thấy hộ khẩu(sổ tạm trú)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //if(/*là hộ khẩu*/ true)
            //using (SoHoKhauGUI a = new SoHoKhauGUI(tbTimKiem.Text))
            //{
            // DataSet ds = shk.TimKiem("sosohokhau='" + tbTimKiem.Text + "'");
            //DataRow dt = ds.Tables["sohokhau"].Rows[0];
            //a.ShowDialog(this);
            //shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString()
            //    , (DateTime)dt["ngaycap"], dt["sodangky"].ToString());

            //            shkDTO = a.shkDTO;
            //    }
            //}
            //else
            //{
            //    if (/*3 tầng tìm kiếm nhân khẩu thường trú, tạm trú*/ false)

            //    {
            //        MessageBox.Show(this, "Không thể tìm thấy nhân khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //if (/*là nhân khẩu thường trú*/ true)
            //    using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI(tbTimKiem.Text,-1))
            //    {
            //DataSet ds = shk.TimKiem("sosohokhau='" + tbTimKiem.Text + "'");
            //DataRow dt = ds.Tables["sohokhau"].Rows[0];
            //a.ShowDialog(this);
            //shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString()
            //    , (DateTime)dt["ngaycap"], dt["sodangky"].ToString());
            //            nkthDTO = a.nkttDTO;
            //        }
            //}
            DataSet dt = new DataSet();

            // tìm trong sổ hộ khẩu
            if (rdHoKhau.Checked)
            {
                shk = new SoHoKhauBUS();
                List<SoHoKhauDTO> shkdto = shk.TimKiem("sosohokhau='" + value + "'");
                if (shkdto.Count > 0)
                {
                    SoHoKhauGUI fr_SoHoKhau = new SoHoKhauGUI(value);
                    fr_SoHoKhau.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sổ hộ khẩu: " + value);
                }
                return;
            }

            //Tìm trong sổ tạm trú
            if (rdTamTru.Checked)
            {
                stt = new SoTamTruBUS();
                List<SoTamTruDTO> sttdto = stt.TimKiem("sosotamtru='" + value + "'");
                if (sttdto.Count > 0)
                {
                    SoTamTruGUI fr_SoTamTru = new SoTamTruGUI(value);
                    fr_SoTamTru.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sổ tạm trú: " + value);
                }
                return;
            }


            //Tìm nhân khẩu tạm trú hoặc thường thú
            if (rdNhanKhau.Checked)
            {
                //Tìm trong bảng nhân khẩu thường trú
                nkthuongtru = new NhanKhauThuongTruBUS();
                List<NhanKhauThuongTruDTO> nkth = nkthuongtru.TimKiem("madinhdanh='" + value + "'");
                if (nkth.Count > 0)
                {
                    NhanKhauThuongTruGUI fr_NhanKhauThuongTru = new NhanKhauThuongTruGUI(value, 0);
                    fr_NhanKhauThuongTru.ShowDialog();
                    return;
                }


                //Tìm trong bảng nhân khẩu tạm trú
                nktamtru = new NhanKhauTamTruBUS();
                List<NhanKhauTamTruDTO> nktt = nktamtru.TimKiem("madinhdanh='" + value + "'");
                if (nktt.Count > 0)
                {
                    NhanKhauTamTruGUI fr_NhanKhauTamTru = new NhanKhauTamTruGUI(value, "1");
                    fr_NhanKhauTamTru.ShowDialog();
                    return;
                }

                MessageBox.Show("Không tìm thấy nhân khẩu có mã định danh:" + value);

                return;
            }


        }
    }
}
