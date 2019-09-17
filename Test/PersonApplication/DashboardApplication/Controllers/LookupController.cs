using DashboardApplication.Models.Select2;
using Microsoft.AspNetCore.Mvc;
using Person.DAL.UnitOfWork;
using Person.DTO;
using System.Linq;

namespace DashboardApplication.Controllers
{
    public class LookupController : Controller
    {
        private IApplicationUnitOfWork appUnitOfWork;

        public LookupController()
        {
            this.appUnitOfWork = new ApplicationUOW();
        }

        [HttpPost]
        public JsonResult Genders(RequestAjaxPostModel model)
        {
            var dataEntity = this.appUnitOfWork.LookupRepository.GetGenderEntities();
            var dataModel = dataEntity.Select(entity => new GenderModel() {
                Id = entity.Id,
                Code = (int)entity.Code,
                Name = entity.Name
            });
            var response = new ResponseAjaxPostModel() {
                items = dataModel.Select(i => new ItemModel() {
                    Id = i.Id,
                    Text = i.Name
                }).ToArray()
            };
            return Json(response);
        }
    }
}