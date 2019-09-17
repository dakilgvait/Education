using Person.DAL.Context;
using Person.DAL.Repository;

namespace Person.DAL.UnitOfWork
{
    public class ApplicationUOW : IApplicationUnitOfWork
    {
        public ApplicationUOW()
        {
            EntityContext entityContext = new EntityContext();
            this.PersonRepository = new PersonRepository(entityContext);
            this.LookupRepository = new LookupRepository(entityContext);
        }

        public IPersonRepository PersonRepository { get; }
        public ILookupRepository LookupRepository { get; }
    }
}