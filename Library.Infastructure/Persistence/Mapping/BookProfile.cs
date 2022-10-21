using AutoMapper;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using Library.Infrastructure.Persistence.Dtos.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Mapping
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetBookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
