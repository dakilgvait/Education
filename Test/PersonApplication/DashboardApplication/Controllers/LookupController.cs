using DashboardApplication.Models.Select2;
using Microsoft.AspNetCore.Mvc;
using Person.DTO;
using Person.Service;
using Person.Service.Abstraction;
using Unity;

namespace DashboardApplication.Controllers
{
    public class LookupController : Controller
    {
        private IGenderService genderService;

        public LookupController(IUnityContainer container)
        {
            this.genderService = new GenderService(container);
        }

        [HttpPost]
        public JsonResult Genders(RequestAjaxPostModel model)
        {
            GenderModel[] genderModels;

            if (string.IsNullOrEmpty(model.name))
            {
                genderModels = this.genderService.GetGenders();
            }
            else
            {
                genderModels = this.genderService.GetGenders(model.name);
            }

            return Json(new ResponseAjaxPostModel(genderModels));
        }
    }
}