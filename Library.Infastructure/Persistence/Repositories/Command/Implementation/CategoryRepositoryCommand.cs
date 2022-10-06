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
    public class CategoryRepositoryCommand: ICategoryRepositoryCommand
    {
        private readonly EFContext _context;

        public CategoryRepositoryCommand(EFContext context)
        {
            _context = context;
        }

        public async Task Add(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            var model = await _context.Category.SingleOrDefaultAsync(c => c.Id == category.Id);
            category.Title = model.Title;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int Id)
        {
            var model = await _context.Category.SingleOrDefaultAsync(c => c.Id == Id);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
