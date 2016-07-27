using Contracts;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLayer.Business
{
    public class GameBusiness
    {
        public List<Game> GetAllGameList()
        {
            var entity = new Game();
            var returnEntities = IoC.Castle.Resolve<IGameRepository>().List(entity);

            List<Game> userList = new List<Game>();
            userList = ConvertToList<Game>(returnEntities);

            return userList;
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
