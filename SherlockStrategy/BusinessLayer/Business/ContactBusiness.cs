using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLayer.Business
{
    public class ContactBusiness
    {
        public void SendContactMessage(Contact Entity)
        {
            Entity.Status = false;
            IoC.Castle.Resolve<IContactRepository>().Insert(Entity);
        }

        public List<Contact> GetContactFormMessage()
        {
            var entity = new Contact();
            var returnEntities = IoC.Castle.Resolve<IContactRepository>().List(entity);

            List<Contact> contactList = new List<Contact>();
            contactList = ConvertToList<Contact>(returnEntities);

            return contactList;
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
