using Library.Domain.Entities;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using Library.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Persistence.Repositories.Query.Implementation
{
    public class CategoryRepositoryQuery : ICategoryRepositoryQuery
    {
        private readonly EFContext _context;

        public CategoryRepositoryQuery(EFContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Category>> GetAll()
            => await _context.Category.ToListAsync();

        public async Task<Category?> GetById(int Id)
            => await _context.Category.SingleOrDefaultAsync(c => c.Id == Id);
    }
}
