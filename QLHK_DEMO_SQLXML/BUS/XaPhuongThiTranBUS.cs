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
    public class 
        
        XaPhuongThiTranBUS: AbstractFormBUS<XAPHUONGTHITRAN>
    {
        XaPhuongThiTranDAO obj = new XaPhuongThiTranDAO();

        public override List<XAPHUONGTHITRAN> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(XAPHUONGTHITRAN data)
        {
            return obj.insert(data);
        }
        public override bool Add_Table(XAPHUONGTHITRAN data)
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

        public override bool Update(XAPHUONGTHITRAN data)
        {
            return obj.update(data);
        }

        public List<XAPHUONGTHITRAN> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
    }
}
