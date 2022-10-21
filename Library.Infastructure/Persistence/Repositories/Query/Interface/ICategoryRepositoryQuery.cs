using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;

namespace Library.Infastructure.Persistence.Repositories.Query.Interface
{
    public interface ICategoryRepositoryQuery
    {
        Task<IReadOnlyCollection<GetCategoryDto>> GetAll();
        Task<GetCategoryDto> GetById(int Id);
    }
}