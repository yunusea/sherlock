using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmLayer;
using System.Data;

namespace Repositorys.Repository
{
    public class UserRepository : IUserRepository
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

        public bool StatusChange(bool Status)
        {
            throw new NotImplementedException();
        }

        public bool Update(object Entity, List<DataParameter> Criterias)
        {
            throw new NotImplementedException();
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
    }
}
