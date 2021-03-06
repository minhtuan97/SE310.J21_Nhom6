﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public abstract class AbstractFormBUS<T>
    {
        public static void submitChangeDAO()
        {
            DBConnection<T>.qlhk.SubmitChanges();
        }
        public Exception getError()
        {
            return DBConnection<T>.error;
        }
        public abstract List<T> GetAll();
        //public abstract DataSet GetAll();
        public abstract bool Add(T data);
        public abstract bool Add_Table(T data);
        public abstract bool Delete(int r);
        public abstract bool Update(T data);
    }
}
