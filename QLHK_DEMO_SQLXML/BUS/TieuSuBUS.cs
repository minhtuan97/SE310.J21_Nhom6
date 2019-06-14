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
    public class TieuSuBUS : AbstractFormBUS<TIEUSU>
    {
        public TieuSuBUS() : base() { }

        TieuSuDAO tieusu = new TieuSuDAO();

        public override List<TIEUSU> GetAll()
        {
            return tieusu.getAll();
        }

        public override bool Add(TIEUSU data)
        {
            return tieusu.insert(data);
        }

        public override bool Add_Table(TIEUSU data)
        {
            return tieusu.insert_table(data);
        }

        public override bool Delete(int r)
        {
            return tieusu.delete(r);
        }
        
        public bool DeleteTS(string id)
        {
            return tieusu.deleteTS(id);
        }

        public override bool Update(TIEUSU data)
        {
            return tieusu.update(data);
        }

        public List<TIEUSU> TimKiem(string query)
        {
            return tieusu.TimKiem(query);
        }
    }
}
