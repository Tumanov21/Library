using Library.Domain.Entities;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using Library.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Library.Infastructure.Persistence.Repositories.Query.Implementation
{
    public class CategoryRepositoryQuery : ICategoryRepositoryQuery
    {
        private readonly EFContext _context;
        private readonly ILogger<CategoryRepositoryQuery> _logger;

        public CategoryRepositoryQuery(EFContext context, ILogger<CategoryRepositoryQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<Category>> GetAll()
        {
            _logger.LogInformation("GetAll");
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetById(int Id)
            => await _context.Category.SingleOrDefaultAsync(c => c.Id == Id);
    }
}
