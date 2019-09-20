using Person.DTO;

namespace Person.Service.Abstraction
{
    public interface IPersonService
    {
        int Count();

        int GetPaginatedFullTextSearchCount(string value);

        PersonViewModel[] GetPaginatedList(int start, int end);

        PersonViewModel[] GetPaginatedFullTextSearch(string value, int start, int end);

        PersonViewModel Delete(PersonEditModel model);

        PersonViewModel Update(PersonEditModel model);

        PersonViewModel Create(PersonNewModel model);
    }
}