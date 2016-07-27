using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Contracts;
using Repository.Repository;

namespace BusinessLayer.IoC
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IGeneralSettingRepository>().ImplementedBy<GeneralSettingRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IMessageRepository>().ImplementedBy<MessageRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IContactRepository>().ImplementedBy<ContactRepository>().LifeStyle.Singleton);
            container.Register(Component.For<IGameRepository>().ImplementedBy<GameRepository>().LifeStyle.Singleton);
        }
    }
}