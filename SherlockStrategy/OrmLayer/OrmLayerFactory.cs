using System;

namespace OrmLayer
{
    public class OrmLayerFactory
    {
        public static IDbOrm Create(string DataLayerType, string ConnectionString)
        {
            IDbOrm dataLayer = null;
            Type T = Type.GetType(DataLayerType);
            object objectHandle = Activator.CreateInstance(T, ConnectionString);
            object obj = objectHandle;
            if (obj != null)
            {
                if (obj is IDbOrm)
                {
                    dataLayer = (IDbOrm)obj;
                }
                else
                {
                    throw new Exception(string.Format("Type '{0}' is not found.", DataLayerType));
                }
            }
            else
            {
                throw new Exception(string.Format("Type '{0}' can not be created.", DataLayerType));
            }
            return dataLayer;
        }
    }
}
