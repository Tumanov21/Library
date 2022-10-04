using Library.Domain.Entities;

namespace Library.Infastructure.Data.Repositories.Command.Interface
{
    public interface IBookRepositoryCommand
    {
        Task Add(Book book);
        Task Remove(Guid id);
        Task Update(Book book);
    }
}