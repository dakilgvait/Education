using Person.DAL.Entity;
using Person.DTO;

namespace Person.Service.Abstraction
{
    public interface IGenderService
    {
        GenderModel[] GetGenders();

        GenderModel[] GetGenders(string name);
    }
}