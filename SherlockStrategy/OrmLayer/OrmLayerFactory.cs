using System;

namespace OrmLayer
{
    public class OrmLayerFactory
    {
        public static IDbOrm Create(string DataLayerType, string ConnectionString)
        {
<<<<<<< HEAD
            IDbOrm dataLayer = null;
            Type T = Type.GetType(DataLayerType);
            object objectHandle = Activator.CreateInstance(T, ConnectionString);
=======
            IDbOrm<T> dataLayer = null;
            Type X = Type.GetType(DataLayerType);
            object objectHandle = Activator.CreateInstance(X, ConnectionString);
>>>>>>> 6012b2a54b7483448f8dd89c0fe36b5da31ceb29
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
