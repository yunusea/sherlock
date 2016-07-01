using Contracts;
using DataLayer.Model;
using OrmLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business
{
    public class UserBusiness
    {
        public void AddUser(User entity)
        {
            IoC.Castle.Resolve<IUserRepository<User>>().Insert(entity);
        }

        public void UpdateAdd(User entity, List<DataParameter> criteriasList)
        {

        }
    }
}
