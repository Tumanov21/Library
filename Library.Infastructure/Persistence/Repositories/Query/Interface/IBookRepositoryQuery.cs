using Library.Domain.Entities;

namespace Library.Infastructure.Data.Repositories.Query.Interface
{
    public interface IBookRepositoryQuery
    {
        Task<IReadOnlyCollection<Book>> GetAll();
        Task<Book?> GetOne(Guid id);
    }
}