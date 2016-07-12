using Contracts;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmLayer;

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

        public IEnumerable<object> List(object Entity)
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

        public object GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
