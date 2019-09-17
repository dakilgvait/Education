using Person.DAL.Entity;
using System.Linq;

namespace Person.DAL.Repository
{
    public interface IPersonRepository
    {
        IQueryable<PersonEntity> GetPersonEntities();

        IQueryable<PersonEntity> GetPerson(int id);

        int Create(PersonEntity entity);

        int Delete(PersonEntity entity);

        int Edit(PersonEntity entity);

        int GetCount();
    }
}