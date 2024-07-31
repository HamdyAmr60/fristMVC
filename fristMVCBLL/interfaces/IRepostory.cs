using fristMVCDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fristMVCBLL.interfaces
{
    internal interface IRepostory<T>
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        int Add(T department);
        int Update(T department);
        int Delete(T department);

    }
}
