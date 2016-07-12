using System;
using System.Collections.Generic;

namespace OrmLayer
{
    public class OrmManager
    {
        private IDbOrm _DataLayer = null;

        public OrmManager(string ConnectionType, string ConnectionString)
        {
            if (_DataLayer == null)
            {
                _DataLayer = OrmLayerFactory.Create(ConnectionType, ConnectionString);
            }
        }

        public void Insert(object Entity)
        {
            _DataLayer.Insert(Entity);
        }

        public IEnumerable<object> AllList(object entity)
        {
            try
            {
                return _DataLayer.AllList(entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(object Entity, List<DataParameter> Criterias)
        {
            _DataLayer.Update(Entity, Criterias);
        }
    }
}
