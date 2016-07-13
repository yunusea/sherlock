using Contracts;
using DataLayer.Model;
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
<<<<<<< HEAD
        private readonly OrmMsSqlManager Db = new OrmMsSqlManager();
        public bool Insert(object Entity)
=======
        private readonly OrmMsSqlManager<User> Db = new OrmMsSqlManager<User>();
        public bool Insert(User Entity)
>>>>>>> 6012b2a54b7483448f8dd89c0fe36b5da31ceb29
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

        public object GetById(int Id)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
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
=======
        public User GetById(int Id)
        {
            throw new NotImplementedException();
>>>>>>> 6012b2a54b7483448f8dd89c0fe36b5da31ceb29
        }
    }
}
