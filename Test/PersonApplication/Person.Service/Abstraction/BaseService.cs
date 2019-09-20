using Person.DAL.UnitOfWork;
using Unity;
using Unity.Resolution;

namespace Person.Service.Abstraction
{
    public abstract class BaseService
    {
        protected IApplicationUnitOfWork appUnitOfWork;

        public BaseService(IUnityContainer container)
        {
            this.appUnitOfWork = container.Resolve<IApplicationUnitOfWork>(new ParameterOverride(typeof(IUnityContainer), container));
        }

        public static IUnityContainer InitializeContainer(IUnityContainer container)
        {
            container.RegisterType<IApplicationUnitOfWork, ApplicationUOW>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterType<IPersonService, IPersonService>();
            return container;
        }
    }
}