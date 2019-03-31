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
    public class TienAnTienSuBUS : AbstractFormBUS<TienAnTienSuDTO>
    {
        public TienAnTienSuBUS() : base() { }
        TienAnTienSuDAO tienantiensu = new TienAnTienSuDAO();

        public override DataSet GetAll()
        {
            return tienantiensu.getAll();
        }

        public override bool Add(TienAnTienSuDTO data)
        {
            return tienantiensu.insert(data);
        }

        public override bool Add_Table(TienAnTienSuDTO data)
        {
            return tienantiensu.insert_table(data);
        }

        public override bool Delete(int r)
        {
            return tienantiensu.delete(r);
        }

        public override bool Update(TienAnTienSuDTO data, int r)
        {
            return tienantiensu.update(data, r);
        }

        public DataSet TimKiem(string query)
        {
            return tienantiensu.TimKiem(query);
        }
    }
}
