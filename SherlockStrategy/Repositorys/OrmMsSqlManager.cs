using OrmLayer;
using System;
using System.Configuration;
using System.Data;

namespace Repositorys
{

    public class OrmMsSqlManager : IDisposable
    {
        public OrmManager _OrmManager = null;

        public OrmMsSqlManager()
        {
            _OrmManager = new OrmManager(
                ConfigurationManager.AppSettings["DataLayerType"].ToString(),
                ConfigurationManager.ConnectionStrings["SherlockDbContext"].ToString());
        }

        public void Dispose()
        {
            _OrmManager = null;
            GC.Collect();
        }

        public void Insert(object Entity)
        {
            _OrmManager.Insert(Entity);
        }

        public void Delete(object Entity)
        {
            _OrmManager.Delete(Entity);
        }

        public DataTable GetByCriterias(string TableName, string CriteriasText)
        {
            return _OrmManager.GetByCriterias(TableName, CriteriasText);
        }

        public DataTable AllList(object entity)
        {
            try
            {
                return _OrmManager.AllList(entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(object Entity, string criterias)
        {
            _OrmManager.Update(Entity, criterias);
        }

        public void SpecialUpdate(string TableName, string SetList, string CriterList)
        {
            _OrmManager.SpecialUpdate(TableName, SetList, CriterList);
        }
    }
}
