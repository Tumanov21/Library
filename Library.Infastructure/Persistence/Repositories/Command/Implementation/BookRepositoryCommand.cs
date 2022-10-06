using Library.Domain.Entities;
using Library.Infastructure.Persistence.Repositories.Command.Interface;
using Library.Infastructure.Persistence.Repositories.Query.Implementation;
using Library.Infastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infastructure.Persistence.Repositories.Query.Interface;

namespace Library.Infastructure.Persistence.Repositories.Command.Implementation
{
    public class BookRepositoryCommand: IBookRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly IBookRepositoryQuery _bookRepositoryQuery;
        private readonly IBookRepositoryCommand _bookRepositoryCommand;

        public BookRepositoryCommand(EFContext context, IBookRepositoryCommand bookRepositoryQuery, IBookRepositoryCommand bookRepositoryCommand)
        {
            _context = context;
            _bookRepositoryQuery = _bookRepositoryQuery;
            _bookRepositoryCommand = _bookRepositoryCommand;
        }

        public async Task Add(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            var model = await _bookRepositoryQuery.GetById(book.Id);
            book.Title = model?.Title;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var model = await _bookRepositoryQuery.GetById(id);
            _context.Book.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
