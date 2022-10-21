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
using AutoMapper;
using Library.Infrastructure.Persistence.Dtos.CategoryDtos;

namespace Library.Infastructure.Persistence.Repositories.Query.Implementation
{
    public class CategoryRepositoryQuery : ICategoryRepositoryQuery
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryRepositoryQuery> _logger;

        public CategoryRepositoryQuery(EFContext context, ILogger<CategoryRepositoryQuery> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<GetCategoryDto>> GetAll()
        {
            _logger.LogInformation("GetAll");
            var result = await _context.Category.AsNoTracking().ToListAsync();
            return _mapper.Map<IReadOnlyCollection<GetCategoryDto>>(result);
        }

        public async Task<GetCategoryDto?> GetById(int Id)
        {
            var result = await _context.Category.AsNoTracking().SingleOrDefaultAsync(c => c.Id == Id);
            return _mapper.Map<GetCategoryDto>(result);
        }
    }
}
