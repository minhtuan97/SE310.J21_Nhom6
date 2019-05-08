﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class 
        
        XaPhuongThiTranBUS: AbstractFormBUS<XaPhuongThiTranDTO>
    {
        XaPhuongThiTranDAO obj = new XaPhuongThiTranDAO();

        public override List<XaPhuongThiTranDTO> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(XaPhuongThiTranDTO data)
        {
            return obj.insert(data);
        }
        public override bool Add_Table(XaPhuongThiTranDTO data)
        {
            return obj.insert_table(data);
        }
        public bool deleteXPTT(string id)
        {
            return obj.deleteXPTT(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(XaPhuongThiTranDTO data)
        {
            return obj.update(data);
        }

        public List<XaPhuongThiTranDTO> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
    }
}
