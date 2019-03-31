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
        
        XaPhuongThiTranBUS: AbstractFormBUS<XaPhuongThiTranDTO>
    {
        XaPhuongThiTranDAO obj = new XaPhuongThiTranDAO();

        public override DataSet GetAll()
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
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(XaPhuongThiTranDTO data, int r)
        {
            return obj.update(data, r);
        }

        public DataSet TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
    }
}
