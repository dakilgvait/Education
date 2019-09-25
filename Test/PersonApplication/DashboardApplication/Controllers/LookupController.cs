using DashboardApplication.Models.Select2;
using Microsoft.AspNetCore.Mvc;
using Person.DTO;
using Person.Service;
using Person.Service.Abstraction;
using ServiceStack.Redis;
using System.Linq;
using Unity;

namespace DashboardApplication.Controllers
{
    public class LookupController : Controller
    {
        private const string genderCacheKey = "genders";
        private readonly IRedisClientsManager redis;
        private readonly IGenderService genderService;

        public LookupController(IUnityContainer container)
        {
            this.redis = container.Resolve<IRedisClientsManager>();
            this.genderService = new GenderService(container);
            this.InitializeCache();
        }

        [HttpPost]
        public JsonResult Genders(RequestAjaxPostModel model)
        {
            GenderModel[] genderModels = this.GetCachedGenders(model.name);
            return Json(new ResponseAjaxPostModel(genderModels));
        }

        protected void InitializeCache()
        {
            using (var client = this.redis.GetClient())
            {
                var typedClient = client.As<GenderModel>();
                var hash = typedClient.GetHash<string>(genderCacheKey);
                if (hash.Count == 0)
                {
                    var genders = this.genderService.GetGenders().ToDictionary(el => $"name:{el.Name}", el => el);
                    typedClient.SetRangeInHash(hash, genders);
                }
            }
        }

        protected GenderModel[] GetCachedGenders(string name = null)
        {
            GenderModel[] genderModels;

            using (var client = this.redis.GetClient())
            {
                var typedClient = client.As<GenderModel>();
                var hash = typedClient.GetHash<string>(genderCacheKey);

                if (string.IsNullOrEmpty(name))
                {
                    genderModels = typedClient.GetHashValues(hash).ToArray();
                }
                else
                {
                    genderModels = hash.Where(el => el.Key == $"name:{name}").Select(el => el.Value).ToArray();
                }
            }

            return genderModels;
        }
    }
}