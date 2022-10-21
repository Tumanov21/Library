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
using AutoMapper;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;

namespace Library.Infastructure.Persistence.Repositories.Command.Implementation
{
    public class CategoryRepositoryCommand: ICategoryRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;

        public CategoryRepositoryCommand(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddCategoryDto category)
        {
            var result = _mapper.Map<Category>(category);
            await _context.Category.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateCategoryDto category)
        {
            var model = await _context.Category.AsNoTracking().SingleOrDefaultAsync(c => c.Id == category.Id);
            model = _mapper.Map<Category>(category);
            _context.Category.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int Id)
        {
            var model = await _context.Category.AsNoTracking().SingleOrDefaultAsync(c => c.Id == Id);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
