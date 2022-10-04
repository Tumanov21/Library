using Library.Domain.Entities;
using Library.Infastructure.Data.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Data.Repositories
{
    public class CategoryRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly CategoryRepositoryQuery _categoryRepositoryQuery;

        public CategoryRepositoryCommand(CategoryRepositoryQuery categoryRepositoryQuery, EFContext context)
        {
            _categoryRepositoryQuery = categoryRepositoryQuery;
            _context = context;
        }

        public async Task Add(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            var model = await _categoryRepositoryQuery.GetOne(category.Id);
            category.Title = model.Title;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid Id)
        {
            var model = await _categoryRepositoryQuery.GetOne(Id);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
