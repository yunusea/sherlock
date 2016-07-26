using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLayer.Business
{
    public class MessageBusiness
    {
        public void SendMessage(Message Entity)
        {
            Entity.Status = false;
            Entity.Date = DateTime.Now;

            IoC.Castle.Resolve<IUserRepository>().Insert(Entity);
        }

        public List<Message> GetUserInBoxMessages(int Id)
        {
            var criterias = "ReceiverUser='" + Id + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("Message", criterias);

            List<Message> returnList = new List<Message>();
            returnList = ConvertToList<Message>(returnObjects);

            if (returnList.Count > 0)
            {
                return returnList.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Message> GetUserSendBoxMessages(int Id)
        {
            var criterias = "SendUser='" + Id + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("Message", criterias);

            List<Message> returnList = new List<Message>();
            returnList = ConvertToList<Message>(returnObjects);

            if (returnList.Count > 0)
            {
                return returnList.ToList();
            }
            else
            {
                return null;
            }
        }

        public Message GetByMessage(int Id)
        {
            var criterias = "Id='" + Id + "'";

            var returnObjects = IoC.Castle.Resolve<IUserRepository>().GetByCriterias("Message", criterias);

            List<Message> returnList = new List<Message>();
            returnList = ConvertToList<Message>(returnObjects);

            if (returnList.Count > 0)
            {
                var resultObject = returnList.FirstOrDefault();
                return resultObject;
            }
            else
            {
                throw new NotSupportedException("Mesaj Bulunamadı");
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

        public void DeleteMessage(Message Entity)
        {
            IoC.Castle.Resolve<IUserRepository>().Delete(Entity);
        }

        public void ChangeStatus(int Id)
        {
            var updateCriterias = "Id='" + Id + "'";
            var setList = "Status='true'";
            var TableName = "Message";

            IoC.Castle.Resolve<IUserRepository>().SpecialUpdate(TableName, setList, updateCriterias);
        }
    }
}
