using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;

namespace Library.Infastructure.Persistence.Repositories.Query.Interface
{
    public interface IBookRepositoryQuery
    {
        Task<IReadOnlyCollection<GetBookDto>> GetAll();
        Task<GetBookDto> GetById(int id);
    }
}