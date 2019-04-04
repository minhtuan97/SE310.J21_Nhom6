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
    public class QuanHuyenBUS: AbstractFormBUS<QuanHuyenDTO>
    {
        QuanHuyenDAO obj = new QuanHuyenDAO();

        public override List<QuanHuyenDTO> GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(QuanHuyenDTO data)
        {
            return obj.insert(data);
        }

        public override bool Delete(int r)
        {
            return obj.delete(r);
        }

        public override bool Update(QuanHuyenDTO data)
        {
            return obj.update(data);
        }
        public override bool Add_Table(QuanHuyenDTO data)
        {
            return obj.insert_table(data);
        }

        public List<QuanHuyenDTO> TimKiem(string query)
        {
            return obj.TimKiem(query);
        }
    }
}
