using Library.Domain.Entities;
using Library.Infastructure.Data.Repositories.Command.Interface;
using Library.Infastructure.Data.Repositories.Query.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Data.Repositories.Command.Implementation
{
    public class BookRepositoryCommand: IBookRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly BookRepositoryQuery _bookRepositoryQuery;

        public BookRepositoryCommand(EFContext context, BookRepositoryQuery bookRepositoryQuery)
        {
            _context = context;
            _bookRepositoryQuery = bookRepositoryQuery;
        }

        public async Task Add(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            var model = await _bookRepositoryQuery.GetOne(book.Id);
            book.Title = model?.Title;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var model = await _bookRepositoryQuery.GetOne(id);
            _context.Book.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
