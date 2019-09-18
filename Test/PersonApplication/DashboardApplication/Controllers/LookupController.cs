using DashboardApplication.Models.Select2;
using Microsoft.AspNetCore.Mvc;
using Person.DAL.Entity;
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
            IQueryable<GenderEntity> dataEntity = this.appUnitOfWork.LookupRepository.GetGenderEntities();

            GenderEntity[] genderEntities;

            if (string.IsNullOrEmpty(model.name))
            {
                genderEntities = dataEntity.ToArray();
            }
            else
            {
                genderEntities = dataEntity.Where(i => i.Name == model.name).ToArray();
            }

            var dataModel = genderEntities.Select(entity => new ItemModel() {
                Id = entity.Id,
                Text = entity.Name
            });

            var response = new ResponseAjaxPostModel() {
                items = dataModel.ToArray()
            };
            return Json(response);
        }
    }
}