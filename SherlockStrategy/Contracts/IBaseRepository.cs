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
        bool Update(object Entity, string Criterias);
        bool SpecialUpdate(string TableName, string SetList, string CriterList);
        DataTable List(object Entity);
        DataTable GetByCriterias(string TableName, string CriteriasText);
        bool Delete(object Entity);
    }
}
