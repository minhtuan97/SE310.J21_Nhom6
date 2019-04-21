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
    public class TinhThanhPhoBUS: AbstractFormBUS<TinhThanhPhoDTO>
    {
        TinhThanhPhoDAO obj = new TinhThanhPhoDAO();

        public override List<TinhThanhPhoDTO> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(TinhThanhPhoDTO data)
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

        public override bool Update(TinhThanhPhoDTO data)
        {
            return obj.update(data);
        }
        public override bool Add_Table(TinhThanhPhoDTO data)
        {
            return obj.insert_table(data);

        }

        public List<TinhThanhPhoDTO> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }

    }
}
