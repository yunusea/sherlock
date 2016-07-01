using OrmLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{

    public class OrmAccessManager<T> : IDisposable where T : class
    {
        public OrmManager<T> _OrmManager = null;
        public OrmAccessManager()
        {
            _OrmManager = new OrmManager<T>(
                ConfigurationManager.AppSettings["DataLayerType"].ToString(),
                ConfigurationManager.ConnectionStrings["SherlockDbContext"].ToString());
        }

        public void Dispose()
        {
            _OrmManager = null;
            GC.Collect();
        }

        public void Insert(T entity)
        {
            _OrmManager.Insert(entity);
        }

        public void Update(T entity, List<DataParameter> criterias)
        {
            _OrmManager.Update(entity, criterias);
        }
    }
}
