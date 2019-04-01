using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class NhanKhauThuongTruBUS: AbstractFormBUS<NhanKhauThuongTruDTO>
    {
        NhanKhauThuongTruDAO obj = new NhanKhauThuongTruDAO();
        public override List<NhanKhauThuongTruDTO> GetAll()
        {
            return obj.getAll();
        }
        public List<NhanKhauThuongTruDTO> GetAllJoinNhanKhau()
        {
            return obj.getAllJoinNhanKhau();
        }
        public bool isValidNhanKhauTT(NhanKhauThuongTruDTO nktt)
        {
            if (!string.IsNullOrEmpty(nktt.HoTen) &&! string.IsNullOrEmpty(nktt.GioiTinh) &&! string.IsNullOrEmpty(nktt.NgaySinh.ToString())
                &&! string.IsNullOrEmpty(nktt.DanToc) &&! string.IsNullOrEmpty(nktt.NgheNghiep) &&! string.IsNullOrEmpty(nktt.MaDinhDanh) 
                &&! string.IsNullOrEmpty(nktt.HoChieu) &&! string.IsNullOrEmpty(nktt.NguyenQuan) &&! string.IsNullOrEmpty(nktt.NoiSinh) 
                &&! string.IsNullOrEmpty(nktt.QuocTich) &&! string.IsNullOrEmpty(nktt.TonGiao) &&! string.IsNullOrEmpty(nktt.SDT) 
                && nktt.MaNhanKhauThuongTru.IndexOf("TH")==0 &&! string.IsNullOrEmpty(nktt.SoSoHoKhau) &&! string.IsNullOrEmpty(nktt.NoiThuongTru)
                &&! string.IsNullOrEmpty(nktt.DiaChiHienNay) &&! string.IsNullOrEmpty(nktt.TrinhDoHocVan) &&! string.IsNullOrEmpty(nktt.TrinhDoChuyenMon) 
                &&! string.IsNullOrEmpty(nktt.QuanHeVoiChuHo))
                return true;
            return false;
        }
        public override bool Add(NhanKhauThuongTruDTO nktt)
        {
            if (!isValidNhanKhauTT(nktt)) return false;

            NhanKhauDAO nk = new NhanKhauDAO();
            return nk.insert(nktt)&&obj.insert(nktt);
        }
        public override bool Add_Table(NhanKhauThuongTruDTO data)
        {
            return obj.insert_table(data);
        }
        public bool XoaNKTT(string maNKTT)
        {
            return obj.XoaNKTT(maNKTT);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public override bool Update(NhanKhauThuongTruDTO nktt)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            
            return nk.update(nktt)&& obj.update(nktt);
        }
        public List<NhanKhauThuongTruDTO> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
        public List<NhanKhauThuongTruDTO> TimKiemJoinNhanKhau(string query)
        {
            return obj.TimKiemJoinNhanKhau(query);
        }
        //public bool DoiChuHo(List<NhanKhauThuongTruDTO> danhsach, string madinhdanh)
        //{
        //    return obj.doiChuHo(danhsach, madinhdanh);
        //}
    }
}
