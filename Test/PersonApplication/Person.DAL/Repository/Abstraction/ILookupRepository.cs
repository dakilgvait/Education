using Person.DAL.Entity;
using System.Linq;

namespace Person.DAL.Repository
{
    public interface ILookupRepository
    {
        IQueryable<GenderEntity> GetGenderEntities();
    }
}