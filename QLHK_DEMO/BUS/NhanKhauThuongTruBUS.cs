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
    public class NhanKhauThuongTruBUS: AbstractFormBUS<NHANKHAUTHUONGTRU>
    {
        NhanKhauThuongTruDAO obj = new NhanKhauThuongTruDAO();
        public override List<NHANKHAUTHUONGTRU> GetAll()
        {
            return obj.getAll();
        }
        public List<NHANKHAUTHUONGTRU> GetAllJoinNhanKhau()
        {
            return obj.getAllJoinNhanKhau();
        }
        public bool isValidNhanKhauTT(NHANKHAUTHUONGTRU nktt)
        {
            if (!string.IsNullOrEmpty(nktt.NHANKHAU.HOTEN) &&! string.IsNullOrEmpty(nktt.NHANKHAU.GIOITINH) &&! string.IsNullOrEmpty(nktt.NHANKHAU.NGAYSINH.ToString())
                &&! string.IsNullOrEmpty(nktt.NHANKHAU.DANTOC) &&! string.IsNullOrEmpty(nktt.NHANKHAU.NGHENGHIEP) &&! string.IsNullOrEmpty(nktt.NHANKHAU.MADINHDANH) 
                /*&&! string.IsNullOrEmpty(nktt.NHANKHAU.HOCHIEU)*/ &&! string.IsNullOrEmpty(nktt.NHANKHAU.NOISINH) 
                &&! string.IsNullOrEmpty(nktt.NHANKHAU.QUOCTICH) &&! string.IsNullOrEmpty(nktt.NHANKHAU.TONGIAO) &&! string.IsNullOrEmpty(nktt.NHANKHAU.SDT) 
                && nktt.MANHANKHAUTHUONGTRU.IndexOf("TH")==0 /*&&! string.IsNullOrEmpty(nktt.SOSOHOKHAU)*/ /*&&! string.IsNullOrEmpty(nktt.NHANKHAU.NOITHUONGTRU)*/
                &&! string.IsNullOrEmpty(nktt.NHANKHAU.DIACHIHIENNAY) &&! string.IsNullOrEmpty(nktt.NHANKHAU.TRINHDOHOCVAN) &&! string.IsNullOrEmpty(nktt.NHANKHAU.TRINHDOCHUYENMON) 
                &&! string.IsNullOrEmpty(nktt.QUANHEVOICHUHO))
                return true;
            return false;
        }
        public override bool Add(NHANKHAUTHUONGTRU nktt)
        {
            if (!isValidNhanKhauTT(nktt)) return false;

            //NhanKhauDAO nk = new NhanKhauDAO();
            //List<NHANKHAU> ls = nk.TimKiem("madinhdanh='" + nktt.NHANKHAU.MADINHDANH + "'");
            //if (nk.insert(nktt.NHANKHAU)|| ls.Count > 0)
            //{
                if (obj.insert(nktt))
                    return true;
            //}
            return false;
        }
        public override bool Add_Table(NHANKHAUTHUONGTRU data)
        {
            return obj.insert_table(data);
        }
        public bool XoaNKTT(NHANKHAUTHUONGTRU nktt)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            TieuSuDAO ts = new TieuSuDAO();
            TienAnTienSuDAO ta = new TienAnTienSuDAO();
            string madinhdanh = nktt.MADINHDANH;
            List<TIEUSU> tsdto = ts.TimKiem("madinhdanh='" + madinhdanh + "'");
            List<TIENANTIENSU> tadto = ta.TimKiem("madinhdanh='" + madinhdanh + "'");

            foreach (TIEUSU s in tsdto)
            {
                if (!ts.deleteTS(s))
                {
                    return false;
                }
            }

            foreach (TIENANTIENSU a in tadto)
            {
                if (!ta.deleteTATS(a))
                {
                    return false;
                }
            }

            if (obj.XoaNKTT(nktt.MANHANKHAUTHUONGTRU))
            {
                if (nk.delete(madinhdanh))
                    return true;
            }
            return false;
        }
        public bool deleteNKTT(string id)
        {
            return obj.deleteNKTT(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public bool updateTTThuongTru(string manktt, string sshk)
        {
            return obj.updateTTThuongTru(manktt, sshk);
        }
        public bool UpdateNKTT(NHANKHAUTHUONGTRU nktt)
        {
            return obj.update(nktt);
        }
        public override bool Update(NHANKHAUTHUONGTRU nktt)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            if (nk.update(nktt.NHANKHAU))
            {
                if (obj.update(nktt))
                    return true;
            }
            return false;
        }
        public List<NHANKHAUTHUONGTRU> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
        public List<NHANKHAUTHUONGTRU> TimKiemJoinNhanKhau(string query)
        {
            return obj.TimKiemJoinNhanKhau(query);
        }
        //public bool DoiChuHo(List<NHANKHAUTHUONGTRU> danhsach, string madinhdanh)
        //{
        //    return obj.doiChuHo(danhsach, madinhdanh);
        //}
    }
}
