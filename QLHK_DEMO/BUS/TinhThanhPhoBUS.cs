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
    public class TinhThanhPhoBUS: AbstractFormBUS<TINHTHANHPHO>
    {
        TinhThanhPhoDAO obj = new TinhThanhPhoDAO();

        public override List<TINHTHANHPHO> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(TINHTHANHPHO data)
        {
            return obj.insert(data);
        }
        public bool deleteTTP(string id)
        {
            return obj.deleteTTP(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(TINHTHANHPHO data)
        {
            return obj.update(data);
        }
        public override bool Add_Table(TINHTHANHPHO data)
        {
            return obj.insert_table(data);

        }

        public List<TINHTHANHPHO> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }

    }
}
