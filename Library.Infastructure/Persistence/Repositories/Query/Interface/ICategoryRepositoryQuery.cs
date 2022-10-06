using Library.Domain.Entities;

namespace Library.Infastructure.Persistence.Repositories.Query.Interface
{
    public interface ICategoryRepositoryQuery
    {
        Task<IReadOnlyCollection<Category>> GetAll();
        Task<Category?> GetById(int Id);
    }
}