using OrmLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{

    public class OrmMsSqlManager : IDisposable
    {
        public OrmManager _OrmManager = null;
        public OrmMsSqlManager()
        {
            _OrmManager = new OrmManager(
                ConfigurationManager.AppSettings["DataLayerType"].ToString(),
                ConfigurationManager.ConnectionStrings["SherlockDbContext"].ToString());
        }

        public void Dispose()
        {
            _OrmManager = null;
            GC.Collect();
        }

        public void Insert(object Entity)
        {
            _OrmManager.Insert(Entity);
        }

        public IEnumerable<object> AllList(object entity)
        {
            try
            {
                return _OrmManager.AllList(entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(object Entity, List<DataParameter> criterias)
        {
            _OrmManager.Update(Entity, criterias);
        }
    }
}
