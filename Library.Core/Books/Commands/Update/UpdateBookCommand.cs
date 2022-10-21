using Library.Domain.Entities;
using Library.Infrastructure.Persistence.Dtos.BookDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Books.Commands.Update
{
    public record UpdateBookCommand(UpdateBookDto Book):IRequest;
}
