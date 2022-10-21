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
    public record CreateBookCommand(AddBookDto BookDto) :IRequest;
}
