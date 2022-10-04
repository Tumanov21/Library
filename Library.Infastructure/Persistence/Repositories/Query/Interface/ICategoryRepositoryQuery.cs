using Library.Domain.Entities;

namespace Library.Infastructure.Data.Repositories.Query.Interface
{
    public interface ICategoryRepositoryQuery
    {
        Task<IReadOnlyCollection<Category>> GetAll();
        Task<Category?> GetOne(Guid Id);
    }
}