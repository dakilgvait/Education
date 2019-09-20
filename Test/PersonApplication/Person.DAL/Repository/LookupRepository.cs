using Person.DAL.Context;
using Person.DAL.Entity;
using System.Linq;

namespace Person.DAL.Repository
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(EntityContext context)
            : base(context) { }

        public GenderEntity[] GetGenderEntitiesByName(string name)
        {
            return this.EntityContext.GenderEntities.Where(i => i.Name == name).ToArray();
        }

        GenderEntity[] ILookupRepository.GetGenderEntities()
        {
            return this.EntityContext.GenderEntities.ToArray();
        }
    }
}