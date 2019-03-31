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

        public override DataSet GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(TinhThanhPhoDTO data)
        {
            return obj.insert(data);
        }

        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(TinhThanhPhoDTO data, int r)
        {
            return obj.update(data, r);
        }
        public override bool Add_Table(TinhThanhPhoDTO data)
        {
            return obj.insert_table(data);

        }

        public DataSet TimKiem(string query)
        {
            return obj.TimKiem(query);
        }

    }
}
