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
using Microsoft.EntityFrameworkCore;

namespace Library.Infastructure.Persistence.Repositories.Command.Implementation
{
    public class BookRepositoryCommand: IBookRepositoryCommand
    {
        private readonly EFContext _context;

        public BookRepositoryCommand(EFContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            var model = await _context.Book.SingleOrDefaultAsync(c => c.Id == book.Id);
            book.Title = model?.Title;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var model = await _context.Book.SingleOrDefaultAsync(c => c.Id == id);
            _context.Book.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
