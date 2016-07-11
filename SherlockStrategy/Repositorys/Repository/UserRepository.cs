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
    public class UserRepository : IUserRepository<User>
    {
        private readonly OrmMsSqlManager<User> Db = new OrmMsSqlManager<User>();
        public bool Insert(User Entity)
        {
            try
            {
                Db.Insert(Entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> List()
        {
            throw new NotImplementedException();
        }

        public bool StatusChange(bool Status)
        {
            throw new NotImplementedException();
        }

        public bool Update(User Entity, List<DataParameter> Criterias)
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
