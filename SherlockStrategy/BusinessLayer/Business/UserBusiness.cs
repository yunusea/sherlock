using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace BusinessLayer.Business
{
    public class UserBusiness
    {
        public void AddUser(User Entity)
        {
            IoC.Castle.Resolve<IUserRepository>().Insert(Entity);
        }

        public void UpdateUser(User Entity)
        {
            var criterias = "Id=" + Entity.Id;
            IoC.Castle.Resolve<IUserRepository>().Update(Entity, criterias);
        }

        public void UpdateProfile(string UserName, string Password, string NewPassword)
        {
            var criterias = "UserName='" + UserName + "' and Password='" + Password + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("User", criterias);

            List<User> returnList = new List<User>();
            returnList = ConvertToList<User>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultUser = returnList.FirstOrDefault();

                Type myType = resultUser.GetType();

                var updateCriterias = "Id='" + resultUser.Id + "'";
                var setList = "Password='" + NewPassword + "'";
                var TableName = myType.Name;

                IoC.Castle.Resolve<IUserRepository>().SpecialUpdate(TableName, setList, updateCriterias);
            }
            else
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu.");
            }
        }

        public User GetLoginUser(string UserName, string Password)
        {
            var criterias = "UserName='" + UserName + "' and Password='" + Password + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("User", criterias);

            List<User> returnList = new List<User>();
            returnList = ConvertToList<User>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultUser = returnList.FirstOrDefault();

                return resultUser;
            }
            else
            {
                return null;
            }
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

        public void ChangeStatu(User Entity)
        {
            try
            {
                Type myType = Entity.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                var criterias = "Id='" + Entity.Id + "'";
                var setList = "Status='" + (!Entity.Status) + "'";
                var TableName = myType.Name;

                IoC.Castle.Resolve<IUserRepository>().SpecialUpdate(TableName, setList, criterias);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("Beklenmedik bir hata oluştu.", ex);
            }
        }

        public User GetUserInfo(int Id)
        {
            var UserTableName = "User";
            var UserCriterList = "Id='" + Id + "'";
            var resultUserObject = IoC.Castle.Resolve<IUserRepository>().GetByCriterias(UserTableName, UserCriterList);
            List<User> returnList = new List<User>();
            returnList = ConvertToList<User>(resultUserObject);

            if (returnList.Count > 0)
            {
                var resultUser = returnList.FirstOrDefault();
                return resultUser;
            }
            else
            {
                throw new NotSupportedException("Beklenmedik Bir Problem İle Karşılaşıldı");
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
                    {
                        pro.SetValue(objT, row[pro.Name]);
                    }
                }
                return objT;
            }).ToList();
        }
    }
}
