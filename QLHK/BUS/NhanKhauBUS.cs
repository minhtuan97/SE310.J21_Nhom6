﻿
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
    public class NhanKhauBUS:AbstractFormBUS<NhanKhau>
    {
        NhanKhauDAO objnhankhau = new NhanKhauDAO();
        public override DataSet GetAll()
        {
            return objnhankhau.getAll();
        }
        public override bool Add(NhanKhau nk)
        {
            return objnhankhau.insert(nk);
        }
          public  bool Delete(string madinhdanh)
        {
            return objnhankhau.delete(madinhdanh);
        }
        public override bool Update(NhanKhau nk, int r)
        {
            return objnhankhau.update(nk, r);
        }
        public override bool Delete(int row)
        {
            return objnhankhau.delete(row);
        }
        public bool Update(NhanKhau nk)
        {
            return false;
        }
        public override bool Add_Table(NhanKhau data)
        {
            return objnhankhau.insert_table(data);
        }
        public DataSet TimKiem(string query)
        {
            return objnhankhau.TimKiem(query);
        }
        public DataSet TimKiemTheoCuTru(string madinhdanh)
        {
            return objnhankhau.TimKiemTheoCuTru(madinhdanh);
        }
    }
}
