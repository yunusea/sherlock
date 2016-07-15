using System;
using System.Collections.Generic;
using System.Data;

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
        public void Delete(object Entity)
        {
            _DataLayer.Delete(Entity);
        }
        public DataTable GetByCriterias(string TableName, string CriteriasText)
        {
            return _DataLayer.GetByCriterias(TableName, CriteriasText);
        }

        public DataTable AllList(object entity)
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

        public void Update(object Entity, string Criterias)
        {
            _DataLayer.Update(Entity, Criterias);
        }
    }
}
