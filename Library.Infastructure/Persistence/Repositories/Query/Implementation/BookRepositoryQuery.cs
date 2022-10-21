using Library.Domain.Entities;
using Library.Infastructure.Persistence.Repositories.Query.Interface;
using Library.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Infrastructure.Persistence.Dto.BookDto;

namespace Library.Infastructure.Persistence.Repositories.Query.Implementation
{
    public class BookRepositoryQuery: IBookRepositoryQuery
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public BookRepositoryQuery(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<GetBookDto>> GetAll()
        {
            var result = await _context.Book.ToListAsync();
            return _mapper.Map<IReadOnlyCollection<GetBookDto>>(result);
        }

        public async Task<GetBookDto> GetById(int id)
        {
            var result = await _context.Book.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetBookDto>(result);
        }
    }

}
