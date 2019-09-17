using Person.DAL.Context;
using Person.DAL.Entity;
using System.Linq;

namespace Person.DAL.Repository
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(EntityContext context)
            : base(context) { }

        public IQueryable<GenderEntity> GetGenderEntities()
        {
            return this.EntityContext.GenderEntities.Select(i => i);
        }
    }
}