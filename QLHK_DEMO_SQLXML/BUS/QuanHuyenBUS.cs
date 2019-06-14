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
    public class QuanHuyenBUS: AbstractFormBUS<QUANHUYEN>
    {
        QuanHuyenDAO obj = new QuanHuyenDAO();

        public override List<QUANHUYEN> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(QUANHUYEN data)
        {
            return obj.insert(data);
        }
        public bool deleteQH(string id)
        {
            return obj.deleteQH(id);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(QUANHUYEN data)
        {
            return obj.update(data);
        }
        public override bool Add_Table(QUANHUYEN data)
        {
            return obj.insert_table(data);
        }

        public List<QUANHUYEN> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
    }
}
