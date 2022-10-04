﻿using Library.Domain.Entities;
using Library.Infastructure.Data.Repositories.Query.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Data.Repositories.Query.Implementation
{
    public class BookRepositoryQuery: IBookRepositoryQuery
    {
        private readonly EFContext _context;
        public BookRepositoryQuery(EFContext context) => _context = context;

        public async Task<IReadOnlyCollection<Book>> GetAll()
            => await _context.Book.ToListAsync();

        public async Task<Book?> GetOne(Guid id)
            => await _context.Book.SingleOrDefaultAsync(c => c.Id == id);
    }

}
