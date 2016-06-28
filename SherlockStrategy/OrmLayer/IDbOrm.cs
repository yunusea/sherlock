using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLayer
{
    public interface IDbOrm<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity, List<DataParameter> Criterias);
        void Delete(T entity);
        IEnumerable<T> SelectDataList();
    }
}
