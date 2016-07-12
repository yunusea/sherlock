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
        public void AddUser(User Entity)
        {
            IoC.Castle.Resolve<IUserRepository>().Insert(Entity);
        }

        public IEnumerable<object> GetAllUserList()
        {
            var entity = new User();
            return IoC.Castle.Resolve<IUserRepository>().List(entity);
        }

        public void UpdateAdd(User Entity, List<DataParameter> criteriasList)
        {

        }
    }
}
