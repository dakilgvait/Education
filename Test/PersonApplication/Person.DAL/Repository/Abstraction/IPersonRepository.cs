using Person.DAL.Entity;

namespace Person.DAL.Repository
{
    public interface IPersonRepository
    {
        PersonEntity[] GetPersonEntities(int countSkip, int countTake);

        PersonEntity[] FullTextSearchEntities(string value, int countSkip, int countTake);

        PersonEntity GetPersonById(int id);

        PersonEntity Insert(PersonEntity entity);

        PersonEntity Update(PersonEntity entity);

        PersonEntity Delete(PersonEntity entity);

        int GetCount();

        int FullTextSearchEntitiesCount(string value);
    }
}