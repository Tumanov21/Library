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
using Microsoft.Extensions.Logging;

namespace Library.Infastructure.Persistence.Repositories.Command.Implementation
{
    public class CategoryRepositoryCommand: ICategoryRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryRepositoryCommand> _logger;

        public CategoryRepositoryCommand(EFContext context, IMapper mapper, ILogger<CategoryRepositoryCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Add(AddCategoryDto category)
        {
            var result = _mapper.Map<Category>(category);
            await _context.Category.AddAsync(result);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Add{@result.Id}");
            return true;
        }

        public async Task<bool> Update(UpdateCategoryDto category)
        {
            var model = await _context.Category.AsNoTracking().SingleOrDefaultAsync(c => c.Id == category.Id);
            model = _mapper.Map<Category>(category);
            _context.Category.Update(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Update{@model.Id}");
            return true;
        }

        public async Task<bool> Remove(int Id)
        {
            var model = await _context.Category.AsNoTracking().SingleOrDefaultAsync(c => c.Id == Id);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Remove{@model.Id}");
            return true;
        }
    }
}
