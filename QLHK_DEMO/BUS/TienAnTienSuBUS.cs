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
    public class TienAnTienSuBUS : AbstractFormBUS<TIENANTIENSU>
    {
        public TienAnTienSuBUS() : base() { }

        TienAnTienSuDAO tienantiensu = new TienAnTienSuDAO();

        public override List<TIENANTIENSU> GetAll()
        {
            return tienantiensu.getAll();
        }

        public override bool Add(TIENANTIENSU data)
        {
            return tienantiensu.insert(data);
        }

        public override bool Add_Table(TIENANTIENSU data)
        {
            return tienantiensu.insert_table(data);
        }

        public bool DeleteTATS(string id)
        {
            return tienantiensu.deleteTATS(id);
        }

        public override bool Delete(int r)
        {
            return tienantiensu.delete(r);
        }

        public override bool Update(TIENANTIENSU data)
        {
            return tienantiensu.update(data);
        }

        public List<TIENANTIENSU> TimKiem(string query)
        {
            return tienantiensu.TimKiem(query);
        }
    }
}
