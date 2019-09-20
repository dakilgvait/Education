using DashboardApplication.Models.DataTable;
using Microsoft.AspNetCore.Mvc;
using Person.DTO;
using Person.Service;
using Person.Service.Abstraction;
using System.Linq;
using Unity;

namespace DashboardApplication.Controllers
{
    public class DataController : Controller
    {
        private IPersonService personService;

        public DataController(IUnityContainer container)
        {
            this.personService = new PersonService(container);
        }

        [HttpPost]
        public JsonResult View(RequstAjaxPostModel model)
        {
            PersonViewModel[] persons;
            int totalCount;

            if (string.IsNullOrEmpty(model.search.value))
            {
                totalCount = this.personService.Count();
                persons = this.personService.GetPaginatedList(model.start, model.length);
            }
            else
            {
                totalCount = this.personService.GetPaginatedFullTextSearchCount(model.search.value);
                persons = this.personService.GetPaginatedFullTextSearch(model.search.value, model.start, model.length);
            }

            var response = new ResponseAjaxPostModel(persons)
            {
                recordsFiltered = totalCount,
                draw = model.draw
            };

            return Json(response);
        }

        [HttpPost]
        public JsonResult Delete(PersonEditModel model)
        {
            var response = this.personService.Delete(model);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Edit(PersonEditModel model)
        {
            if (ModelState.IsValid)
            {
                var response = this.personService.Update(model);
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
                var response = this.personService.Create(model);
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