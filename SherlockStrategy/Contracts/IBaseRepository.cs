using OrmLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBaseRepository
    {
        bool Insert(object Entity);
        bool Update(object Entity, List<DataParameter> Criterias);
        DataTable List(object entity);
        object GetById(int Id);
        bool Delete(object Entity);
    }
}
