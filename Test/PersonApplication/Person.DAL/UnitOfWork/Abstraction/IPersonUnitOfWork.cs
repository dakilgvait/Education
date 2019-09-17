using Person.DAL.Repository;

namespace Person.DAL.UnitOfWork
{
    public interface IApplicationUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
        ILookupRepository LookupRepository { get; }
    }
}