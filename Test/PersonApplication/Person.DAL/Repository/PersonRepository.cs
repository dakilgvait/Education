using Person.DAL.Context;
using Person.DAL.Entity;
using System;
using System.Linq;

namespace Person.DAL.Repository
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(EntityContext context)
            : base(context) { }

        public int Create(PersonEntity entity)
        {
            var context = this.EntityContext;
            context.PersonEntities.Add(entity);
            return context.SaveChanges();
        }

        public int Delete(PersonEntity entity)
        {
            var context = this.EntityContext;
            context.PersonEntities.Remove(entity);
            return context.SaveChanges();
        }

        public int Edit(PersonEntity entity)
        {
            var context = this.EntityContext;
            context.PersonEntities.Update(entity);
            return context.SaveChanges();
        }

        public int GetCount()
        {
            return this.EntityContext.PersonEntities.Count();
        }

        public IQueryable<PersonEntity> GetPerson(int id)
        {
            return this.EntityContext.PersonEntities.Where(i => i.Id == id);
        }

        public IQueryable<PersonEntity> GetPersonEntities()
        {
            return this.EntityContext.PersonEntities.Select(i => i);
        }
    }
}