using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;

namespace Library.Infastructure.Persistence.Repositories.Command.Interface
{
    public interface ICategoryRepositoryCommand
    {
        Task Add(AddCategoryDto category);
        Task Remove(int Id);
        Task Update(UpdateCategoryDto category);
    }
}