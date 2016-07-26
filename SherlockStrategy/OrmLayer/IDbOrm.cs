using System.Data;

namespace OrmLayer
{
    public interface IDbOrm
    {
        void Insert(object entity);
        void Update(object entity, string Criterias);
        void SpecialUpdate(string TableName, string SetList, string CriterList);
        void Delete(object entity);
        DataTable AllList(object entity);
        DataTable GetByCriterias(string TableName, string CriteriasText);
    }
}
