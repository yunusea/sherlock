using System.Collections.Generic;

namespace OrmLayer
{
    public interface IDbOrm
    {
        void Insert(object entity);
        void Update(object entity, List<DataParameter> Criterias);
        void Delete(object entity);
        IEnumerable<object> AllList(object entity);
    }
}
