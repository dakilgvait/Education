using Microsoft.EntityFrameworkCore;
using Person.DAL.Context;
using Person.DAL.Entity;
using System.Linq;

namespace Person.DAL.Repository
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(EntityContext context)
            : base(context) { }

        public PersonEntity Delete(PersonEntity entity)
        {
            this.EntityContext.PersonEntities.Remove(entity);
            int count = this.EntityContext.SaveChanges();
            return entity;
        }

        public PersonEntity[] FullTextSearchEntities(string value, int countSkip, int countTake)
        {
            IQueryable<PersonEntity> entitiesFiltered = this.FullTextSearchEntities(this.EntityContext.PersonEntities, value);
            IQueryable<PersonEntity> entitiesPaginated = this.GetPersonEntities(entitiesFiltered, countSkip, countTake);
            return entitiesPaginated.ToArray();
        }

        public int FullTextSearchEntitiesCount(string value)
        {
            return this.FullTextSearchEntities(this.EntityContext.PersonEntities, value).Count();
        }

        public int GetCount()
        {
            return this.EntityContext.PersonEntities.Count();
        }

        public PersonEntity GetPersonById(int id)
        {
            return this.EntityContext.PersonEntities.Where(i => i.Id == id).First();
        }

        public PersonEntity[] GetPersonEntities(int countSkip, int countTake)
        {
            return this.GetPersonEntities(this.EntityContext.PersonEntities, countSkip, countTake).ToArray();
        }

        public PersonEntity Insert(PersonEntity entity)
        {
            this.EntityContext.PersonEntities.Add(entity);
            int count = this.EntityContext.SaveChanges();
            return entity;
        }

        public PersonEntity Update(PersonEntity entity)
        {
            this.EntityContext.PersonEntities.Update(entity);
            int count = this.EntityContext.SaveChanges();
            return entity;
        }

        protected IQueryable<PersonEntity> GetPersonEntities(IQueryable<PersonEntity> list, int countSkip, int countTake)
        {
            return list.Include(c => c.Gender).Skip(countSkip).Take(countTake);
        }

        protected IQueryable<PersonEntity> FullTextSearchEntities(IQueryable<PersonEntity> list, string value)
        {
            return list.Where(e => e.FirstName.Contains(value)
            || e.LastName.Contains(value)
            || e.Gender.Name.Contains(value)
            || e.PersonNumber.Contains(value)
            || e.Salary.ToString().Contains(value));
        }
    }
}