using Library.Domain.Entities;

namespace Library.Infastructure.Persistence.Repositories.Query.Interface
{
    public interface IBookRepositoryQuery
    {
        Task<IReadOnlyCollection<Book>> GetAll();
        Task<Book?> GetById(int id);
    }
}