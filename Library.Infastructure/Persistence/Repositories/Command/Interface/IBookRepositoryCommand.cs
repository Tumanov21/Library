using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using Library.Infrastructure.Persistence.Dtos.BookDtos;

namespace Library.Infastructure.Persistence.Repositories.Command.Interface
{
    public interface IBookRepositoryCommand
    {
        Task<bool> Add(AddBookDto book);
        Task<bool> Remove(int id);
        Task<bool> Update(UpdateBookDto book);
    }
}