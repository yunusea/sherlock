using OrmLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        bool Insert(T Entity);
        bool Update(T Entity, List<DataParameter> Criterias);
        IEnumerable<T> List();
        T GetById(int Id);
    }
}
