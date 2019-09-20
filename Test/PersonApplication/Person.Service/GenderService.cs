using Person.DAL.Entity;
using Person.DTO;
using Person.Service.Abstraction;
using System.Linq;
using Unity;

namespace Person.Service
{
    public class GenderService : BaseService, IGenderService
    {
        public GenderService(IUnityContainer container)
            : base(container) { }

        public GenderModel[] GetGenders()
        {
            return this.appUnitOfWork.LookupRepository.GetGenderEntities().Select(i => this.ConvertToModel(i)).ToArray();
        }

        public GenderModel[] GetGenders(string name)
        {
            return this.appUnitOfWork.LookupRepository.GetGenderEntitiesByName(name).Select(i => this.ConvertToModel(i)).ToArray();
        }

        protected GenderModel ConvertToModel(GenderEntity e)
        {
            var result = new GenderModel()
            {
                Id = e.Id,
                Code = (int)e.Code,
                Name = e.Name
            };
            return result;
        }
    }
}