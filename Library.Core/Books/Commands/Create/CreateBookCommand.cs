using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dto.BookDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Create
{
    public class CreateBookCommand
    {
        public class Request : IRequest<Response>
        {
            public AddBookDto AddBookDto { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
        }
    }
}
