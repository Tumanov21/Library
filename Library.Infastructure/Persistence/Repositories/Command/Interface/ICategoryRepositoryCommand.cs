using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;

namespace Library.Infastructure.Persistence.Repositories.Command.Interface
{
    public interface ICategoryRepositoryCommand
    {
        Task<bool> Add(AddCategoryDto category);
        Task<bool> Remove(int Id);
        Task<bool> Update(UpdateCategoryDto category);
    }
}