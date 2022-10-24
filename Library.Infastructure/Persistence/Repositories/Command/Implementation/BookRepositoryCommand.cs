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
using Library.Infrastructure.Persistence.Dto.BookDto;
using AutoMapper;
using Library.Infrastructure.Persistence.Dtos.BookDtos;
using Microsoft.Extensions.Logging;

namespace Library.Infastructure.Persistence.Repositories.Command.Implementation
{
    public class BookRepositoryCommand: IBookRepositoryCommand
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRepositoryCommand> _logger;

        public BookRepositoryCommand(EFContext context, IMapper mapper, ILogger<BookRepositoryCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Add(AddBookDto BookDto)
        {
            var mapping = _mapper.Map<Book>(BookDto);
            await _context.AddAsync(mapping);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Add {@mapping.Id}");
            return true;
        }

        public async Task<bool> Update(UpdateBookDto BookDto)
        {
            var model = await _context.Book.AsNoTracking().SingleOrDefaultAsync(c => c.Id == BookDto.Id);
            model = _mapper.Map<Book>(BookDto);
            _context.Book.Update(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Update{@model.Id}");
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var model = await _context.Book.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
            _context.Book.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Remove{@model.Id}");
            return true;
        }
    }
}
