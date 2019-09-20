using Person.DAL.Context;
using Person.DAL.Repository;
using Unity;

namespace Person.DAL.UnitOfWork
{
    public class ApplicationUOW : IApplicationUnitOfWork
    {
        public ApplicationUOW(IUnityContainer container)
        {
            EntityContext entityContext = new EntityContext();
            this.PersonRepository = container.Resolve<IPersonRepository>();
            this.LookupRepository = container.Resolve<ILookupRepository>();
        }

        public IPersonRepository PersonRepository { get; }
        public ILookupRepository LookupRepository { get; }

        public static IUnityContainer InitializeContainer(IUnityContainer container)
        {
            container.RegisterType<ILookupRepository, LookupRepository>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            return container;
        }
    }
}