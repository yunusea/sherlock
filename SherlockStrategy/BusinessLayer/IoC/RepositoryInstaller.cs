using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Repositorys.Repository;
using Contracts;

namespace BusinessLayer.IoC
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifeStyle.Singleton);
        }
    }
}