using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IoC
{
    public static class Castle
    {
        private static IWindsorContainer _Container;

        public static void Initialize()
        {
            _Container = new WindsorContainer().Install(new RepositoryInstaller());
        }

        public static T Resolve<T>()
        {
            return _Container.Resolve<T>();
        }
    }
}
