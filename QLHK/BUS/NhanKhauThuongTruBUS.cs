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
            if (!string.IsNullOrEmpty(nktt.db.HOTEN) &&! string.IsNullOrEmpty(nktt.db.GIOITINH) &&! string.IsNullOrEmpty(nktt.db.NGAYSINH.ToString())
                &&! string.IsNullOrEmpty(nktt.db.DANTOC) &&! string.IsNullOrEmpty(nktt.db.NGHENGHIEP) &&! string.IsNullOrEmpty(nktt.db.MADINHDANH) 
                /*&&! string.IsNullOrEmpty(nktt.db.HOCHIEU)*/ &&! string.IsNullOrEmpty(nktt.db.NOISINH) 
                &&! string.IsNullOrEmpty(nktt.db.QUOCTICH) &&! string.IsNullOrEmpty(nktt.db.TONGIAO) &&! string.IsNullOrEmpty(nktt.db.SDT) 
                && nktt.dbnktt.MANHANKHAUTHUONGTRU.IndexOf("TH")==0 /*&&! string.IsNullOrEmpty(nktt.dbnktt.SOSOHOKHAU)*/ /*&&! string.IsNullOrEmpty(nktt.db.NOITHUONGTRU)*/
                &&! string.IsNullOrEmpty(nktt.db.DIACHIHIENNAY) &&! string.IsNullOrEmpty(nktt.db.TRINHDOHOCVAN) &&! string.IsNullOrEmpty(nktt.db.TRINHDOCHUYENMON) 
                &&! string.IsNullOrEmpty(nktt.dbnktt.QUANHEVOICHUHO))
                return true;
            return false;
        }
        public override bool Add(NhanKhauThuongTruDTO nktt)
        {
            if (!isValidNhanKhauTT(nktt)) return false;

            NhanKhauDAO nk = new NhanKhauDAO();
            List<NhanKhau> ls = nk.TimKiem("madinhdanh='" + nktt.db.MADINHDANH + "'");
            if (nk.insert(nktt)|| ls.Count > 0)
            {
                if (obj.insert(nktt))
                    return true;
            }
            return false;
        }
        public override bool Add_Table(NhanKhauThuongTruDTO data)
        {
            return obj.insert_table(data);
        }
        public bool XoaNKTT(NhanKhauThuongTruDTO nktt)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            TieuSuDAO ts = new TieuSuDAO();
            TienAnTienSuDAO ta = new TienAnTienSuDAO();
            string madinhdanh = nktt.dbnktt.MADINHDANH;
            List<TieuSuDTO> tsdto = ts.TimKiem("madinhdanh='" + madinhdanh + "'");
            List<TienAnTienSuDTO> tadto = ta.TimKiem("madinhdanh='" + madinhdanh + "'");

            foreach (TieuSuDTO s in tsdto)
            {
                if (!ts.deleteTS(s.db))
                {
                    return false;
                }
            }

            foreach (TienAnTienSuDTO a in tadto)
            {
                if (!ta.deleteTATS(a.db))
                {
                    return false;
                }
            }

            if (obj.XoaNKTT(nktt.dbnktt.MANHANKHAUTHUONGTRU))
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
        public bool updateTTThuongTru(string manktt, SOHOKHAU shk)
        {
            return obj.updateTTThuongTru(manktt, shk);
        }
        public override bool Update(NhanKhauThuongTruDTO nktt)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            if (nk.update(nktt))
            {
                if (obj.update(nktt))
                    return true;
            }
            return false;
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
