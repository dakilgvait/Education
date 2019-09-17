using DashboardApplication.Models.DataTable;
using Microsoft.AspNetCore.Mvc;
using Person.DAL.Entity;
using Person.DAL.UnitOfWork;
using Person.DTO;
using System.Linq;

namespace DashboardApplication.Controllers
{
    public class DataController : Controller
    {
        private IApplicationUnitOfWork appUnitOfWork;

        public DataController()
        {
            this.appUnitOfWork = new ApplicationUOW();
        }

        [HttpPost]
        public JsonResult View(RequstAjaxPostModel model)
        {
            IQueryable<PersonEntity> dataEntity;
            int countTotal;

            if (string.IsNullOrEmpty(model.search.value))
            {
                dataEntity = this.appUnitOfWork.PersonRepository.GetPersonEntities();
                countTotal = dataEntity.Count();
            }
            else
            {
                dataEntity = this.appUnitOfWork.PersonRepository.GetPersonEntities().Where(
                    e => e.FirstName.Contains(model.search.value)
                    || e.LastName.Contains(model.search.value)
                    || e.Gender.Name.Contains(model.search.value)
                    || e.PersonNumber.Contains(model.search.value)
                    || e.Salary.ToString().Contains(model.search.value));

                countTotal = dataEntity.Count();
            }

            PersonViewModel[] dataModel = dataEntity
                   .Skip(model.start)
                   .Take(model.length)
                   .Select(entity => new PersonViewModel() {
                       Id = entity.Id,
                       Birthdate = entity.Birthdate,
                       FirstName = entity.FirstName,
                       Gender = entity.Gender.Name,
                       LastName = entity.LastName,
                       PersonNumber = entity.PersonNumber,
                       Salary = entity.Salary
                   }).ToArray();

            var response = new ResponseAjaxPostModel() {
                draw = model.draw,
                recordsTotal = countTotal,
                recordsFiltered = countTotal,
                data = dataModel
            };

            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(PersonEditModel model)
        {
            var entity = new PersonEntity() {
                Id = model.Id,
                Birthdate = model.Birthdate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salary = model.Salary,
                PersonNumber = model.PersonNumber,
                GenderId = model.Gender
            };
            int count = this.appUnitOfWork.PersonRepository.Delete(entity);
            return Json(new { count = count });
        }

        [HttpPost]
        public JsonResult Edit(PersonEditModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new PersonEntity() {
                    Id = model.Id,
                    Birthdate = model.Birthdate,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    PersonNumber = model.PersonNumber,
                    GenderId = model.Gender
                };
                int count = this.appUnitOfWork.PersonRepository.Edit(entity);

                var response = this.appUnitOfWork.PersonRepository.GetPerson(entity.Id).Select(
                        e => new PersonViewModel() {
                            Id = e.Id,
                            Birthdate = e.Birthdate,
                            FirstName = e.FirstName,
                            Gender = e.Gender.Name,
                            LastName = e.LastName,
                            PersonNumber = e.PersonNumber,
                            Salary = e.Salary
                        }).First();

                return Json(response);
            }
            else
            {
                return Json(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
            }
        }

        [HttpPost]
        public JsonResult Create(PersonNewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new PersonEntity() {
                    Birthdate = model.Birthdate,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Salary = model.Salary,
                    PersonNumber = model.PersonNumber,
                    GenderId = model.Gender
                };

                this.appUnitOfWork.PersonRepository.Create(entity);

                var response = this.appUnitOfWork.PersonRepository.GetPerson(entity.Id).Select(
                    e => new PersonViewModel() {
                        Id = e.Id,
                        Birthdate = e.Birthdate,
                        FirstName = e.FirstName,
                        Gender = e.Gender.Name,
                        LastName = e.LastName,
                        PersonNumber = e.PersonNumber,
                        Salary = e.Salary
                    }).First();

                return Json(response);
            }
            else
            {
                return Json(ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage));
            }
        }
    }
}