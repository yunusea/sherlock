using Contracts;
using System;
using System.Data;
using Repositorys;

namespace Repository.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly OrmMsSqlManager Db = new OrmMsSqlManager();

        public bool Insert(object Entity)
        {
            try
            {
                Db.Insert(Entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable List(object Entity)
        {
            try
            {
                return Db.AllList(Entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(object Entity, string Criterias)
        {
            try
            {
                Db.Update(Entity, Criterias);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetByCriterias(string TableName, string CriteriasText)
        {
            try
            {
                return Db.GetByCriterias(TableName, CriteriasText);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(object Entity)
        {
            try
            {
                Db.Delete(Entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object FirsOrCriterias(string TableName, string CriteriasText)
        {
            try
            {
                return Db.GetByCriterias(TableName, CriteriasText);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SpecialUpdate(string TableName, string SetList, string CriterList)
        {
            try
            {
                Db.SpecialUpdate(TableName, SetList, CriterList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
