using Contracts;
using Models.Model;
using OrmLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLayer.Business
{
    public class UserBusiness
    {
        public void AddUser(User Entity)
        {
            IoC.Castle.Resolve<IUserRepository>().Insert(Entity);
        }

        public User GetLoginUser(string UserName, string Password)
        {

            var criterias = "UserName='" + UserName + "' and Password='" + Password + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("User",criterias);

            List<User> returnList = new List<User>();
            returnList = ConvertToList<User>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultUsert = returnList.FirstOrDefault();

                return resultUsert;
            }
            else
            {
                return null;
            }
        }

        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                        pro.SetValue(objT, row[pro.Name]);
                }
                return objT;
            }).ToList();
        }

        public List<User> GetAllUserList()
        {
            var entity = new User();
            var returnEntities = IoC.Castle.Resolve<IUserRepository>().List(entity);

            List<User> userList = new List<User>();
            userList = ConvertToList<User>(returnEntities);

            return userList;
        }

        public void DeleteUser(User Entity)
        {

            IoC.Castle.Resolve<IUserRepository>().Delete(Entity);
        }

        public void UpdateAdd(User Entity, List<DataParameter> criteriasList)
        {

        }
    }
}
