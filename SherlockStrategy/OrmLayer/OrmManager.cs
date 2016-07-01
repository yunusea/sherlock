using System.Collections.Generic;

namespace OrmLayer
{
    public class OrmManager<T> where T : class
    {
        private IDbOrm<T> _DataLayer = null;

        public OrmManager(string ConnectionType, string ConnectionString)
        {
            if (_DataLayer == null)
            {
                _DataLayer = OrmLayerFactory<T>.Create(ConnectionType, ConnectionString);
            }
        }

        public void Insert(T Entity)
        {
            _DataLayer.Insert(Entity);
        }

        public void Update(T Entity, List<DataParameter> Criterias)
        {
            _DataLayer.Update(Entity, Criterias);
        }
    }
}
