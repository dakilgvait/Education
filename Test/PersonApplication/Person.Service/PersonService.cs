using Person.DAL.Entity;
using Person.DTO;
using Person.Service.Abstraction;
using System.Linq;
using Unity;

namespace Person.Service
{
    public class PersonService : BaseService, IPersonService
    {
        public PersonService(IUnityContainer container)
            : base(container) { }

        public int Count()
        {
            return this.appUnitOfWork.PersonRepository.GetCount();
        }

        protected PersonViewModel ConvertToView(PersonEntity entity)
        {
            var result = new PersonViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Birthdate = entity.Birthdate,
                Gender = entity.Gender?.Name,
                PersonNumber = entity.PersonNumber,
                Salary = entity.Salary
            };
            return result;
        }

        protected PersonEntity ConvertToEntity(PersonNewModel model)
        {
            var result = new PersonEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthdate = model.Birthdate,
                GenderId = model.Gender,
                PersonNumber = model.PersonNumber,
                Salary = model.Salary
            };
            return result;
        }

        protected PersonEntity ConvertToEntity(PersonEditModel model)
        {
            var result = new PersonEntity()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthdate = model.Birthdate,
                GenderId = model.Gender,
                PersonNumber = model.PersonNumber,
                Salary = model.Salary
            };
            return result;
        }

        public PersonViewModel Create(PersonNewModel model)
        {
            var entity = this.ConvertToEntity(model);
            var executedEntity = this.appUnitOfWork.PersonRepository.Insert(entity);
            return this.ConvertToView(executedEntity);
        }

        public PersonViewModel Delete(PersonEditModel model)
        {
            var entity = this.ConvertToEntity(model);
            var executedEntity = this.appUnitOfWork.PersonRepository.Delete(entity);
            return this.ConvertToView(executedEntity);
        }

        PersonViewModel[] IPersonService.GetPaginatedList(int start, int end)
        {
            var executedEntities = this.appUnitOfWork.PersonRepository.GetPersonEntities(start, end);
            return executedEntities.Select(e => this.ConvertToView(e)).ToArray();
        }

        PersonViewModel[] IPersonService.GetPaginatedFullTextSearch(string value, int start, int end)
        {
            var executedEntities = this.appUnitOfWork.PersonRepository.FullTextSearchEntities(value, start, end);
            return executedEntities.Select(e => this.ConvertToView(e)).ToArray();
        }

        public PersonViewModel Update(PersonEditModel model)
        {
            var entity = this.ConvertToEntity(model);
            var executedEntity = this.appUnitOfWork.PersonRepository.Update(entity);
            return this.ConvertToView(executedEntity);
        }

        int IPersonService.GetPaginatedFullTextSearchCount(string value)
        {
            return this.appUnitOfWork.PersonRepository.FullTextSearchEntitiesCount(value);
        }
    }
}