using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using Library.Infrastructure.Persistence.Dtos.BookDtos;

namespace Library.Infastructure.Persistence.Repositories.Command.Interface
{
    public interface IBookRepositoryCommand
    {
        Task Add(AddBookDto book);
        Task Remove(int id);
        Task Update(UpdateBookDto book);
    }
}