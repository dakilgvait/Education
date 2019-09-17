using Person.DAL.Context;

namespace Person.DAL.Repository
{
    public abstract class BaseRepository
    {
        protected EntityContext EntityContext { get; }

        public BaseRepository(EntityContext context)
        {
            this.EntityContext = context;
        }
    }
}